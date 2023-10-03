using ChessGame.Models;

namespace ChessGame.ViewModels
{
    internal class Pawn : Piece
    {
        private object black;
        private ChessPosition chessPosition;

        public Pawn(object black, ChessPosition chessPosition)
        {
            this.black = black;
            this.chessPosition = chessPosition;
        }
    }
}