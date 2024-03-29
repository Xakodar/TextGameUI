using System.Windows;

namespace WpfApp
{
    /// <summary>
    /// Логика взаимодействия для Lobby.xaml
    /// </summary>
    public partial class Lobby : Window
    {
        public MainWindow MainWindow { get; set; }
        
        public Lobby()
        {
            InitializeComponent();
            MainWindow = new MainWindow();
        }

        /// <summary>
        /// Событие нажатия кнопки. Начинает первый ход игры.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click_StartGame(object sender, RoutedEventArgs e)
        {
            MainWindow.StartGame(loadSave: false);
            MainWindow.Show();
            this.Close();
        }

        /// <summary>
        /// Событие нажатия кнопки. Загружает файл сохранения и запускает игру.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click_StartGameSave(object sender, RoutedEventArgs e)
        {
            var isLoad = MainWindow.StartGame(loadSave: true);
            if (isLoad)
            {
                MainWindow.Show();
                this.Close();
            }

            textBoxError.Visibility = Visibility.Visible;
        }
    }
}
