using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ChessAI
{
    //num = row
    //lett = col
    public partial class MainWindow : Window
    {
        private static readonly int col = 0;
        private static readonly int row = 1;
        private Piece pieceToMove;
        private Color turn;

        //private Piece[,] blackPieces, whitePieces;
        public MainWindow()
        {
            InitializeComponent();
            ResetBoard(null,null);
        }

        private void listen(object sender, NotifyCollectionChangedEventArgs e)
        {
            if(sender is ObservableCollection<int>){
                if(((ObservableCollection<int>)sender).Count > 1)
                {
                    int[] locations = ((ObservableCollection<int>)sender).ToList().ToArray();
                    foreach (object ele in chessBoard.Children)
                    {
                        if(ele is Piece)
                        {
                            Piece piece = (Piece)ele;
                            if (piece.GetLocation() == sender)
                            {
                                Grid.SetColumn(piece, locations[col]);
                                Grid.SetRow(piece, locations[row]);
                            }
                        }
                    }
                }
            }
        }

        private void FillChessBoard()
        {
            AddChessPiece(Piece.blackRook, PieceType.ROOK, Colors.Black, "a8");
            AddChessPiece(Piece.blackRook, PieceType.ROOK, Colors.Black, "h8");
            AddChessPiece(Piece.blackBishop, PieceType.BISHOP, Colors.Black, "c8");
            AddChessPiece(Piece.blackBishop, PieceType.BISHOP, Colors.Black, "f8");
            AddChessPiece(Piece.blackKnight, PieceType.KNIGHT, Colors.Black, "b8");
            AddChessPiece(Piece.blackKnight, PieceType.KNIGHT, Colors.Black, "g8");
            AddChessPiece(Piece.blackQueen, PieceType.QUEEN, Colors.Black, "d8");
            AddChessPiece(Piece.blackKing, PieceType.KING, Colors.Black, "e8");
            AddChessPiece(Piece.blackPawn, PieceType.PAWN, Colors.Black, "a7");
            AddChessPiece(Piece.blackPawn, PieceType.PAWN, Colors.Black, "b7");
            AddChessPiece(Piece.blackPawn, PieceType.PAWN, Colors.Black, "c7");
            AddChessPiece(Piece.blackPawn, PieceType.PAWN, Colors.Black, "d7");
            AddChessPiece(Piece.blackPawn, PieceType.PAWN, Colors.Black, "e7");
            AddChessPiece(Piece.blackPawn, PieceType.PAWN, Colors.Black, "f7");
            AddChessPiece(Piece.blackPawn, PieceType.PAWN, Colors.Black, "g7");
            AddChessPiece(Piece.blackPawn, PieceType.PAWN, Colors.Black, "h7");

            AddChessPiece(Piece.whiteRook, PieceType.ROOK, Colors.White, "a1");
            AddChessPiece(Piece.whiteRook, PieceType.ROOK, Colors.White, "h1");
            AddChessPiece(Piece.whiteBishop, PieceType.BISHOP, Colors.White, "c1");
            AddChessPiece(Piece.whiteBishop, PieceType.BISHOP, Colors.White, "f1");
            AddChessPiece(Piece.whiteKnight, PieceType.KNIGHT, Colors.White, "b1");
            AddChessPiece(Piece.whiteKnight, PieceType.KNIGHT, Colors.White, "g1");
            AddChessPiece(Piece.whiteQueen, PieceType.QUEEN, Colors.White, "d1");
            AddChessPiece(Piece.whiteKing, PieceType.KING, Colors.White, "e1");
            AddChessPiece(Piece.whitePawn, PieceType.PAWN, Colors.White, "a2");
            AddChessPiece(Piece.whitePawn, PieceType.PAWN, Colors.White, "b2");
            AddChessPiece(Piece.whitePawn, PieceType.PAWN, Colors.White, "c2");
            AddChessPiece(Piece.whitePawn, PieceType.PAWN, Colors.White, "d2");
            AddChessPiece(Piece.whitePawn, PieceType.PAWN, Colors.White, "e2");
            AddChessPiece(Piece.whitePawn, PieceType.PAWN, Colors.White, "f2");
            AddChessPiece(Piece.whitePawn, PieceType.PAWN, Colors.White, "g2");
            AddChessPiece(Piece.whitePawn, PieceType.PAWN, Colors.White, "h2");
        }

        private void AddChessPiece(string source, PieceType type, Color color, string location)
        {
            Piece piece = new Piece(type, color, ChessBoard.boardLoc(location));
            piece.GetLocation().CollectionChanged += listen;
            piece.MouseDown += clickPiece;
            piece.MouseUp += TakePiece;
            BitmapImage logo = new BitmapImage();
            logo.BeginInit();
            logo.UriSource = new Uri(source);
            logo.EndInit();
            piece.Source = logo;
            
            Panel.SetZIndex(piece, 2);
            Grid.SetColumn(piece, ChessBoard.boardLoc(location)[0]);
            Grid.SetRow(piece, ChessBoard.boardLoc(location)[1]);
            chessBoard.Children.Add(piece);
        }

        private void InitChessBoard()
        {
            for (int num = 0; num < 8; num++)
            {
                for (int lett = 0; lett < 8; lett++)
                {
                    if (num % 2 == 0) // even
                    {
                        if (lett % 2 != 0) // even
                        {
                            Rectangle rect = new Rectangle();
                            rect.Fill = new SolidColorBrush(Color.FromRgb(116, 148, 84));
                            Grid.SetColumn(rect, lett);
                            Grid.SetRow(rect, num);
                            rect.MouseUp += MovePiece;
                            chessBoard.Children.Add(rect);
                        } else
                        {
                            Rectangle rect = new Rectangle();
                            rect.Fill = new SolidColorBrush(Color.FromRgb(236, 236, 212));
                            Grid.SetColumn(rect, lett);
                            Grid.SetRow(rect, num);
                            rect.MouseUp += MovePiece;
                            chessBoard.Children.Add(rect);
                        }
                    } else // odd
                    {
                        if (lett % 2 == 0) // odd
                        {
                            Rectangle rect = new Rectangle();
                            rect.Fill = new SolidColorBrush(Color.FromRgb(116, 148, 84));
                            Grid.SetColumn(rect, lett);
                            Grid.SetRow(rect, num);
                            rect.MouseUp += MovePiece;
                            chessBoard.Children.Add(rect);
                        } else
                        {
                            Rectangle rect = new Rectangle();
                            rect.Fill = new SolidColorBrush(Color.FromRgb(236, 236, 212));
                            Grid.SetColumn(rect, lett);
                            Grid.SetRow(rect, num);
                            rect.MouseUp += MovePiece;
                            chessBoard.Children.Add(rect);
                        }
                    }
                }
            }
        }

        private void TakePiece(object sender, RoutedEventArgs e)
        {
            if(pieceToMove != null && pieceToMove.GetPieceColor() != ((Piece)sender).GetPieceColor())
            {
                int[,] moves = pieceToMove.ValidMoves(this);
                if(moves != null)
                {
                    for (int i = 0; i < (moves.Length) / 2; i++)
                    {
                        if (pieceToMove.ValidMoves(this)[i, col] == Grid.GetColumn((UIElement)sender) && pieceToMove.ValidMoves(this)[i, row] == Grid.GetRow((UIElement)sender))
                        {
                            chessBoard.Children.Remove((UIElement)sender);
                            pieceToMove.MovePiece(Grid.GetColumn((UIElement)sender), Grid.GetRow((UIElement)sender));
                            pieceToMove = null;
                            turn = (turn == Colors.White) ? Colors.Black : Colors.White;
                            Console.WriteLine("Moved Piece");
                            break;
                        }
                    }
                }
            }
        }

        private void MovePiece(object sender, RoutedEventArgs e)
        {
            if(pieceToMove != null)
            {
                int[,] moves = pieceToMove.ValidMoves(this);
                if (moves != null)
                {
                    for (int i = 0; i < (pieceToMove.ValidMoves(this).Length) / 2; i++)
                    {
                        if (pieceToMove.ValidMoves(this)[i, col] == Grid.GetColumn((UIElement)sender) && pieceToMove.ValidMoves(this)[i, row] == Grid.GetRow((UIElement)sender))
                        {
                            pieceToMove.MovePiece(Grid.GetColumn((UIElement)sender), Grid.GetRow((UIElement)sender));
                            pieceToMove = null;
                            turn = (turn == Colors.White) ? Colors.Black : Colors.White;
                            Console.WriteLine("Moved Piece");
                            break;
                        }
                    }
                }
            }
        }

        private void clickPiece(object sender, RoutedEventArgs e)
        {
            if(((Piece)sender).GetPieceColor().Equals(turn))
            {
                pieceToMove = ((Piece)sender);
                Console.WriteLine("Selected Piece");
            }
        }

        public Piece GetPieceAt(int col, int row)
        {
            foreach (UIElement ele in chessBoard.Children)
            {
                if(Grid.GetColumn(ele) == col && Grid.GetRow(ele) == row && ele is Piece)
                {
                    return (Piece)ele;
                }
            }
            return null;
        }

        private void ExitClick(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void ResetBoard(object sender, RoutedEventArgs e)
        {
            chessBoard.Children.Clear();
            turn = Colors.White;
            InitChessBoard();
            FillChessBoard();
        }
    }
}
