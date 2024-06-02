using System.Drawing;

namespace Tetris.Logic
{
    public class Piece
    {
        public EdgePosition EdgePosition { get; set; }
        public Orientation Orientation { get; set; }
        public PieceType PieceType { get; set; }
        public bool[][] Positions { get; set; }
        public byte Width { get; set; }
        public Color Color { get; set; }

        public Piece(EdgePosition edgePosition, Orientation orientation, PieceType pieceType)
        {
            EdgePosition = edgePosition;
            Orientation = orientation;
            PieceType = pieceType;
            Color = PieceColors[new Random().Next(PieceColors.Length)];
            (Positions, Width) = CalculatePiecePositions(PieceType, Orientation);
        }

        private static (bool[][], byte) CalculatePiecePositions(PieceType pieceType, Orientation orientation)
        {
            switch (pieceType)
            {
                case PieceType.I:
                    if (orientation is Orientation.North or Orientation.South)
                    {
                        bool[][] positions = 
                        [
                            [true],
                            [true],
                            [true],
                            [true],
                        ];
                        return (positions, (byte)positions[0].Length);
                    }
                    else
                    {
                        bool[][] positions =
                        [
                            [true,true,true,true],
                        ];
                        return (positions, (byte)positions[0].Length);
                    }
                    break;
                case PieceType.J:
                    break;
                case PieceType.L:
                    break;
                case PieceType.O:
                    break;
                case PieceType.S:
                    break;
                case PieceType.T:
                    break;
                case PieceType.Z:
                    break;
                default:
                    throw new NotImplementedException();
            }


            return (Array.Empty<bool[]>(), 0);
        }

        private static Color[] PieceColors = [Color.Blue, Color.Green, Color.Red, Color.Purple, Color.Brown, Color.Yellow, Color.Pink];
    }
}
