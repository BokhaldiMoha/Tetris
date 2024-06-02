namespace Tetris.Logic
{
    internal static class PieceOrientation
    {
        public static readonly Dictionary<PieceType, (bool[,], HashSet<Orientation>)[]> PieceOrientations = new()
        {
            {
                PieceType.I, new[]
                {
                    (
                        new bool[,]
                        {
                            { true },
                            { true },
                            { true },
                            { true }
                        },
                        new HashSet<Orientation> { Orientation.North, Orientation.South }
                    ),
                    (
                        new bool[,]
                        {
                            { true, true, true, true }
                        },
                        new HashSet<Orientation> { Orientation.East, Orientation.West }
                    )
                }
            },
            {
                PieceType.J, new[]
                {
                    (
                        new bool[,]
                        {
                            { true, false, false },
                            { true, true, true }
                        },
                        new HashSet<Orientation> { Orientation.North }
                    ),
                    (
                        new bool[,]
                        {
                            { true, true },
                            { true, false },
                            { true, false }
                        },
                        new HashSet<Orientation> { Orientation.East }
                    ),
                    (
                        new bool[,]
                        {
                            { true, true, true },
                            { false, false, true }
                        },
                        new HashSet<Orientation> { Orientation.South }
                    ),
                    (
                        new bool[,]
                        {
                            { false, true },
                            { false, true },
                            { true, true }
                        },
                        new HashSet<Orientation> { Orientation.West }
                    )
                }
            },
            {
                PieceType.L, new[]
                {
                    (
                        new bool[,]
                        {
                            { false, false, true },
                            { true, true, true }
                        },
                        new HashSet<Orientation> { Orientation.North }
                    ),
                    (
                        new bool[,]
                        {
                            { true, false },
                            { true, false },
                            { true, true }
                        },
                        new HashSet<Orientation> { Orientation.East }
                    ),
                    (
                        new bool[,]
                        {
                            { true, true, true },
                            { true, false, false }
                        },
                        new HashSet<Orientation> { Orientation.South }
                    ),
                    (
                        new bool[,]
                        {
                            { true, true },
                            { false, true },
                            { false, true }
                        },
                        new HashSet<Orientation> { Orientation.West }
                    )
                }
            },
            {
                PieceType.O, new[]
                {
                    (
                        new bool[,]
                        {
                            { true, true },
                            { true, true }
                        },
                        new HashSet<Orientation> { Orientation.North, Orientation.East, Orientation.South, Orientation.West }
                    )
                }
            },
            {
                PieceType.S, new[]
                {
                    (
                        new bool[,]
                        {
                            { false, true, true },
                            { true, true, false }
                        },
                        new HashSet<Orientation> { Orientation.North, Orientation.South }
                    ),
                    (
                        new bool[,]
                        {
                            { true, false },
                            { true, true },
                            { false, true }
                        },
                        new HashSet<Orientation> { Orientation.East, Orientation.West }
                    )
                }
            },
            {
                PieceType.T, new[]
                {
                    (
                        new bool[,]
                        {
                            { false, true, false },
                            { true, true, true }
                        },
                        new HashSet<Orientation> { Orientation.North }
                    ),
                    (
                        new bool[,]
                        {
                            { true, false },
                            { true, true },
                            { true, false }
                        },
                        new HashSet<Orientation> { Orientation.East }
                    ),
                    (
                        new bool[,]
                        {
                            { true, true, true },
                            { false, true, false }
                        },
                        new HashSet<Orientation> { Orientation.South }
                    ),
                    (
                        new bool[,]
                        {
                            { false, true },
                            { true, true },
                            { false, true }
                        },
                        new HashSet<Orientation> { Orientation.West }
                    )
                }
            },
            {
                PieceType.Z, new[]
                {
                    (
                        new bool[,]
                        {
                            { true, true, false },
                            { false, true, true }
                        },
                        new HashSet<Orientation> { Orientation.North, Orientation.South }
                    ),
                    (
                        new bool[,]
                        {
                            { false, true },
                            { true, true },
                            { true, false }
                        },
                        new HashSet<Orientation> { Orientation.East, Orientation.West }
                    )
                }
            }
        };

    }
}
