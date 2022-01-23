using System;
using System.ComponentModel.DataAnnotations;
using WhooberCore.Domain.Entities;
using WhooberCore.Domain.Enums;

namespace DriverApp.Models
{
    public class DriverModel
    {
        public DriverModel(Driver driver)
        {
            Name = driver.Name;
            PhoneNumber = driver.PhoneNumber;
            Rating = Math.Round(driver.Rating?.AverageScore ?? 0, 2);
            CarDescription = driver.Car?.ToString() ?? string.Empty;
            State = driver.State;
            PaymentMethod = driver.PaymentMethod?.ToString() ?? string.Empty;
            SavedCardNumber = driver.SavedCard?.CardNumber ?? string.Empty;
        }
        [Display(Name="Name")]
        public string Name { get; set; }
        [Display(Name="Phone number")]
        public string PhoneNumber { get; set; }
        [Display(Name="Rating")]
        public double Rating { get; set; }
        [Display(Name="Car description")]
        public string CarDescription { get; set; }
        [Display(Name="State")]
        public DriverState State { get; set; }
        [Display(Name="Payment method")]
        public string PaymentMethod { get; set; }
        [Display(Name="Saved card number")]
        public string SavedCardNumber { get; set; }
    }
}