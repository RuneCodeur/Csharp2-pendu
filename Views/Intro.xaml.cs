using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace pendu.Views
{
    /// <summary>
    /// Logique d'interaction pour intro.xaml
    /// </summary>
    public partial class Intro : UserControl
    {
        private bool isStarted = false;
        public Intro()
        {
            InitializeComponent();
            Loaded += Intro_Loaded;
        }


        private void Intro_Loaded(object sender, RoutedEventArgs e)
        {
            Focus();
        }

        private async void UserControl_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter && isStarted == false)
            {
                isStarted = true;
                var fadeAnimation = FindResource("FadeInOut") as Storyboard;

                BeginStoryboard(fadeAnimation);
                await Task.Delay(700);

                Play PlayPage = new Play();
                ((MainWindow)Application.Current.MainWindow).mainFrame.Content = PlayPage;
            }

        }
    }
}
