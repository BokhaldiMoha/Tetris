using Microsoft.AspNetCore.Components.Web;
using System.Drawing;
using Tetris.Logic;
using System.Timers;

namespace Tetris.Components.Pages
{
    public partial class PageGame
    {
        private Game game;
        private Color[][] map;
        private IEnumerable<EdgePosition> piece;
        private System.Timers.Timer timer;

        protected override void OnAfterRender(bool firstRender)
        {
            if (firstRender)
            {
                game = new Game();
                map = game.VisibleMap;
                piece = game.FallingPiece.PositionsCoordinates;

                timer = new System.Timers.Timer(500);
                timer.Elapsed += OnTimedEvent;
                timer.AutoReset = true;
                timer.Enabled = true;

                StateHasChanged();
            }
        }

        private void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            InvokeAsync(() =>
            {
                game.MovePieceDown();
                StateHasChanged();
            });
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
                case "Space":
                    game.FallingPiece.SpinPiece();
                    break;
                default:
                    break;
            }
        }
    }
}
