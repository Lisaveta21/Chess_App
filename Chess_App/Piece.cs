using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel;

namespace ChessGame.Models
{
    public class Piece : INotifyPropertyChanged
    {
        private string _imageUri;

        public string ImageUri
        {
            get { return _imageUri; }
            set
            {
                _imageUri = value;
                OnPropertyChanged("ImageUri");
            }
        }
      

        public abstract bool IsValidMove(ChessPosition toPosition, ObservableCollection<Piece> chessboard);

        private string _background;

        public string Background
        {
            get { return _background; }
            set
            {
                _background = value;
                OnPropertyChanged("Background");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        internal bool IsValidMove(object endPosition, object chessboard)
        {
            throw new NotImplementedException();
        }
    }

}
