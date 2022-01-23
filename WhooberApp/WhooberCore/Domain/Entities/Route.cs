using System;
using System.Collections.Generic;
using System.Linq;
using WhooberCore.Domain.Exceptions;

namespace WhooberCore.Domain.Entities
{
    public class Route
    {
        private const int MinLocationsCount = 2;
        private List<Location> _locations;

        public Route(List<Location> locations)
        {
            if (locations == null) throw new ArgumentNullException(nameof(locations));
            if (locations.Count < MinLocationsCount)
                throw new TripException($"Impossible to create route with less than {MinLocationsCount} stops");

            _locations = locations;
        }

        private Route()
        {
        }

        public IReadOnlyCollection<Location> Locations
        {
            get => _locations;
            set => _locations = value.ToList();
        }

        public string LocationString
        {
            get
            {
                IEnumerable<string> listString = Locations.Select(l => $"{l.Latitude}:{l.Longitude}");
                return string.Join(' ', listString);
            }
            set
            {
                var locationStrings = value.Split(' ').ToList();
                Locations = locationStrings.Select(s =>
                {
                    string[] coords = s.Split(':');
                    return new Location(Convert.ToDouble(coords.First()), Convert.ToDouble(coords.Last()));
                }).ToList();
            }
        }

        public Location Start => Locations.FirstOrDefault();
        public Location Finish => Locations.LastOrDefault();
    }
}