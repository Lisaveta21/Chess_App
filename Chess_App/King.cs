using ChessGame.Models;

namespace ChessGame.ViewModels
{
    internal class King : Piece
    {
        private object black;
        private ChessPosition chessPosition;

        public King(object black, ChessPosition chessPosition)
        {
            this.black = black;
            this.chessPosition = chessPosition;
        }
    }
}