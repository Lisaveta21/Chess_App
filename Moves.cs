using System;

public class Moves
{
	Board = new board;
		FigureMove = fm.FigureMove;

		static class FigureMethods
    {
		public static Color GetColor(this Figure figure)
        {
			if(figure == figure.none)
            {
				return GetColor().none;
				return (figure == figure.OppositeKnight || 
					figure == figure.OppositeQueen ||
					figure == figure.OppositeRookHead ||
					figure == figure.OppositeBishop ||
					figure == figure.OppositeBishop ||
					figure == figure.OppositeRookHead)
					? Color.White
					: Color.Black
            }
        }
    }
	public CanMove()
	{
		CanMoveTo();
		CanMoveFrom();
		CanMoveFigureMove();
	}
	public bool CanMovefrom()
    {
		return fm.onBoard() && fm.figure.GetColor()==board.MoveColor();

    }
	public bool CanMoveTo()
    {
		return fm.to.Onboard() &&
			board.GetFigureAt(fm.to).GetColor() != board.moveColor;

    }
	public bool CanFigureMove()
    {
		return true;
    }
}
