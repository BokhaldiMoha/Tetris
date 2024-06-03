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
                return Map.Skip(4).ToArray();
            }
        }

        private static Color BackGroundColor = Color.Black;

        private int MapHeight = 36;
        private int MapWidth = 10;

        public Game()
        {
            FallingPiece = Piece.GenerateRandomNewPiece(MapWidth);
            Map = new Color[MapHeight + 4][];
            for (int i = 0; i < Map.Length; i++)
            {
                Map[i] = new Color[MapWidth];
                for (int j = 0; j < MapWidth; j++)
                {
                    Map[i][j] = BackGroundColor;
                }
            }
        }

        public void MovePieceDown()
        {
            if (CheckIfPieceIsOnTheGround())
            {
                TurnPieceIntoGround();
                FallingPiece = Piece.GenerateRandomNewPiece(MapWidth);
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
                    int xToCheck = FallingPiece.EdgePosition.X;
                    int yToCheck = FallingPiece.EdgePosition.Y + j;

                    if (xToCheck + 1 >= Map.Length || Map[xToCheck][yToCheck] != BackGroundColor)
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
            if (FallingPiece.Positions.GetLength(1) + FallingPiece.EdgePosition.Y < MapWidth)
                FallingPiece.MovePieceToSide(DirectionToMove.Right);
        }

        public void MovePieceLeft()
        {
            if (FallingPiece.EdgePosition.Y > 0)
                FallingPiece.MovePieceToSide(DirectionToMove.Left);
        }
    }
}
