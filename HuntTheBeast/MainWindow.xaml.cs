using System;
using System.Windows;
using Engine.field;

namespace HuntTheBeast
{
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void RunClick(object sender, RoutedEventArgs e)
        {
            try
            {
                var template = new FieldTemplate(int.Parse(Width.Text), int.Parse(Height.Text), int.Parse(Hunters.Text),
                    1,
                    int.Parse(Traps.Text));

                var field = FieldFactory.MakeField(template);
                new GameWindow(field).ShowDialog();

            }
            catch (Exception fuckUp)
            {
                MessageBox.Show(fuckUp.Message, "Ошибка инициализации", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
