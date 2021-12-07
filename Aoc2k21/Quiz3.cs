using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aoc2k21;

public static class Quiz3
{


    public static async Task<IEnumerable<short>> GetInputData(string fname) =>
    (await File.ReadAllLinesAsync(fname)).
        Select(l => Convert.ToInt16(l, 2));


    public static (int Gamma, int Epsilon) CalculateRates(IEnumerable<short> values, int numbits)
    {
        var gamma = 0;
        var entries = values.Count();
        for (var idx = 1; idx <= numbits; idx++)
        {
            var ones = 0;
            foreach (var value in values)
            {
                ones = BinaryDigitIsOne(idx, value, numbits) ? ones + 1 : ones;
            }
            if (ones > entries / 2)
            {
                gamma = gamma | (1 << numbits - idx);
            }
        }

        return (gamma, (ushort)~gamma & ((1 << numbits) - 1));
    }

    private static bool BinaryDigitIsOne(int idx, short value, int numbits)
    {
        return (value & (1 << (numbits - idx))) != 0;
    }
}