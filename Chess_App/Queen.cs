using ChessGame.Models;

namespace ChessGame.ViewModels
{
    internal class Queen : Piece
    {
        private object black;
        private ChessPosition chessPosition;

        public Queen(object black, ChessPosition chessPosition)
        {
            this.black = black;
            this.chessPosition = chessPosition;
        }
    }
}