namespace Videogame.Model;

public struct Range
{
    public int From { get; }
    public int To { get; }

    public Range(int from, int to)
    {/*
        if (from <= 0 || to <= 0)
            throw new ArgumentOutOfRangeException("Range edges must be greater than 0");

        if (from > 20 || to > 20)
            throw new ArgumentOutOfRangeException("Range edges must be less or equals than 20");
            */

        if (to < from)
            throw new ArgumentException("Low edge of range must be lesser than high");

        From = from;
        To = to;
    }
}