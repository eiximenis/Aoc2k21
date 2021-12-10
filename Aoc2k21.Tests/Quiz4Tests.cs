using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Aoc2k21.Quiz4;
using FluentAssertions;
using Xunit;

namespace Aoc2k21.Tests
{
    public class Quiz4Tests
    {

        private Board CreateSampleBoard()
        {
            var board = new Board();
            board.AddInputData(0, new[] { 1, 2, 3, 4, 5 });
            board.AddInputData(1, new[] { 6, 7, 8, 9, 10 });
            board.AddInputData(2, new[] { 11, 12, 13, 14, 15 });
            board.AddInputData(3, new[] { 16, 17, 18, 19, 20 });
            board.AddInputData(4, new[] { 21, 22, 23, 24, 25 });
            return board;
        }

        [Fact]
        public void Given_A_Number_That_Exists_In_A_Board_This_Number_Should_Be_Marked()
        {
            var board = CreateSampleBoard();
            board.MarkNumber(5).Should().BeTrue();
            board.MarkedNumbers.Should().Contain(5);
        }

        [Fact]
        public void Given_A_Number_That_Dont_Exists_In_A_Board_This_Number_Should_Not_Be_Marked()
        {
            var board = CreateSampleBoard();
            board.MarkNumber(50).Should().BeFalse();
            board.MarkedNumbers.Should().HaveCount(0);
        }

        [Fact]
        public void Given_A_Row_Marked_Should_Have_Bingo()
        {
            var board = CreateSampleBoard();
            board.MarkNumber(6);
            board.MarkNumber(7);
            board.MarkNumber(8);
            board.MarkNumber(9);
            board.MarkNumber(10);
            board.Bingo.Should().BeTrue();
        }

        [Fact]
        public void Given_A_Column_Marked_Should_Have_Bingo()
        {
            var board = CreateSampleBoard();
            board.MarkNumber(2);
            board.MarkNumber(7);
            board.MarkNumber(12);
            board.MarkNumber(17);
            board.MarkNumber(22);
            board.Bingo.Should().BeTrue();
        }

        [Fact]
        public async Task Foo()
        {
            var quiz = new QuizData();
            using var fs = new FileStream(@"D:\input.txt", FileMode.Open, FileAccess.Read);
            await quiz.Read(fs);
            var answer = 0;
            foreach (var input in quiz.Inputs)
            {
                foreach (var board in quiz.Boards) { board.MarkNumber(input); }
                var winner = quiz.Boards.FirstOrDefault(b => b.Bingo);
                if (winner != null)
                {
                    answer = winner.UnmarkedNumbers.Sum() * input;
                    break;
                }
            }

            answer.Should().Be(42);
        }

    }
}
