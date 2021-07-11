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
        private Piece[,] blackPieces, whitePieces;
        public MainWindow()
        {
            InitializeComponent();
            blackPieces = new Piece[8, 8];
            whitePieces = new Piece[8, 8];

            blackPieces[0, 0] = new Piece(PieceType.ROOK, 0,0);

            blackPieces[0, 0].GetLocation().CollectionChanged += listen;
            InitChessBoard();
            FillChessBoard();
        }

        private void listen(object sender, NotifyCollectionChangedEventArgs e)
        {
            if(sender is ObservableCollection<int>){
                if(((ObservableCollection<int>)sender).Count > 1)
                {
                    int[] locations = ((ObservableCollection<int>)sender).ToList().ToArray();
                    Console.WriteLine("New location: " + ChessBoard.boardLoc(locations));
                }
            }
        }

        private void FillChessBoard()
        {
            AddChessPiece(Piece.blackRook, "a8");
            AddChessPiece(Piece.blackRook, "h8");
            AddChessPiece(Piece.blackBishop, "c8");
            AddChessPiece(Piece.blackBishop, "f8");
            AddChessPiece(Piece.blackKnight, "b8");
            AddChessPiece(Piece.blackKnight, "g8");
            AddChessPiece(Piece.blackQueen, "d8");
            AddChessPiece(Piece.blackKing, "e8");
            AddChessPiece(Piece.blackPawn, "a7");
            AddChessPiece(Piece.blackPawn, "b7");
            AddChessPiece(Piece.blackPawn, "c7");
            AddChessPiece(Piece.blackPawn, "d7");
            AddChessPiece(Piece.blackPawn, "e7");
            AddChessPiece(Piece.blackPawn, "f7");
            AddChessPiece(Piece.blackPawn, "g7");
            AddChessPiece(Piece.blackPawn, "h7");

            AddChessPiece(Piece.whiteRook, "a1");
            AddChessPiece(Piece.whiteRook, "h1");
            AddChessPiece(Piece.whiteBishop, "c1");
            AddChessPiece(Piece.whiteBishop, "f1");
            AddChessPiece(Piece.whiteKnight, "b1");
            AddChessPiece(Piece.whiteKnight, "g1");
            AddChessPiece(Piece.whiteQueen, "d1");
            AddChessPiece(Piece.whiteKing, "e1");
            AddChessPiece(Piece.whitePawn, "a2");
            AddChessPiece(Piece.whitePawn, "b2");
            AddChessPiece(Piece.whitePawn, "c2");
            AddChessPiece(Piece.whitePawn, "d2");
            AddChessPiece(Piece.whitePawn, "e2");
            AddChessPiece(Piece.whitePawn, "f2");
            AddChessPiece(Piece.whitePawn, "g2");
            AddChessPiece(Piece.whitePawn, "h2");
        }

        private void AddChessPiece(string source, string location)
        {
            Image piece = new Image();
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
                            chessBoard.Children.Add(rect);
                        } else
                        {
                            Rectangle rect = new Rectangle();
                            rect.Fill = new SolidColorBrush(Color.FromRgb(236, 236, 212));
                            Grid.SetColumn(rect, lett);
                            Grid.SetRow(rect, num);
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

                            chessBoard.Children.Add(rect);
                        } else
                        {
                            Rectangle rect = new Rectangle();
                            rect.Fill = new SolidColorBrush(Color.FromRgb(236, 236, 212));
                            Grid.SetColumn(rect, lett);
                            Grid.SetRow(rect, num);
                            chessBoard.Children.Add(rect);
                        }
                    }
                }
            }
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            blackPieces[0, 0].movePiece(1, 1);
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
