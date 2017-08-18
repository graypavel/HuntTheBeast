using System;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Engine.field;
using Engine.models;
using HuntTheBeast.controls;

namespace HuntTheBeast
{
    public partial class GameWindow
    {
        private readonly Field field;

        public GameWindow(Field gameField)
        {
            InitializeComponent();
            field = gameField;
            Grid.Rows = field.Width;
            Grid.Columns = field.Height;
            for (var i = 0; i < field.Width; i++)
            {
                for (var j = 0; j < field.Height; j++)
                {
                    var image = GetImageForTile(field.Tiles[i, j]);
                    var tile = field.Tiles[i, j];
                    var fieldTile = new FieldTile(image, tile)
                    {
                        Width = GetTileSize(),
                        Height = GetTileSize(),
                    };
                    Grid.Children.Add(fieldTile);
                }
            }
            
        }

        private Image GetImageForTile(Tile tile)
        {
            var image = new Image();
            var character = tile.Character;
            if (character != null)
            {
                if (character is Beast)
                    image.Source = new BitmapImage(new Uri("pack://application:,,,/images/beast.png"));
                if (character is Hunter)
                    image.Source = new BitmapImage(new Uri("pack://application:,,,/images/hunter.png"));
            }
            if (tile.Type == Tile.TileType.Trap)
                image.Source = new BitmapImage(new Uri("pack://application:,,,/images/trap.png"));
            return image;
        }
        
        private int GetTileSize()
        {
            var largeSize = field.Width > field.Height ? field.Width : field.Height;
            var size = System.Windows.SystemParameters.PrimaryScreenHeight / largeSize * 0.8;
            return Convert.ToInt32(size);
        }
    }
}
