using FluentAssertions;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Aoc2k21.Tests;

public class QuizTests
{


    [Fact]
    public async Task Given_Input_File_All_Entries_Should_Be_Returned()
    {
        var data = new[] { "100", "200", "50", "300" };
        var fname = Path.GetTempFileName();
        await File.WriteAllLinesAsync(fname, data);

        var read = await Quiz1.GetInputData(fname);
        read.Should().BeEquivalentTo(data.Select(d => int.Parse(d, CultureInfo.InvariantCulture)));
    }

    public class V1
    {

        [Fact]
        public void Given_No_Increases_Zero_Should_Be_Returned()
        {
            var inputs = new[] { 100, 90, 80, 70, 60, 50, 40, 30, 20, 10 };
            var result = Quiz1.GetDepthIncreases(inputs);
            result.Should().Be(0);
        }

        [Fact]
        public void Given_Example_Inputs_Example_Answer_Should_Be_Returned()
        {
            var inputs = new[] { 199, 200, 208, 210, 200, 207, 240, 269, 260, 263 };
            var result = Quiz1.GetDepthIncreases(inputs);
            result.Should().Be(7);
        }

        [Fact]
        public void Given_Single_Depth_A_Zero_Is_Returned()
        {
            var inputs = new[] { 42 };
            var result = Quiz1.GetDepthIncreases(inputs);
            result.Should().Be(0);
        }
    }

    public class V2
    {
        [Fact]
        public void Given_No_Increases_Zero_Should_Be_Returned()
        {
            var inputs = new[] { 100, 90, 80, 70, 60, 50, 40, 30, 20, 10 };
            var result = Quiz1.GetDepthIncreases_V2(inputs);
            result.Should().Be(0);
        }

        [Fact]
        public void Given_Example_Inputs_Example_Answer_Should_Be_Returned()
        {
            var inputs = new[] { 199, 200, 208, 210, 200, 207, 240, 269, 260, 263 };
            var result = Quiz1.GetDepthIncreases_V2(inputs);
            result.Should().Be(7);
        }

        [Fact]
        public void Given_Single_Depth_A_Zero_Is_Returned()
        {
            var inputs = new[] { 42 };
            var result = Quiz1.GetDepthIncreases_V2(inputs);
            result.Should().Be(0);
        }
    }
}

public class Quiz1bTests
{

    [Fact]
    public void Given_No_Increases_Zero_Should_Be_Returned()
    {
        var inputs = new[] { 100, 90, 80, 70, 60, 50, 40, 30, 20, 10 };
        var result = Quiz1b.GetDepthIncreasesByTriples(inputs);
        result.Should().Be(0);
    }

    [Fact]
    public void Given_Example_Inputs_Example_Answer_Should_Be_Returned()
    {
        var inputs = new[] { 199, 200, 208, 210, 200, 207, 240, 269, 260, 263 };
        var result = Quiz1b.GetDepthIncreasesByTriples(inputs);
        result.Should().Be(5);
    }

}