using System;
using WhooberCore.Domain.AlgorithmsAbstractions;
using WhooberCore.Domain.Entities;

namespace WhooberCore.Algorithms
{
    public class EuclidRouteLengthCount : IRouteLengthDeterminer
    {
        public double CountLength(Route route)
        {
            double length = 0;
            Location previous = route.Start;
            foreach (Location routeLocation in route.Locations)
            {
                length += CountLocationsDistance(previous, routeLocation);
                previous = routeLocation;
            }

            return length;
        }

        private double CountLocationsDistance(Location start, Location finish)
        {
            return Math.Sqrt(Math.Pow(start.Latitude - finish.Latitude, 2) + Math.Pow(start.Longitude - finish.Longitude, 2));
        }
    }
}