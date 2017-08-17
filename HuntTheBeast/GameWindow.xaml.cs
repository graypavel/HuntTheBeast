using System;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Engine.field;
using Engine.models;

namespace HuntTheBeast
{
    public partial class GameWindow
    {
        private Field field;

        public GameWindow(Field gameField)
        {
            InitializeComponent();
            field = gameField;
            Grid.Rows = field.Width;
            Grid.Columns = field.Height;

            for (int i = 0; i < field.Width; i++)
            {
                for (int j = 0; j < field.Height; j++)
                {
                    var largeSize = field.Width > field.Height ? field.Width : field.Height;
                    var imgSize = System.Windows.SystemParameters.PrimaryScreenHeight / largeSize * 0.8;



                    Button b = new Button();
                    var character = field.Tiles[i, j].Character;
                    if (character != null)
                    {
                        if (character is Beast)
                            b.Background = new ImageBrush {ImageSource = new BitmapImage(new Uri("images/beast.png"))};
                        if(character is Hunter)
                            b.Background = new ImageBrush { ImageSource = new BitmapImage(new Uri("images/hunter.png")) };
                    }
                    b.Content = "btn";
                    b.Width = imgSize;
                    b.Height = imgSize;
                    Grid.Children.Add(b);
                }
            }
            Grid.UpdateLayout();

        }
    }
}
