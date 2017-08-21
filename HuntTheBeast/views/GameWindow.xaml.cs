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
        private Opponent oppenent;

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
                var image = GetImageForTile(field.GetTile(new Coordinate(i, j)));
                var tile = field.GetTile(new Coordinate(i, j));
                var fieldTile = new TileView(image, tile)
                {
                    Width = GetTileSize(),
                    Height = GetTileSize(),
                };
                Grid.SetRow(fieldTile, i);
                Grid.SetColumn(fieldTile, j);
                Grid.Children.Add(fieldTile);
            }
        }

        private Image GetImageForTile(Tile tile)
        {
            var image = new Image();
            var character = tile.Character;
            if (character != null)
            {
                if (character is DumbBeast)
                    image.Source = new BitmapImage(new Uri("pack://application:,,,/images/beast.png"));
                if (character is Hunter)
                    image.Source = new BitmapImage(new Uri("pack://application:,,,/images/hunter.png"));
            }
            else switch (tile.Type)
            {
                case Tile.TileType.Trap:
                    image.Source = new BitmapImage(new Uri("pack://application:,,,/images/trap.png"));
                    break;
                case Tile.TileType.Common:
                    image.Source = new BitmapImage(new Uri("pack://application:,,,/images/plain.png"));
                    break;
            }
            return image;
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
                    destination = new Coordinate(selectedTile.Tile.Coordinate.x - 1, selectedTile.Tile.Coordinate.y);
                    break;
                case Key.Down:
                    destination = new Coordinate(selectedTile.Tile.Coordinate.x + 1, selectedTile.Tile.Coordinate.y);
                    break;
                case Key.Left:
                    destination = new Coordinate(selectedTile.Tile.Coordinate.x, selectedTile.Tile.Coordinate.y - 1);
                    break;
                case Key.Right:
                    destination = new Coordinate(selectedTile.Tile.Coordinate.x, selectedTile.Tile.Coordinate.y + 1);
                    break;
                default:
                    return;
            }
            if (field.IsPositionFreeToMove(destination))
            {
                field.MoveCharacter(selectedTile.Tile.Coordinate, destination);
                try
                {
                    oppenent.MakeMove(field);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                selectedTile = null;
                RedrawField();
            }
        }
    }
}
