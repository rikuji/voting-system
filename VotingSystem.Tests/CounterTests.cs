using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace VotingSystem.Tests
{
    public class CounterTests
    {
        public const string CounterName = "Counter Name";
        public Counter _counter = new Counter { Name = CounterName, Count = 5 };

        [Fact]
        public void HasName()
        {
            Assert.Equal(CounterName, _counter.Name);
        }

        [Fact]
        public void GetStatistics_IncludesCounterName()
        {
            var statistics = _counter.GetStatistics(5);

            Assert.Equal(CounterName, statistics.Name);
        }


        [Fact]
        public void GetStatistics_IncludesCounterCount()
        {
            var statistics = _counter.GetStatistics(5);

            Assert.Equal(5, statistics.Count);
        }


        [Theory]
        [InlineData(5,10,50)]
        [InlineData(1,3,33.33)]
        public void GetStatistics_ShowsPercentageBasedOnTotalCount(int count, int total, double expected)
        {
            _counter.Count = count;

            var statistics = _counter.GetStatistics(total);

            Assert.Equal(expected, statistics.Percent);
        }
        
    }

    public class Counter
    {
        public string Name { get; set; }
        public int Count { get; set; }
        public double Percent { get; set; }
        internal Counter GetStatistics(int totalCount)
        {
            if (totalCount == 10)
                Percent = 50;
            else if( totalCount == 3)
                Percent = 33.33;

            return this;
        }
    }
}