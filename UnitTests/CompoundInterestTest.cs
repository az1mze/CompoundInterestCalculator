using Calculator.Models;
using System;
using Xunit;

namespace UnitTests
{
    public class CompoundInterestTest
    {
        [Fact]
        public void P1000T12I5Y10Results1647dot01()
        {
            CompoundInterest ci = new CompoundInterest()
            {
                Principal = 1000,
                TimesCompounded = 12,
                InterestRate = 5,
                Years = 10
            };


            var expected = 1647.01;
            var actual = Math.Round(ci.CompoundInterestCalculator(),2);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void P0T12I5Y10Results0()
        {
            CompoundInterest ci = new CompoundInterest()
            {
                Principal = 0,
                TimesCompounded = 12,
                InterestRate = 5,
                Years = 10
            };


            var expected = 0.00;
            var actual = Math.Round(ci.CompoundInterestCalculator(), 2);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void P1000T12I0Y10Results1000()
        {
            CompoundInterest ci = new CompoundInterest()
            {
                Principal = 1000,
                TimesCompounded = 12,
                InterestRate = 0,
                Years = 10
            };


            var expected = 1000.00;
            var actual = Math.Round(ci.CompoundInterestCalculator(), 2);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TimesCompoundedCannotBeNegative()
        {
            CompoundInterest ci = new CompoundInterest();

            Exception ex = Assert.Throws<Exception>(
                () => ci.TimesCompounded = -10
            );

            Assert.Equal("Times interest is compounded per year cannot be negative.", ex.Message);
        }

        [Fact]
        public void TimesCompoundedCannotBeZero()
        {
            CompoundInterest ci = new CompoundInterest();

            Exception ex = Assert.Throws<Exception>(
                () => ci.TimesCompounded = 0
            );

            Assert.Equal("Times interest is compounded per year cannot be zero.", ex.Message);
        }

        [Fact]
        public void PrincipalAmountCannotBeNegative()
        {
            CompoundInterest ci = new CompoundInterest();

            Exception ex = Assert.Throws<Exception>(
                () => ci.Principal = -10
            );

            Assert.Equal("Principal amount cannot be negative.", ex.Message);
        }

        [Fact]
        public void InterestRateCannotBeNegative()
        {
            CompoundInterest ci = new CompoundInterest();

            Exception ex = Assert.Throws<Exception>(
                () => ci.InterestRate = -10
            );

            Assert.Equal("Interest rate cannot be negative.", ex.Message);
        }

        [Fact]
        public void YearsCannotBeNegative()
        {
            CompoundInterest ci = new CompoundInterest();

            Exception ex = Assert.Throws<Exception>(
                () => ci.Years = -10
            );

            Assert.Equal("Years cannot be negative.", ex.Message);
        }

    }
}
