using ChessGame.Models;
using GalaSoft.MvvmLight.Command;
using Microsoft.Build.Tasks;
using Microsoft.TeamFoundation.Server;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using static System.Net.Mime.MediaTypeNames;

namespace ChessGame.ViewModels
{
    public class ChessboardViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Models.Piece> _chessboard;

        public ObservableCollection<Models.Piece> Chessboard
        {
            get { return _chessboard; }
            set
            {
                _chessboard = value;
                OnPropertyChanged("Chessboard");
            }
        }

        internal void StartGame()
        {
            throw new NotImplementedException();
        }

        private void OnPropertyChanged(string v)
        {
            throw new NotImplementedException();
        }

        public ICommand MovePieceCommand { get; private set; }

        public ChessboardViewModel()
        {
            // Initialize chessboard and pieces
            InitializeChessboard();

            // Initialize command
            MovePieceCommand = new RelayCommand<Move>(MovePiece);
        }

        private void InitializeChessboard()
        {
            Chessboard = new ObservableCollection<Piece>();

            // Add code to initialize the chessboard with pieces
            // ...
        }

        private void MovePiece(Move move) { }
        private System.Drawing.Image selectedPiece;
        private Point mousePosition;

        public event PropertyChangedEventHandler PropertyChanged;



        private void Image_MouseDown(object sender, MouseButtonEventArgs e)
        {
            selectedPiece = sender as System.Net.Mime.MediaTypeNames.Image;
            mousePosition = e.GetPosition((System.Windows.IInputElement)Chessboard);
            Canvas.SetZIndex(selectedPiece, 1);
            Chessboard.MouseMove += Image_MouseMove;
            Chessboard.MouseUp += Image_MouseUp;
        }


        private void Image_MouseMove(object sender, MouseEventArgs e)
        {
            if (selectedPiece != null)
            {
                double x = e.GetPosition((System.Windows.IInputElement)Chessboard).X - mousePosition.X + Canvas.GetLeft(selectedPiece);
                double y = e.GetPosition((System.Windows.IInputElement)Chessboard).Y - mousePosition.Y + Canvas.GetTop(selectedPiece);
                Canvas.SetLeft(selectedPiece, x);
                Canvas.SetTop(selectedPiece, y);
            }
        }

