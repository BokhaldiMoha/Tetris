using System.Drawing;

namespace Tetris.Logic
{
    public class Game
    {
        public Piece FallingPiece { get; set; }
        private Color[][] Map;
        public Color[][] VisibleMap
        {
            get
            {
                return VisibleMap.Skip(4).ToArray();
            }
        }

        private static int MinMapWidth = 10;
        private static int MaxMapWidth = 30;

        private static Color BackGroundColor = Color.Black;

        public Game(int mapWidth)
        {
            if (mapWidth < MinMapWidth || mapWidth > MaxMapWidth)
            {
                throw new ArgumentException($"Map width cannot be lower than {MinMapWidth} or larger than {MaxMapWidth}.");
            }

            FallingPiece = Piece.GenerateRandomNewPiece(mapWidth);
            Map = new Color[50][];
            foreach (var rowMap in Map)
            {
                for (int i = 0; i < mapWidth; i++)
                {
                    rowMap[i] = BackGroundColor;
                }
            }
        }

        public void MovePieceDown()
        {
            if (CheckIfPieceIsOnTheGround())
            {
                TurnPieceIntoGround();
                FallingPiece = Piece.GenerateRandomNewPiece(VisibleMap.Length);
                return;
            }

            FallingPiece.MovePieceDown();
        }

        private bool CheckIfPieceIsOnTheGround()
        {
            for (int i = 0; i < FallingPiece.Positions.GetLength(0); i++)
            {
                for (int j = 0; j < FallingPiece.Positions.GetLength(1); j++)
                {
                    int xToCheck = FallingPiece.EdgePosition.X + i;
                    int yToCheck = FallingPiece.EdgePosition.Y + j;

                    if (Map[xToCheck + 1][yToCheck] != BackGroundColor)
                        return true;
                }
            }

            return false;
        }

        private void TurnPieceIntoGround()
        {
            for (int i = 0; i < FallingPiece.Positions.GetLength(0); i++)
            {
                for (int j = 0; j < FallingPiece.Positions.GetLength(1); j++)
                {
                    if (FallingPiece.Positions[i, j])
                    {
                        int xToTransform = FallingPiece.EdgePosition.X + i;
                        int yToTransform = FallingPiece.EdgePosition.Y + j;

                        Map[xToTransform][yToTransform] = FallingPiece.Color;
                    }
                }
            }
        }

        public void MovePieceRight()
        {
            if (FallingPiece.Width + FallingPiece.EdgePosition.Y < Map.Length)
                FallingPiece.MovePieceToSide(DirectionToMove.Right);
        }

        public void MovePieceLeft()
        {
            if (FallingPiece.EdgePosition.Y >= 0)
                FallingPiece.MovePieceToSide(DirectionToMove.Left);
        }
    }
}
