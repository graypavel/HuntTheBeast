using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using Engine.field;
using Engine.models;

namespace HuntTheBeast
{
    public static class Graphics
    {
        public static Image GetImageForTile(Tile tile)
        {
            var image = new Image();
            var character = tile.Character;
            if (character != null)
            {
                if (character is Hunter)
                    image.Source = new BitmapImage(new Uri("pack://application:,,,/images/hunter.png"));
                else 
                    image.Source = new BitmapImage(new Uri("pack://application:,,,/images/beast.png"));
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

        public static Image GetHunter()
        {
            var image = new Image();
            image.Source = new BitmapImage(new Uri("pack://application:,,,/images/hunter.png"));
            return image;
        }

        public static Image GetSelectedHunter()
        {
            var image = new Image();
            image.Source = new BitmapImage(new Uri("pack://application:,,,/images/hunter_reverse.png"));
            return image;
        }
    }
}
