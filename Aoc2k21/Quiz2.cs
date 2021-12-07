using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aoc2k21
{
    public static class Quiz2
    {

        public enum Movement
        {
            Forward,
            Up,
            Down
        }

        public static async Task<IEnumerable<(Movement Mov, int Units)>> GetInputData(string fname) =>
            (await File.ReadAllLinesAsync(fname)).
            Select(l => l.Split(' ', StringSplitOptions.RemoveEmptyEntries)).
            Select(t => (Enum.Parse<Movement>(t[0], ignoreCase: true), int.Parse(t[1])));

        public class Submarine
        {

            public int Horizontal { get; private set; }
            public int Depth { get; private set; }

            public Submarine Move(IEnumerable<(Movement Mov, int Units)> movements)
            {
                foreach (var (Mov, Units) in movements)
                {
                    Move(Mov, Units);
                }

                return this;
            }


            public Submarine Move(Movement movement, int units)
            {
                return movement switch
                {
                    Movement.Down => Down(units),
                    Movement.Forward => Forward(units),
                    Movement.Up => Up(units),
                    _ => this
                };
            }

            private Submarine Forward(int x)
            {
                Horizontal += x;
                return this;
            }

            private Submarine Down(int v)
            {
                Depth += v;
                return this;
            }
            private Submarine Up(int v)
            {
                Depth -= v;
                if (Depth < 0) { Depth = 0; }
                return this;
            }
        }
    }

    public static class Quiz2b
    {
        public class AimedSubmarine
        {

            public int Horizontal { get; private set; }
            public int Depth { get; private set; }

            public int Aim { get; private set; }

            public AimedSubmarine Move(IEnumerable<(Quiz2.Movement Mov, int Units)> movements)
            {
                foreach (var (Mov, Units) in movements)
                {
                    Move(Mov, Units);
                }

                return this;
            }


            public AimedSubmarine Move(Quiz2.Movement movement, int units)
            {
                return movement switch
                {
                    Quiz2.Movement.Down => Down(units),
                    Quiz2.Movement.Forward => Forward(units),
                    Quiz2.Movement.Up => Up(units),
                    _ => this
                };
            }

            private AimedSubmarine Forward(int x)
            {
                Horizontal += x;
                Depth += Aim * x;
                return this;
            }

            private AimedSubmarine Down(int v)
            {
                Aim += v;
                return this;
            }
            private AimedSubmarine Up(int v)
            {
                Aim -= v;
                if (Aim < 0) { Aim = 0; }
                return this;
            }
        }
    }
}
