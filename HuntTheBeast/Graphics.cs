﻿using System;
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
    }
}
