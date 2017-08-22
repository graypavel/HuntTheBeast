using System;
using System.Windows.Media.Imaging;
using Engine.field;
using Engine.models;

namespace HuntTheBeast
{
    public static class Graphics
    {
        public static BitmapImage GetImageForTile(Tile tile)
        {
            var character = tile.Character;
            if (character != null)
            {
                return character is Hunter
                    ? new BitmapImage(new Uri("pack://application:,,,/images/hunter.png"))
                    : new BitmapImage(new Uri("pack://application:,,,/images/beast.png"));
            }
            switch (tile.Type)
            {
                case Tile.TileType.Trap:
                    return new BitmapImage(new Uri("pack://application:,,,/images/trap.png"));
                case Tile.TileType.Common:
                    return new BitmapImage(new Uri("pack://application:,,,/images/plain.png"));
                default:
                    return new BitmapImage(new Uri("pack://application:,,,/images/plain.png"));
            }
        }

        public static BitmapImage GetHunter()
        {
            return new BitmapImage(new Uri("pack://application:,,,/images/hunter.png"));
        }

        public static BitmapImage GetSelectedHunter()
        {
            return new BitmapImage(new Uri("pack://application:,,,/images/hunter_reverse.png"));
        }
    }
}
