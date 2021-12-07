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
            var data = new[] { "100110011100", "001100111101"};
            var fname = Path.GetTempFileName();
            await File.WriteAllLinesAsync(fname, data);

            var read = await Quiz3.GetInputData(fname);
            var expected = data.Select(i => Convert.ToInt16(i, 2));
            read.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void Given_Web_Inputs_Values_Should_Be_Correct()
        {
            var data = new[] { "00100", "11110", "10110", "10111", "10101", "01111", "00111", "11100", "10000", "11001", "00010", "01010" };
            var input = data.Select(i => Convert.ToInt16(i, 2));

            var (gamma, epsilon) = Quiz3.CalculateRates(input, 5);
            gamma.Should().Be(22);
            epsilon.Should().Be(9);
        }

        [Fact]
        public void Given_All_Ones_Gamma_Should_Be_All_Ones_And_Epsilon_Should_Be_Zero()
        {
            var data = new short [] { 0b111, 0b111, 0b111 };
            var (gamma, epsilon) = Quiz3.CalculateRates(data, 3);
            gamma.Should().Be(0b111);
            epsilon.Should().Be(0);
        }
    }
}
