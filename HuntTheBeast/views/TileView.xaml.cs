using System.Windows.Media.Imaging;
using Engine.field;

namespace HuntTheBeast.views
{
    public partial class TileView
    {
        public readonly Tile Tile;

        public TileView(BitmapImage image, Tile tile)
        {
            InitializeComponent();
            Image.Source = image;
            Tile = tile;
        }
    }
}
