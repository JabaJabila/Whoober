using System;

namespace WhooberCore.Domain.Entities
{
    public class Location
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public Location(double latitude, double longitude)
        {
            Latitude = latitude;
            Longitude = longitude;
        }

        public Location()
        {
        }

        public double DistanceTo(Location other)
        {
            return Math.Sqrt(Math.Pow(Latitude - other.Latitude, 2) + Math.Pow(Longitude - other.Longitude, 2));
        }
    }
}