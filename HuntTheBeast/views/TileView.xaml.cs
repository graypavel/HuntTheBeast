using System.Windows.Controls;
using Engine.field;

namespace HuntTheBeast.views
{
    public partial class TileView
    {
        public readonly Tile Tile;

        public TileView(Image image, Tile tile)
        {
            InitializeComponent();
            Image.Source = image.Source;
            Tile = tile;
        }
    }
}
