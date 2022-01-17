using System;
using System.Collections.Generic;
using System.Linq;

namespace WhooberCore.Domain.Entities
{
    public class Rating
    {
        private List<Rate> _rates;
        
        public IReadOnlyCollection<Rate> Rates
        {
            get => _rates;
            private init => _rates = value.ToList();
        }

        public double AverageScore => CountScores == 0 ? 0 : SumScores / CountScores;
        private int SumScores { get; set; }
        private int CountScores => _rates.Count;

        public Rating()
        {
            Rates = new List<Rate>();
        }

        public void AddRate(Rate rate)
        {
            if (rate == null) throw new ArgumentNullException(nameof(rate));
            SumScores += rate.RateValue;
            _rates.Add(rate);
        }
    }
}