        private void Image_MouseUp(object sender, MouseButtonEventArgs e)
        {
            selectedPiece = null;
            Chessboard.MouseMove -= Image_MouseMove;
            Chessboard.MouseUp -= Image_MouseUp;
        }
    
               
    
    }

        

        public event PropertyChangedEventHandler PropertyChanged;

    protected virtual void OnPropertyChanged(string propertyName)
        {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    
    RelayCommand<Move>


    private void InitializeChessboard(ObservableCollection<Piece> Chessboard, object PieceColor)
    {
        Chessboard = new ObservableCollection<Piece>();

        // Добавить 8 пешек для черных
        for (int i = 0; i < 8; i++)
        {
            Chessboard.Add(new Pawn(PieceColor.Black, new ChessPosition(i, 6)));
        }

        // Добавить 8 пешек для белых
        for (int i = 0; i < 8; i++)
        {
            Chessboard.Add(new Pawn(PieceColor.White, new ChessPosition(i, 1)));
        }

        // Добавить остальные фигуры для черных
        Chessboard.Add(new Rook(PieceColor.Black, new ChessPosition(0, 7)));
        Chessboard.Add(new Knight(PieceColor.Black, new ChessPosition(1, 7)));
        Chessboard.Add(new Bishop(PieceColor.Black, new ChessPosition(2, 7)));
        Chessboard.Add(new Queen(PieceColor.Black, new ChessPosition(3, 7)));
        Chessboard.Add(new King(PieceColor.Black, new ChessPosition(4, 7)));
        Chessboard.Add(new Bishop(PieceColor.Black, new ChessPosition(5, 7)));
        Chessboard.Add(new Knight(PieceColor.Black, new ChessPosition(6, 7)));
        Chessboard.Add(new Rook(PieceColor.Black, new ChessPosition(7, 7)));

        // Добавить остальные фигуры для белых
        Chessboard.Add(new Rook(PieceColor.White, new ChessPosition(0, 0)));
        Chessboard.Add(new Knight(PieceColor.White, new ChessPosition(1, 0)));
        Chessboard.Add(new Bishop(PieceColor.White, new ChessPosition(2, 0)));
        Chessboard.Add(new Queen(PieceColor.White, new ChessPosition(3, 0)));
        Chessboard.Add(new King(PieceColor.White, new ChessPosition(4, 0)));
        Chessboard.Add(new Bishop(PieceColor.White, new ChessPosition(5, 0)));
        Chessboard.Add(new Knight(PieceColor.White, new ChessPosition(6, 0)));
        Chessboard.Add(new Rook(PieceColor.White, new ChessPosition(7, 0)));

        // Добавить остальные клетки доски
        for (int row = 2; row < 6; row++)
        {
            for (int col = 0; col < 8; col++)
            {
                Chessboard.Add(new EmptyPiece(new ChessPosition(col, row)));
            }
        }
    }
    public abstract class Piece
    {
        public enum PieceColor
        {
            White,
            Black
        }

        public PieceColor Color { get; set; }
        public ChessPosition Position { get; set; }

        public Piece(PieceColor color, ChessPosition position)
        {
            Color = color;
            Position = position;
        }

        public abstract bool IsValidMove(ChessPosition toPosition, ObservableCollection<Piece> chessboard);

        internal bool IsValidMove(object endPosition, object chessboard)
        {
            throw new NotImplementedException();
        }
    }
    private void MovePiece(Move move, object Chessboard)
    {
        // Найти фигуру, которую нужно переместить
        Piece piece = Chessboard.FirstOrDefault(p => p.Position == move.StartPosition);

        if (piece != null)
        {
            // Проверить, может ли фигура выполнить данный ход
            if (piece.IsValidMove(move.EndPosition, Chessboard))
            {
                // Обновить позицию фигуры
                piece.Position = move.EndPosition;

                // Удалить фигуру, если на конечной позиции уже есть другая фигура
                Piece occupiedPiece = Chessboard.FirstOrDefault(p => p.Position == move.EndPosition);
                if (occupiedPiece != null)
                {
                    Chessboard.Remove(occupiedPiece);
                }
            }
        }
    }

    public class Pawn : Piece
    {
        public Pawn(PieceColor color, ChessPosition position) : base(color, position)
        {
        }

        public int currentRow { get; private set; }
        public int currentColumn { get; private set; }
        public int targetRow { get; private set; }
        public int targetColumn { get; private set; }

        public override bool IsValidMove(ChessPosition toPosition, ObservableCollection<Piece> chessboard)
        {
            if (currentRow < 0 || currentRow > 7 || currentColumn < 0 || currentColumn > 7 ||
     targetRow < 0 || targetRow > 7 || targetColumn < 0 || targetColumn > 7)
            {
                return false;
            }

            // Проверка, что ход по вертикали
            if (targetColumn == currentColumn)
            {
                // Проверка для белых пешек
                if (currentRow == targetRow - 1)
                {
                    return true;
                }

                // Проверка для черных пешек
                if (currentRow == targetRow + 1)
                {
                    return true;
                }
            }

            return false;
        }
    }

    public class Rook : Piece
    {
        public int currentRow { get; private set; }
        public int currentColumn { get; private set; }
        public int targetRow { get; private set; }
        public int targetColumn { get; private set; }

        public Rook(PieceColor color, ChessPosition position) : base(color, position)
        {
        }

        public override bool IsValidMove(ChessPosition toPosition, ObservableCollection<Piece> chessboard)
        {
            if (currentRow < 0 || currentRow > 7 || currentColumn < 0 || currentColumn > 7 ||
            targetRow < 0 || targetRow > 7 || targetColumn < 0 || targetColumn > 7)
                return false;

            // Ладья может двигаться только горизонтально или вертикально
            if (currentRow != targetRow && currentColumn != targetColumn)
                return false;

            // Проверяем, что между начальной и конечной клетками нет других фигур

            if (currentRow == targetRow)
            {
                int min = Math.Min(currentColumn, targetColumn);
                int max = Math.Max(currentColumn, targetColumn);
                for (int y = min + 1; y < max; y++)
                {
                    if (!chessboard[currentRow, y].HasPiece)
                    {
                        continue;
                    }

                    return false;
                }
            }
            else
            {
                int min = Math.Min(currentRow, targetRow);
                int max = Math.Max(currentRow, targetRow);
                for (int x = min + 1; x < max; x++)
                {
                    if (chessboard[x, currentColumn].HasPiece)
                    {
                        return false;
                    }
                }
            }

            // Все проверки прошли успешно
            return true;
        }
    }
    

    public class King : Piece
    {
        public int currentRow { get; private set; }
        public int currentColumn { get; private set; }
        public int targetRow { get; private set; }
        public int targetColumn { get; private set; }

        public King(PieceColor color, ChessPosition position) : base(color, position)
        {
        }

        public override bool IsValidMove(ChessPosition toPosition, ObservableCollection<Piece> chessboard)
        {
        if (currentRow < 0 || currentRow > 7 || currentColumn < 0 || currentColumn > 7 ||
      targetRow < 0 || targetRow > 7 || targetColumn < 0 ||targetColumn > 7)
            return false;

        // Король может двигаться на одну клетку в любом направлении
        if (Math.Abs(currentRow - targetRow) <= 1 && Math.Abs(currentColumn - targetColumn) <= 1)
            return true;

        return false;
    }



    }
    public class Queen : Piece
    {
        public int currentRow { get; private set; }
        public int currentColumn { get; private set; }
        public int targetRow { get; private set; }
        public int targetColumn { get; private set; }
        public Queen(PieceColor color, ChessPosition position) : base(color, position)
        {
        }

        public override bool IsValidMove(ChessPosition toPosition, ObservableCollection<Piece> chessboard)
        {
            // Проверяем, что начальные и конечные координаты находятся на нашей шахматной доске
            if (currentRow < 0 || currentRow > 7 || currentColumn < 0 ||currentColumn > 7 ||
                targetRow < 0 || targetRow > 7 || targetColumn < 0 ||targetColumn > 7)
                return false;

            // Королева может двигаться как по горизонтали и вертикали, так и по диагонали
            if (currentRow == targetRow || currentColumn == targetColumn || Math.Abs(currentRow - targetRow) == Math.Abs(currentColumn - targetColumn))
                return true;

            return false;
        }
    }
}



