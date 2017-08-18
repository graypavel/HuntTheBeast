using System.Windows;
using System.Windows.Controls;
using Engine.field;
using Engine.models;

namespace HuntTheBeast.controls
{
    public partial class FieldTile
    {
        private Tile tile;

        public FieldTile(Image image, Tile tile)
        {
            InitializeComponent();
            Image.Source = image.Source;
            this.tile = tile;
        }

        private void Image_MouseUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            MessageBox.Show("click!");
        }

        private void Image_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {

        }
    }
}
