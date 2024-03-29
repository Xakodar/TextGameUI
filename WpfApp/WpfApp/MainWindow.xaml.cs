using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using TextGame;

namespace WpfApp
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Game Game { get; set; }

        public MainWindow()
        {
            InitializeComponent();

            Game = new Game();
        }

        /// <summary>
        /// Запускает игру. Если входной параметр true - загружает сохранение.
        /// </summary>
        /// <param name="loadSave"></param>
        /// <returns>Возращает true если загрузка прошла успешно.</returns>
        public bool StartGame(bool loadSave)
        {
            bool isLoad = true; 

            if (loadSave)
            {
                isLoad = Loading();
            }
            if (!isLoad)
            {
                return isLoad;
            }
            var step = Game.StartGame();
            DataContext = step;

            return isLoad;
        }

        /// <summary>
        /// Отображает следующий ход игры.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click_NextStep(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            var variant = (Variant)button.DataContext;

            var step = (Step)DataContext;
            var listVariants = step.Variants;
            int index = listVariants.IndexOf(variant);

            step = Game.NextStep(index + 1);
            DataContext = step;

            return;
        }

        /// <summary>
        /// Событие нажатия кнопки. Сохраняет игру и убивает процесс приложения.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click_Exit(object sender, RoutedEventArgs e)
        {
            Game.Save();
            Process.GetCurrentProcess().Kill();
        }

        /// <summary>
        /// Загружает сохраненное состояние обьекта.
        /// </summary>
        /// <returns>Возвращает true если загрузка прошла успешно.</returns>
        private bool Loading()
        {
            try
            {
                Game = Game.Looding();
                return true;
            }
            catch (System.Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Событие нажатия кнопки закрытия окна. Сохраняет игру и убивает процесс приложения.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnClosing(CancelEventArgs e)
        {
            Game.Save();
            Process.GetCurrentProcess().Kill();
            base.OnClosing(e);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Game.Save();
        }
    }
}
