namespace Aoc2k21;
public static class Quiz1
{

    public static async Task<IEnumerable<int>> GetInputData(string fname) =>
        (await File.ReadAllLinesAsync(fname)).
            Select(l => int.TryParse(l, out var r) ? r : (int?)null)
            .Where(v => v.HasValue)
            .Select(v => v!.Value);

    public static int GetDepthIncreases(IEnumerable<int> depths)
    {
        if (depths.Count() <= 1) return 0;

        var increases = 0;
        var current = depths.First();

        foreach (var depth in depths.Skip(1))
        {
            if (depth > current) { increases++; }
            current = depth;
        }

        return increases;
    }

    public static int GetDepthIncreases_V2(IEnumerable<int> depths)
    {
        return depths.Zip(depths.Skip(1)).Count(p => p.Item2 > p.Item1);
    }

    public static IEnumerable<(T, T)> ToPairs<T>(this IEnumerable<T> input)
    {
        if (input.Count() <= 1) { return Enumerable.Empty<(T, T)>(); }
        return input.Zip(input.Skip(1));
    }
}
