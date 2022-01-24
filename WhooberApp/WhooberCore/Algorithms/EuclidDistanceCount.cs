using System;
using System.Linq;
using WhooberCore.Domain.AlgorithmsAbstractions;
using WhooberCore.Domain.Entities;

namespace WhooberCore.Algorithms
{
    public class EuclidDistanceCount : IDistanceDeterminer
    {
        public double CountLength(Route route)
        {
            double length = 0;
            Location previous = route.Locations.FirstOrDefault();
            foreach (Location routeLocation in route.Locations)
            {
                length += CountLocationsDistance(previous, routeLocation);
                previous = routeLocation;
            }

            return length;
        }

        public double CountLocationsDistance(Location start, Location finish)
        {
            return Math.Sqrt(
                Math.Pow(start.Latitude - finish.Latitude, 2) + Math.Pow(start.Longitude - finish.Longitude, 2));
        }
    }
}