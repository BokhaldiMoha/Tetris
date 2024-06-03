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
        public Color Color { get; set; }
        public IEnumerable<EdgePosition> PositionsCoordinates
        {
            get
            {
                for (int i = 0; i < Positions.GetLength(0); i++)
                {
                    for (int j = 0; j < Positions.GetLength(1); j++)
                    {
                        if (Positions[i, j])
                            yield return new EdgePosition(EdgePosition.X + i, EdgePosition.Y + j);
                    }
                }
            }
        }

        public Piece(EdgePosition edgePosition, Orientation orientation, PieceType pieceType)
        {
            EdgePosition = edgePosition;
            Orientation = orientation;
            PieceType = pieceType;
            Color = PieceColors[new Random().Next(PieceColors.Length)];
            Positions = CalculatePiecePositions(PieceType, Orientation);
        }

        internal static Piece GenerateRandomNewPiece(int mapWidth)
        {
            var random = new Random();
            return new Piece(new EdgePosition(0, mapWidth / 2), (Orientation)random.Next(Enum.GetValues(typeof(Orientation)).Length), (PieceType)random.Next(Enum.GetValues(typeof(PieceType)).Length));
        }

        private static bool[,] CalculatePiecePositions(PieceType pieceType, Orientation orientation)
        {
            foreach (var (positions, orientations) in PieceOrientations[pieceType])
            {
                if (orientations.Contains(orientation))
                {
                    return positions;
                }
            }

            throw new NotImplementedException("The specified orientation is not implemented for the given piece type.");
        }

        internal void MovePieceToSide(DirectionToMove directionToMove)
        {
            if (directionToMove is DirectionToMove.Left)
                this.EdgePosition.Y--;
            else if (directionToMove is DirectionToMove.Right)
                this.EdgePosition.Y++;
        }

        internal void MovePieceDown()
        {
            this.EdgePosition.X++;
        }

        private static Color[] PieceColors = [Color.Blue, Color.Green, Color.Red, Color.Purple, Color.Brown, Color.Yellow, Color.Pink];
    }
}