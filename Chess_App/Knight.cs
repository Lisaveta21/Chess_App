using ChessGame.Models;

namespace ChessGame.ViewModels
{
    internal class Knight : Piece
    {
        private object black;
        private ChessPosition chessPosition;

        public Knight(object black, ChessPosition chessPosition)
        {
            this.black = black;
            this.chessPosition = chessPosition;
        }
    }
}