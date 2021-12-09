using Aoc2k21.Quiz3;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Aoc2k21.Tests
{
    public class Quiz3Tests
    {
        [Fact]
        public async Task Given_Input_File_All_Entries_Should_Be_Returned()
        {
            var data = new[] { "100110011100", "001100111101" };
            var fname = Path.GetTempFileName();
            await File.WriteAllLinesAsync(fname, data);

            var read = await Quiz3.Common.GetInputData(fname);
            var expected = data.Select(i => Convert.ToInt16(i, 2));
            read.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void Given_Web_Inputs_Values_Should_Be_Correct()
        {
            var data = new[] { "00100", "11110", "10110", "10111", "10101", "01111", "00111", "11100", "10000", "11001", "00010", "01010" };
            var input = data.Select(i => Convert.ToInt16(i, 2));

            var (gamma, epsilon) = Quiz3a.CalculateRates(input, 5);
            gamma.Should().Be(22);
            epsilon.Should().Be(9);
        }

        [Fact]
        public void Given_All_Ones_Gamma_Should_Be_All_Ones_And_Epsilon_Should_Be_Zero()
        {
            var data = new short[] { 0b111, 0b111, 0b111 };
            var (gamma, epsilon) = Quiz3a.CalculateRates(data, 3);
            gamma.Should().Be(0b111);
            epsilon.Should().Be(0);
        }
    }

    public class Quiz3bTests
    {
        [Fact]
        public void Given_A_Single_Number_This_Number_Is_The_Oxygen_Generator_Rate()
        {
            var value = (short)0b10111;
            var data = new[] { value };
            var oxygen = Quiz3b.GetOxygenGeneratorRating(data, 5);
            oxygen.Should().Be(value);
        }

        [Fact]
        public void Given_Web_Inputs_Oxygen_Generator_Rate_Is_Correct()
        {
            var data = new[] { "00100", "11110", "10110", "10111", "10101", "01111", "00111", "11100", "10000", "11001", "00010", "01010" };
            var input = data.Select(i => Convert.ToInt16(i, 2));
            var oxygen = Quiz3b.GetOxygenGeneratorRating(input, 5);
            var expected = (short)23;
            oxygen.Should().Be(expected);
        }

        [Fact]
        public void Given_A_Single_Number_This_Number_Is_The_CO2_Scrubber_Rate()
        {
            var value = (short)0b10111;
            var data = new[] { value };
            var oxygen = Quiz3b.GetOxygenGeneratorRating(data, 5);
            oxygen.Should().Be(value);
        }

        [Fact]
        public void Given_Web_Inputs_CO2_Scrubber_Rate_Is_Correct()
        {
            var data = new[] { "00100", "11110", "10110", "10111", "10101", "01111", "00111", "11100", "10000", "11001", "00010", "01010" };
            var input = data.Select(i => Convert.ToInt16(i, 2));
            var co2 = Quiz3b.GetCO2SrubberRating(input, 5);
            var expected = (short)10;
            co2.Should().Be(expected);
        }

    }

}