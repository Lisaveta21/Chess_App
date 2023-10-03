using ChessGame.Models;

namespace ChessGame.ViewModels
{
    internal class Bishop : Piece
    {
        private object black;
        private ChessPosition chessPosition;

        public Bishop(object black, ChessPosition chessPosition)
        {
            this.black = black;
            this.chessPosition = chessPosition;
        }
    }
}