using System;

public class Board
{
	public string fen { get; private set; }
	Figure[,] figures;
	public Color{ get; private set; }
	public int moveNumber { get; private set; }

public Board (string fen)
{
	this.fen = fen;
	figures = new Figures;
	
}
}
