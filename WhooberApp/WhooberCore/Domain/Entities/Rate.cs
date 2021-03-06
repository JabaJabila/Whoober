using System;
using WhooberCore.Domain.Exceptions;

namespace WhooberCore.Domain.Entities
{
    public class Rate
    {
        public Rate(int rateValue, string comment)
        {
            if (rateValue is > 5 or < 1) throw new RatingException("Rate value must be in range 1..5");
            RateValue = rateValue;
            Comment = comment ?? throw new ArgumentNullException(nameof(comment));
        }

        private Rate()
        {
        }

        public Guid Id { get; private init; }
        public int RateValue { get; private init; }
        public string Comment { get; private init; }
        public Rating FromRating { get; set; }
    }
}