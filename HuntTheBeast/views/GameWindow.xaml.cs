using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using Engine.field;
using Engine.models;

namespace HuntTheBeast.views
{
    public partial class GameWindow
    {
        private Field field;
        private TileView selectedTile;
        private readonly Opponent oppenent;

        public GameWindow(Field gameField, Opponent opponent)
        {
            InitializeComponent();
            this.oppenent = opponent;
            InitField(gameField);
            RedrawField();
        }

        private void InitField(Field gameField)
        {
            field = gameField;
            for (var i = 0; i < field.Width; i++)
                Grid.RowDefinitions.Add(new RowDefinition());
            for (var i = 0; i < field.Height; i++)
                Grid.ColumnDefinitions.Add(new ColumnDefinition());
        }

        private void RedrawField()
        {
            for (var i = 0; i < field.Width; i++)
            for (var j = 0; j < field.Height; j++)
            {
                var tile = field.GetTile(new Coordinate(i, j));
                var image = Graphics.GetImageForTile(tile);
                var tileView = new TileView(image, tile)
                {
                    Width = GetTileSize(),
                    Height = GetTileSize(),
                };
                Grid.SetRow(tileView, i);
                Grid.SetColumn(tileView, j);
                Grid.Children.Add(tileView);
            }
        }
        
        private int GetTileSize()
        {
            var largeSize = field.Width > field.Height ? field.Width : field.Height;
            var size = SystemParameters.PrimaryScreenHeight / largeSize * 0.9;
            return Convert.ToInt32(size);
        }

        private void Grid_MouseUp(object sender, MouseButtonEventArgs e)
        {
            var tileView = e.Source as TileView;
            if (tileView?.Tile.Character is Hunter)
            {
                if (selectedTile == null)
                {
                    selectedTile = tileView;
                    selectedTile.Image.Source = new BitmapImage(new Uri("pack://application:,,,/images/hunter_reverse.png"));
                    
                }
                else if (tileView.Equals(selectedTile))
                {
                    tileView.Image.Source = new BitmapImage(new Uri("pack://application:,,,/images/hunter.png"));
                    selectedTile = null;
                }
                else
                {
                    MessageBox.Show("Одновременно можно выбрать только одного охотника", "", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
        }

        private void Window_KeyUp(object sender, KeyEventArgs e)
        {
            if (selectedTile == null)
                return;
            Coordinate destination;
            switch (e.Key)
            {
                case Key.Up:
                    destination = new Coordinate(selectedTile.Tile.Coordinate.X - 1, selectedTile.Tile.Coordinate.Y);
                    break;
                case Key.Down:
                    destination = new Coordinate(selectedTile.Tile.Coordinate.X + 1, selectedTile.Tile.Coordinate.Y);
                    break;
                case Key.Left:
                    destination = new Coordinate(selectedTile.Tile.Coordinate.X, selectedTile.Tile.Coordinate.Y - 1);
                    break;
                case Key.Right:
                    destination = new Coordinate(selectedTile.Tile.Coordinate.X, selectedTile.Tile.Coordinate.Y + 1);
                    break;
                default:
                    return;
            }
            if (field.IsPositionFree(destination))
            {
                field.MoveCharacter(selectedTile.Tile.Coordinate, destination);
                RedrawField();
                try
                {
                    oppenent.MakeMove(field);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Игра окончена", MessageBoxButton.OK, MessageBoxImage.Information);
                    Close();
                }
                selectedTile = null;
                RedrawField();
            }
        }
    }
}
