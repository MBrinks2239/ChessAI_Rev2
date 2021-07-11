using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessAI
{
    class Piece
    {
        public static readonly string whitePawn = "pack://application:,,,/ChessAI;component/resources/images/pieces/white/pawn.png";
        public static readonly string whiteKing = "pack://application:,,,/ChessAI;component/resources/images/pieces/white/king.png";
        public static readonly string whiteQueen = "pack://application:,,,/ChessAI;component/resources/images/pieces/white/queen.png";
        public static readonly string whiteBishop = "pack://application:,,,/ChessAI;component/resources/images/pieces/white/bishop.png";
        public static readonly string whiteRook = "pack://application:,,,/ChessAI;component/resources/images/pieces/white/rook.png";
        public static readonly string whiteKnight = "pack://application:,,,/ChessAI;component/resources/images/pieces/white/knight.png";

        public static readonly string blackPawn = "pack://application:,,,/ChessAI;component/resources/images/pieces/black/pawn.png";
        public static readonly string blackKing = "pack://application:,,,/ChessAI;component/resources/images/pieces/black/king.png";
        public static readonly string blackQueen = "pack://application:,,,/ChessAI;component/resources/images/pieces/black/queen.png";
        public static readonly string blackBishop = "pack://application:,,,/ChessAI;component/resources/images/pieces/black/bishop.png";
        public static readonly string blackRook = "pack://application:,,,/ChessAI;component/resources/images/pieces/black/rook.png";
        public static readonly string blackKnight = "pack://application:,,,/ChessAI;component/resources/images/pieces/black/knight.png";

        private static readonly int col = 0;
        private static readonly int row = 1;

        private PieceType type;
        private ObservableCollection<int> location;

        public Piece(PieceType _type, params int[] _location)
        {
            type = _type;
            location = new ObservableCollection<int>();
            location.Add(_location[col]);
            location.Add(_location[row]);
        }

        public ObservableCollection<int> GetLocation()
        {
            return location;
        }

        public void movePiece(params int[] _location)
        {
            location.Clear();
            location.Add(_location[col]);
            location.Add(_location[row]);
        }

        public PieceType GetPieceType()
        {
            return type;
        }
    }
}
