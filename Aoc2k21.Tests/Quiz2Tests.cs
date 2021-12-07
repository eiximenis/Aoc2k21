using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Movement = Aoc2k21.Quiz2.Submarine.Movement;

namespace Aoc2k21.Tests
{
    public class Quiz2Tests
    {
        [Fact]
        public async Task Given_Input_File_All_Entries_Should_Be_Returned()
        {
            var data = new[] { "forward 10", "down 21", "down 12", "up 2" };
            var fname = Path.GetTempFileName();
            await File.WriteAllLinesAsync(fname, data);

            var read = await Quiz2.GetInputData(fname);
            var expected = new[] { (Movement.Forward, 10), (Movement.Down, 21), (Movement.Down, 12), (Movement.Up, 2) };
            read.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void Given_Some_Moves_Position_Should_Be_Correct()
        {
            var input = new[] { (Movement.Forward, 10), (Movement.Down, 21), (Movement.Down, 12), (Movement.Up, 2) };
            var submarine = new Quiz2.Submarine();
            submarine.Move(input);
            submarine.Depth.Should().Be(21 + 12 - 2);
            submarine.Horizontal.Should().Be(10);
        }

        [Fact]
        public async Task Given_Web_Inputs_Position_Should_Be_Correct()
        {
            var data = new[] { "forward 5", "down 5", "forward 8", "up 3", "down 8", "forward 2" };
            var fname = Path.GetTempFileName();
            await File.WriteAllLinesAsync(fname, data);
            var read = await Quiz2.GetInputData(fname);
            var submarine = new Quiz2.Submarine();
            submarine.Move(read);
            var expected = submarine.Depth * submarine.Horizontal;
            expected.Should().Be(150);
        }
    }
}

