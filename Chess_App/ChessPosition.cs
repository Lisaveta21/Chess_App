namespace ChessGame.ViewModels
{
    
    public class ChessPosition
    {
        public int Row { get; set; }
        public int Column { get; set; }

        public ChessPosition(int row, int column)
        {
            Row = row;
            Column = column;
        }
    }
}