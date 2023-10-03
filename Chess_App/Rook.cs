using ChessGame.Models;

namespace ChessGame.ViewModels
{
    internal class Rook : Piece
    {
        private object black;
        private ChessPosition chessPosition;

        public Rook(object black, ChessPosition chessPosition)
        {
            this.black = black;
            this.chessPosition = chessPosition;
        }
    }
}