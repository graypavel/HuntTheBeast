using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Effects;
using Engine.field;
using Engine.models;

namespace HuntTheBeast.controls
{
    public partial class FieldTile
    {
        public Tile tile;

        public FieldTile(Image image, Tile tile)
        {
            InitializeComponent();
            Image.Source = image.Source;
            this.tile = tile;
        }

        private void Image_MouseUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            //if (tile.Character is Hunter)
                
        }
    }
}
