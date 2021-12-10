using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aoc2k21.Quiz4;


static class SpanExtensions
{
    public static bool All<T>(this Span<T> span, Func<T, bool> selector)
    {
        var all = true;
        foreach (var item in span)
        {
            all = all && selector(item);
            if (!all) return false;
        }

        return true;
    }
}

public class QuizData
{

    private readonly List<Board> _boards;
    private readonly List<int> _inputs;
    public IEnumerable<Board> Boards { get => _boards; }
    public IEnumerable<int> Inputs { get => _inputs; }

    public QuizData()
    {
        _boards = new List<Board>();
        _inputs = new List<int>();
    }

    public async Task Read(Stream stream)
    {
        using var reader = new StreamReader(stream);
        var inputs = await reader.ReadLineAsync();
        _inputs.AddRange(inputs!.Split(',').Select(s => int.Parse(s)));
        var board = (Board?)null;
        do
        {
            board = await ReadBoard(reader);
            if (board != null)
            {
                _boards.Add(board);
            }
        } while (board is not null);
    }

    private async Task<Board?> ReadBoard(StreamReader reader)
    {
        
        var line = "";
        var board = new Board();
        var row = 0;
        do
        {
            line = await reader.ReadLineAsync();
            if (!String.IsNullOrWhiteSpace(line))
            {
                var numbers = line.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(i => int.Parse(i)).ToArray();
                board.AddInputData(row, numbers);
                row++;
            }
            if (row == 5)
            {
                return board;
            }
        } while (line is not null);

        return null;
    }
}

public class Board
{
    private const int BOARDSIZE = 5;
    readonly record struct BoardItem(int value, bool marked);
    private readonly BoardItem[] _data;

    public Board()
    {
        _data = new BoardItem[BOARDSIZE * BOARDSIZE];
    }

    public bool Bingo { get; private set; }

    public void AddInputData(int row, int[] rowData)
    {
        if (rowData.Length != BOARDSIZE)
        {
            throw new InvalidOperationException("Row data must have 5 elements");
        }

        Array.Copy(rowData.Select(x => new BoardItem(x, false)).ToArray(), 0, _data, row * BOARDSIZE, BOARDSIZE);
    }

    public bool MarkNumber(int number)
    {
        var found = false;
        var idx = Array.IndexOf(_data, new BoardItem(number, false));
        if (idx != -1)
        {
            _data[idx] = new BoardItem(number, true);
            found = true;
        }

        Bingo = CheckBingo();
        return found;
    }

    private bool CheckBingo()
    {
        var bingo = false;

        for (var row = 0; row < BOARDSIZE; row++)
        {
            bingo = bingo || CheckRow(row);
            if (bingo) return true;
        }

        for (var col = 0; col < BOARDSIZE; col++)
        {
            bingo = bingo || CheckColumn(col);
            if (bingo) return true;
        }

        return false;
    }

    private bool CheckRow(int row)
    {
        var startIdx = row * BOARDSIZE;
        return _data.AsSpan(startIdx, BOARDSIZE).All(x => x.marked == true);
    }

    private bool CheckColumn(int col)
    {
        var indexes = Enumerable.Range(0, BOARDSIZE).Select(i => col+ (i * BOARDSIZE));
        return indexes.Select(idx => _data[idx].marked).All(marked => marked == true);
    }

    public IEnumerable<int> MarkedNumbers { get => _data.Where(x => x.marked == true).Select(x => x.value); }
    public IEnumerable<int> UnmarkedNumbers { get => _data.Where(x => x.marked == false).Select(x => x.value); }
}