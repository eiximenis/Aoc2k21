using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aoc2k21.Quiz3;

public static class Common
{
    public static bool BinaryDigitIsOne(int idx, short value, int numbits)
    {
        return (value & (1 << (numbits - idx))) != 0;
    }

    public static async Task<IEnumerable<short>> GetInputData(string fname) =>
        (await File.ReadAllLinesAsync(fname)).
        Select(l => Convert.ToInt16(l, 2));
}

public static class Quiz3a
{

    public static (int Gamma, int Epsilon) CalculateRates(IEnumerable<short> values, int numbits)
    {
        var gamma = 0;
        var entries = values.Count();
        for (var idx = 1; idx <= numbits; idx++)
        {
            var ones = 0;
            foreach (var value in values)
            {
                ones = Common.BinaryDigitIsOne(idx, value, numbits) ? ones + 1 : ones;
            }
            if (ones > entries / 2)
            {
                gamma = gamma | (1 << numbits - idx);
            }
        }

        return (gamma, (ushort)~gamma & ((1 << numbits) - 1));
    }
}

public static class Quiz3b
{
    public static short GetOxygenGeneratorRating(IEnumerable<short> values, int numbits)
    {
        var oxygen = (short)0;
        var current = values;
        for (var idx = 1; idx <= numbits; idx++)
        {
            var ones = current.Where(v => Common.BinaryDigitIsOne(idx, v, numbits)).ToArray();
            var zeros = current.Where(v => !Common.BinaryDigitIsOne(idx, v, numbits)).ToArray();
            if (ones.Count() >= zeros.Count())
            {
                oxygen |= (short)(1 << numbits - idx);
                current = ones;
            }
            else
            {
                current = zeros;
            }
        }

        return oxygen;
    }

    public static short GetCO2SrubberRating(IEnumerable<short> values, int numbits)
    {
        var current = values;
        for (var idx = 1; idx <= numbits && current.Count() > 1; idx++)
        {
            var ones = current.Where(v => Common.BinaryDigitIsOne(idx, v, numbits)).ToArray();
            var zeros = current.Where(v => !Common.BinaryDigitIsOne(idx, v, numbits)).ToArray();
            current = ones.Count() < zeros.Count() ? ones : zeros;
        }

        return current.Single();
    }
}