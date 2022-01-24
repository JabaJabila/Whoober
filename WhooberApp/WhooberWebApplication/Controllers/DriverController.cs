using System;
using Microsoft.AspNetCore.Mvc;
using Whoober_WebApplication.Models;
using WhooberCore.Domain.Entities;
using WhooberCore.Domain.Enums;
using WhooberCore.InfrastructureAbstractions;
using WhooberCore.Payment;

namespace Whoober_WebApplication.Controllers
{
    [ApiController]
    [Route("/driversController")]
    public class DriverController : ControllerBase
    {
        private readonly IDriverService _driverService;

        public DriverController(IDriverService driverService)
        {
            _driverService = driverService;
        }

        [HttpPost("register-driver")]
        public IActionResult RegisterDriver([FromQuery] string name, [FromQuery] string number)
        {
            var driver = new Driver(name, number);
            return Ok(_driverService.RegisterDriver(driver));
        }

        [HttpPost("edit-driver-info")]
        public IActionResult EditDriver([FromQuery] Guid id, [FromQuery] DriverMutableDto driverMutableDto)
        {
            Driver driver = _driverService.FindDriverById(id);
            driver.Car = new Car(driverMutableDto.Model, driverMutableDto.Color, driverMutableDto.CarNumber, driverMutableDto.Level);
            driver.SavedCard = driverMutableDto.SavedCard;
            return Ok(_driverService.UpdateDriver(id));
        }

        [HttpPost("update-driver-location")]
        public IActionResult UpdateDriverLocation([FromQuery] Guid id, [FromBody] Location newLocation)
        {
            return Ok(_driverService.UpdateLocation(id, newLocation));
        }

        [HttpPost("update-driver-sate")]
        public IActionResult ChangeDriverState([FromQuery]Guid id, [FromQuery] DriverState state)
        {
            return state switch
            {
                DriverState.Driving => Ok(_driverService.SetDriverStateToWorking(id)),
                DriverState.Waiting => Ok(_driverService.SetDriverStateToWaiting(id)),
                DriverState.Inactive => Ok(_driverService.SetDriverStateToInactive(id)),
                _ => throw new ArgumentOutOfRangeException(nameof(state), state, null)
            };
        }

        [HttpPost("accept-order")]
        public IActionResult AcceptOrder([FromQuery] Guid id, [FromQuery] Order order)
        {
            return Ok(_driverService.AcceptOrder(id, order));
        }

        [HttpPost("deny-order")]
        public IActionResult DenyOrder(Guid id, Order order)
        {
            return Ok(_driverService.DenyOrder(id, order));
        }

        [HttpPost("change-trip-state")]
        public IActionResult ChangeTripState(Guid id, TripState state)
        {
            return state switch
            {
                TripState.AwaitDriver => Ok(_driverService.ChangeTripStateToAwaitDriver(id)),
                TripState.AwaitClient => Ok(_driverService.ChangeTripStateToAwaitClient(id)),
                TripState.OnTheWay => Ok(_driverService.ChangeTripStateToOnTheWay(id)),
                TripState.FinishedUnpaid => Ok(_driverService.ChangeTripStateToFinished(id)),
                TripState.FinishedPaid => Ok(_driverService.ChangeTripStateToFinished(id)),
                _ => throw new ArgumentOutOfRangeException(nameof(state), state, null)
            };
        }

        [HttpGet("get-active-drivers")]
        public IActionResult GetActiveDrivers()
        {
            return Ok(_driverService.GetActiveDrivers());
        }
    }
}