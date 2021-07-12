using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace ChessAI
{
    public class Piece : Image
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
        private Color color;
        private bool firstMove;
        private ObservableCollection<int> location;

        public Piece(PieceType _type, Color _color, params int[] _location)
        {
            type = _type;
            color = _color;
            firstMove = true;
            location = new ObservableCollection<int>();
            location.Add(_location[col]);
            location.Add(_location[row]);
        }

        public ObservableCollection<int> GetLocation()
        {
            return location;
        }

        public void MovePiece(params int[] _location)
        {
            location.Clear();
            location.Add(_location[col]);
            location.Add(_location[row]);
            firstMove = false;
        }

        public PieceType GetPieceType()
        {
            return type;
        }

        public Color GetPieceColor()
        {
            return color;
        }

        public int[,] ValidMoves(MainWindow main)
        {
            switch(type)
            {
                case PieceType.PAWN:
                    return ValidPawn(main);

                case PieceType.BISHOP:
                    return ValidBishop(main);

                case PieceType.KNIGHT:
                    return ValidKnight(main);

                case PieceType.ROOK:
                    return ValidRook(main);

                case PieceType.KING:
                    return ValidKing(main);

                case PieceType.QUEEN:
                    return ValidQueen(main);

               default:
                   return null;
            }
        }

        private int[,] to2d(int[][] source)
        {
            try
            {
                int[,] result = new int[source.Length, source[0].Length];

                for (int i = 0; i < source.Length; i++)
                {
                    for (int k = 0; k < source[0].Length; k++)
                    {
                        result[i, k] = source[i][k];
                    }
                }

                return result;
            } catch
            {
                return null;
            }
        }

        private int[,] ValidPawn(MainWindow main)
        {
            List<int[]> moves = new List<int[]>();
            if (color == Colors.White)
            {
                if (!(main.GetPieceAt(location.ElementAt(col), location.ElementAt(row) - 1) is Piece))
                {
                    moves.Add(new int[2] { location.ElementAt(col), location.ElementAt(row) - 1 });
                    if (main.GetPieceAt(location.ElementAt(col), location.ElementAt(row) - 2) == null && firstMove)
                    {
                        moves.Add(new int[2] { location.ElementAt(col), location.ElementAt(row) - 2 });
                    }
                }

                if ((main.GetPieceAt(location.ElementAt(col) + 1, location.ElementAt(row) - 1) is Piece))
                {
                    moves.Add(new int[2] { location.ElementAt(col) + 1, location.ElementAt(row) - 1 });
                }
                if ((main.GetPieceAt(location.ElementAt(col) - 1, location.ElementAt(row) - 1) is Piece))
                {
                    moves.Add(new int[2] { location.ElementAt(col) - 1, location.ElementAt(row) - 1 });
                }
            } else
            {
                if (!(main.GetPieceAt(location.ElementAt(col), location.ElementAt(row) + 1) is Piece))
                {
                    moves.Add(new int[2] { location.ElementAt(col), location.ElementAt(row) + 1 });
                    if (main.GetPieceAt(location.ElementAt(col), location.ElementAt(row) + 2) == null && firstMove)
                    {
                        moves.Add(new int[2] { location.ElementAt(col), location.ElementAt(row) + 2 });
                    }
                }

                if ((main.GetPieceAt(location.ElementAt(col) + 1, location.ElementAt(row) + 1) is Piece))
                {
                    moves.Add(new int[2] { location.ElementAt(col) + 1, location.ElementAt(row) + 1 });
                }
                if ((main.GetPieceAt(location.ElementAt(col) - 1, location.ElementAt(row) + 1) is Piece))
                {
                    moves.Add(new int[2] { location.ElementAt(col) - 1, location.ElementAt(row) + 1 });
                }
            }
            int[][] arrays = moves.Select(a => a.ToArray()).ToArray();
            return to2d(arrays);
        }
        private int[,] ValidBishop(MainWindow main)
        {
            List<int[]> moves = new List<int[]>();
            if (color == Colors.White)
            {
                bool hitObstacle = false;
                for(int i = 0; !hitObstacle; i++)
                {
                    if(location[col] + i >= 8 && location[row] + i >= 8)
                    {
                        break;
                    } else
                    {
                        if (main.GetPieceAt(location.ElementAt(col) + i, location.ElementAt(row) + i) != null)
                        {
                            moves.Add(new int[2] { location.ElementAt(col) + i, location.ElementAt(row) + i});
                        }
                    }
                }
            }
            int[][] arrays = moves.Select(a => a.ToArray()).ToArray();
            return to2d(arrays);
        }
        private int[,] ValidRook(MainWindow main)
        {
            List<int[]> moves = new List<int[]>();
            if (color == Colors.White)
            {
                if (!(main.GetPieceAt(location.ElementAt(col), location.ElementAt(row) + 1) is Piece))
                {
                    moves.Add(new int[2] { location.ElementAt(col), location.ElementAt(row) + 1 });
                    if (main.GetPieceAt(location.ElementAt(col), location.ElementAt(row) + 2) == null)
                    {
                        moves.Add(new int[2] { location.ElementAt(col), location.ElementAt(row) + 2 });
                    }
                }

                if ((main.GetPieceAt(location.ElementAt(col) + 1, location.ElementAt(row) + 1) == null))
                {
                    moves.Add(new int[2] { location.ElementAt(col) + 1, location.ElementAt(row) + 1 });
                }
                if ((main.GetPieceAt(location.ElementAt(col) - 1, location.ElementAt(row) + 1) == null))
                {
                    moves.Add(new int[2] { location.ElementAt(col) - 1, location.ElementAt(row) + 1 });
                }
            }
            int[][] arrays = moves.Select(a => a.ToArray()).ToArray();
            return to2d(arrays);
        }
        private int[,] ValidKnight(MainWindow main)
        {
            List<int[]> moves = new List<int[]>();
            if (color == Colors.White)
            {
                if (!(main.GetPieceAt(location.ElementAt(col), location.ElementAt(row) + 1) is Piece))
                {
                    moves.Add(new int[2] { location.ElementAt(col), location.ElementAt(row) + 1 });
                    if (main.GetPieceAt(location.ElementAt(col), location.ElementAt(row) + 2) == null)
                    {
                        moves.Add(new int[2] { location.ElementAt(col), location.ElementAt(row) + 2 });
                    }
                }

                if ((main.GetPieceAt(location.ElementAt(col) + 1, location.ElementAt(row) + 1) == null))
                {
                    moves.Add(new int[2] { location.ElementAt(col) + 1, location.ElementAt(row) + 1 });
                }
                if ((main.GetPieceAt(location.ElementAt(col) - 1, location.ElementAt(row) + 1) == null))
                {
                    moves.Add(new int[2] { location.ElementAt(col) - 1, location.ElementAt(row) + 1 });
                }
            }
            int[][] arrays = moves.Select(a => a.ToArray()).ToArray();
            return to2d(arrays);
        }
        private int[,] ValidKing(MainWindow main)
        {
            List<int[]> moves = new List<int[]>();
            if (color == Colors.White)
            {
                if (!(main.GetPieceAt(location.ElementAt(col), location.ElementAt(row) + 1) is Piece))
                {
                    moves.Add(new int[2] { location.ElementAt(col), location.ElementAt(row) + 1 });
                    if (main.GetPieceAt(location.ElementAt(col), location.ElementAt(row) + 2) == null)
                    {
                        moves.Add(new int[2] { location.ElementAt(col), location.ElementAt(row) + 2 });
                    }
                }

                if ((main.GetPieceAt(location.ElementAt(col) + 1, location.ElementAt(row) + 1) == null))
                {
                    moves.Add(new int[2] { location.ElementAt(col) + 1, location.ElementAt(row) + 1 });
                }
                if ((main.GetPieceAt(location.ElementAt(col) - 1, location.ElementAt(row) + 1) == null))
                {
                    moves.Add(new int[2] { location.ElementAt(col) - 1, location.ElementAt(row) + 1 });
                }
            }
            int[][] arrays = moves.Select(a => a.ToArray()).ToArray();
            return to2d(arrays);
        }
        private int[,] ValidQueen(MainWindow main)
        {
            List<int[]> moves = new List<int[]>();
            if (color == Colors.White)
            {
                if (!(main.GetPieceAt(location.ElementAt(col), location.ElementAt(row) + 1) is Piece))
                {
                    moves.Add(new int[2] { location.ElementAt(col), location.ElementAt(row) + 1 });
                    if (main.GetPieceAt(location.ElementAt(col), location.ElementAt(row) + 2) == null)
                    {
                        moves.Add(new int[2] { location.ElementAt(col), location.ElementAt(row) + 2 });
                    }
                }

                if ((main.GetPieceAt(location.ElementAt(col) + 1, location.ElementAt(row) + 1) == null))
                {
                    moves.Add(new int[2] { location.ElementAt(col) + 1, location.ElementAt(row) + 1 });
                }
                if ((main.GetPieceAt(location.ElementAt(col) - 1, location.ElementAt(row) + 1) == null))
                {
                    moves.Add(new int[2] { location.ElementAt(col) - 1, location.ElementAt(row) + 1 });
                }
            }
            int[][] arrays = moves.Select(a => a.ToArray()).ToArray();
            return to2d(arrays);
        }
    }
}
