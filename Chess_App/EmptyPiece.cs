using ChessGame.Models;

namespace ChessGame.ViewModels
{
    internal class EmptyPiece : Piece
    {
        private ChessPosition chessPosition;

        public EmptyPiece(ChessPosition chessPosition)
        {
            this.chessPosition = chessPosition;
        }
    }
}