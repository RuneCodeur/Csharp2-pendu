using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Numerics;
using System.Reflection;
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
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace pendu.Views
{
    /// <summary>
    /// Logique d'interaction pour play.xaml
    /// </summary>
    public partial class Play : UserControl
    {
        private List<string> Words;
        private string wordToGuess;
        private bool blockGame = false;
        private List<char> LetterCalled = new List<char>();

        public static readonly DependencyProperty NumberOfErrorsProperty = DependencyProperty.Register(
        "NumberOfErrors", typeof(int), typeof(Play), new PropertyMetadata(0));

        public int NumberOfErrors
        {
            get { return (int)GetValue(NumberOfErrorsProperty); }
            set { SetValue(NumberOfErrorsProperty, value); }
        }


        public Play()
        {
            InitializeComponent();
            Words = new List<string> { 
                "PENDU",
                "CHEVALIER",
                "CHATEAU",
                "DRAGON",
                "MAGIE",
                "ARMURE",
                "PRINCESSE",
                "SORCIER",
                "ROYAUME",
                "TROLL",
                "BOUCLIER",
                "LANCE",
                "GUERRIER",
                "SORTILEGE",
                "CACHOT",
                "TRESOR",
                "BAGUETTE",
                "ARCHER",
                "LEGENDE",
                "CATAPULTE",
                "MYSTERE",
                "TALISMAN",
                "CHAUDRON",
                "CHEMIN",
                "CREATURE",
                "ENCHANTEUR",
                "SPECTRE",
                "HARPIE",
                "MEDUSE",
                "PALADIN",
                "POTION",
                "SENTINELLE",
                "SORCIER",
                "TOMBEAU",
                "TYRANNIE",
                "VAMPIRE",
                "WYVERNE",
                "ZOMBIE",
                "ELIXIR",
            };
            DataContext = this;
            createWordToGuess();

            Loaded += Intro_Loaded;
        }
        private void Intro_Loaded(object sender, RoutedEventArgs e)
        {
            Focus();
        }

        public async void createWordToGuess()
        {
            Random random = new Random();
            int randomNumberWordToGuess = random.Next(0, Words.Count);
            wordToGuess = Words[randomNumberWordToGuess];
            NumberOfErrors = 0;
            LetterCalled = [];
            CheckWordToGuess();
        }

        public async void CheckWordToGuess()
        {
            int numberOfColumnswordGrid = wordToGuess.Length;
            wordGrid.Children.Clear();
            wordGrid.ColumnDefinitions.Clear();

            for (int i = 0; i < numberOfColumnswordGrid; i++)
            {
                ColumnDefinition columnDefinition = new ColumnDefinition();
                columnDefinition.Width = new GridLength(1, GridUnitType.Star);
                wordGrid.ColumnDefinitions.Add(columnDefinition);
            }
            bool isVictory = true;

            for (int i = 0; i < wordToGuess.Length; i++)
            {
                TextBox textBoxWord = new TextBox();

                textBoxWord.Width = 25;
                textBoxWord.Height = 25;
                textBoxWord.TextAlignment = TextAlignment.Center;
                textBoxWord.IsEnabled = false;
                textBoxWord.Margin = new Thickness(5);
                textBoxWord.FontSize = 18;
                textBoxWord.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFFFFFFF"));
                textBoxWord.FontWeight = FontWeights.Bold;

                if (!LetterCalled.Contains(wordToGuess[i]))
                {
                    textBoxWord.Text = "_";
                    isVictory = false;
                }
                else
                {
                    textBoxWord.Text = "" + wordToGuess[i];
                }
                wordGrid.Children.Add(textBoxWord);
                Grid.SetColumn(textBoxWord, i);
                Grid.SetRow(textBoxWord, 0);

                //Debug.WriteLine(wordToGuess[i]);
            }
            if(isVictory == true)
            {
                victory();
            }

            string allLetters = "";
            for (int i = 0; i < LetterCalled.Count; i++)
            {
                allLetters += LetterCalled[i] + " ";
            }
            LetterCalledGrid.Text = allLetters;
        }

        private async void UserControl_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key >= Key.A && e.Key <= Key.Z)
            {
                char letter = e.Key.ToString()[0];

                if (!LetterCalled.Contains(letter) && blockGame == false)
                {
                    blockGame = true;
                    LetterCalled.Add(letter);

                    if (!wordToGuess.Contains(letter))
                    {
                        NumberOfErrors++;
                        if(NumberOfErrors >= 11)
                        {
                            gameOver();
                        }
                        Debug.WriteLine("La lettre " + letter + " n'est pas présente dans le mot à découvrir." + NumberOfErrors);
                    }
                    CheckWordToGuess();
                    blockGame = false;
                }

            }
        }

        public async void victory()
        {
            int score = NumberOfErrors;
            Debug.WriteLine(score);

            switch (score)
            {
                case 0:
                    scoreView.Text = "Tu as fait AUCUNE faute !";
                    break;
                case 1:
                    scoreView.Text = "Tu as fait 1 seule faute !";
                    break;
                default:
                    scoreView.Text = "Tu as fait " + score + " fautes";
                    break;
            }
            var apparitionAnimation = FindResource("ApparitionVictory") as Storyboard;
            if (apparitionAnimation != null)
            {
                apparitionAnimation.Begin();
            }
            await Task.Delay(6000);
            createWordToGuess();
        }

        public async void gameOver()
        {
            Debug.WriteLine("perdu !");
            soluceView.Text = wordToGuess;

            var apparitionAnimation = FindResource("ApparitionGameOver") as Storyboard;
            if (apparitionAnimation != null)
            {
                apparitionAnimation.Begin();
            }

            await Task.Delay(6000);
            soluceView.Text = "";
            createWordToGuess();

        }
    }
}
