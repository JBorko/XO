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
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace X_O_Game
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private GameEngine gameEngine;
        public MainWindow()
        {
            InitializeComponent();
            gameEngine = new GameEngine();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            FieldState fieldState = FieldState.O;
            if (gameEngine.CurrentPlayer.Equals(gameEngine.PlayerX))
            {
                fieldState = FieldState.X;
            }
            (sender as Button).Content = fieldState;
            int i = int.Parse((sender as Button).Name.Split('_')[1][0].ToString());
            int j = int.Parse((sender as Button).Name.Split('_')[1][1].ToString());
            (gameEngine.GameBoard.Fields.GetValue(i,j) as Field).State = fieldState;

            if (gameEngine.Status == GameStatus.NEW_GAME)
            {
                if (gameEngine.ScoreBoard.GetGameWinner(gameEngine.ScoreBoard.NumOfGamesPlayed).Equals(gameEngine.PlayerO))
                {
                    MessageBox.Show("Winner is Player 1");
                    lblP1.Content = "Player 1: " + gameEngine.PlayerO.Score;
                }
                else
                {
                    MessageBox.Show("Winner is Player 2");
                    lblP2.Content = "Player 2: " + gameEngine.PlayerX.Score;
                }
                foreach (UIElement elem in MainGrid.Children)
                {
                    if (elem is Button)
                    {
                        (elem as Button).Content = "";
                    }
                }
            }
        }
    }
}
