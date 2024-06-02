using System;
using System.Drawing;
using static Tetris.Logic.PieceOrientation;

namespace Tetris.Logic
{
    public class Piece
    {
        public EdgePosition EdgePosition { get; set; }
        public Orientation Orientation { get; set; }
        public PieceType PieceType { get; set; }
        public bool[,] Positions { get; set; }
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

        internal static Piece GenerateRandomNewPiece(int mapWidth)
        {
            var random = new Random();
            return new Piece(new EdgePosition(0, mapWidth / 2), (Orientation)random.Next(Enum.GetValues(typeof(Orientation)).Length), (PieceType)random.Next(Enum.GetValues(typeof(PieceType)).Length));
        }

        private static (bool[,], byte) CalculatePiecePositions(PieceType pieceType, Orientation orientation)
        {
            foreach (var (positions, orientations) in PieceOrientations[pieceType])
            {
                if (orientations.Contains(orientation))
                {
                    return (positions, (byte)positions.Length);
                }
            }

            throw new NotImplementedException("The specified orientation is not implemented for the given piece type.");
        }

        internal void MovePieceToSide(DirectionToMove directionToMove)
        {
            if (directionToMove is DirectionToMove.Left)
                this.EdgePosition.y--;
            else if (directionToMove is DirectionToMove.Right)
                this.EdgePosition.y++;
        }

        internal void MovePieceDown()
        {
            this.EdgePosition.x++;
        }

        private static Color[] PieceColors = [Color.Blue, Color.Green, Color.Red, Color.Purple, Color.Brown, Color.Yellow, Color.Pink];
    }
}