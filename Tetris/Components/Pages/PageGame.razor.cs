using Microsoft.AspNetCore.Components.Web;
using System.Drawing;
using Tetris.Logic;

namespace Tetris.Components.Pages
{
    public partial class PageGame
    {
        private Game game;
        private Color[][] map;
        private IEnumerable<EdgePosition> piece;

        protected override void OnInitialized()
        {
            game = new Game();
            map = game.VisibleMap;
            piece = game.FallingPiece.PositionsCoordinates;
        }

        private void OnKeyDown(KeyboardEventArgs args)
        {
            switch (args.Code)
            {
                case "ArrowDown":
                    game.MovePieceDown();
                    break;
                case "ArrowLeft":
                    game.MovePieceLeft();
                    break;
                case "ArrowRight":
                    game.MovePieceRight();
                    break;
                default:
                    break;
            }
        }
    }
}
