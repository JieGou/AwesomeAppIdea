using AwesomeAppIdea.Core.Contracts;
using AwesomeAppIdea.UI.View;
using Prism.Commands;
using SIG.Model;
using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;
                                                                                                                        
namespace AwesomeAppIdea.UI.ViewModel
{
    internal class Controller_ViewModel
    {
        public Controller_ViewModel(IClientTheme clientTheme)
        {
            Loaded_Command = new DelegateCommand<UserControl>(Handler_Loaded_Command);
            Unloaded_Command = new DelegateCommand<RoutedEventArgs>(Handler_Unloaded_Command);
            KeyDown_Command = new DelegateCommand<KeyEventArgs>(Handler_KeyDown_Command);
            KeyUp_Command = new DelegateCommand<KeyEventArgs>(Handler_KeyUp_Command);

            _keydownhandler = new KeyEventHandler((o, e) => Handler_KeyDown_Command(e));
            _keyuphandler = new KeyEventHandler((o, e) => Handler_KeyUp_Command(e));

            _hiScoreDirectory = new DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\AwesomeAppIdea");
            _highscore = new FileInfo(Path.Combine(_hiScoreDirectory.FullName, "highscore"));

            LoadHighScore();

            Game = new Game(_hiScore, clientTheme);

            _timerGame = new DispatcherTimer()
            {
                Interval = TimeSpan.FromMilliseconds(20)
            };
            _timerGame.Tick += Handler_TimerTick;
        }

        private readonly DirectoryInfo _hiScoreDirectory;
        private readonly FileInfo _highscore;
        private DispatcherTimer _timerGame;

        private Key _keyPressed;
        public Game Game { get; }
        private UserControl _view;
        private uint _hiScore;

        private readonly KeyEventHandler _keydownhandler;
        private readonly KeyEventHandler _keyuphandler;

        public DelegateCommand<UserControl> Loaded_Command { get; }
        public DelegateCommand<RoutedEventArgs> Unloaded_Command { get; }
        public DelegateCommand<KeyEventArgs> KeyDown_Command { get; }
        public DelegateCommand<KeyEventArgs> KeyUp_Command { get; }

        private void Handler_Loaded_Command(UserControl payload)
        {
            _view = payload;

            Game.Reset();
            _timerGame.Start();

            var parent = FindParent<Main_View>(_view);
            if (parent != null)
            {
                parent.PreviewKeyDown += _keydownhandler;
                parent.PreviewKeyUp += _keyuphandler;
            }
        }

        private void Handler_Unloaded_Command(RoutedEventArgs payload)
        {
            var parent = FindParent<Main_View>(_view);
            if (parent != null)
            {
                parent.PreviewKeyDown -= _keydownhandler;
                parent.PreviewKeyUp -= _keyuphandler;

                _timerGame.Stop();
            }
            Game.Exit();
            SaveHighScore();
        }

        private void Handler_KeyDown_Command(KeyEventArgs payload)
        {
            if ((payload.Key == Key.Space) && (_keyPressed == Key.Space)) return;

            Game.Level.PressKey(payload.Key);
            _keyPressed = payload.Key;
        }

        private void Handler_KeyUp_Command(KeyEventArgs payload)
        {
            Game.Level.ReleaseKey();
            _keyPressed = Key.None;
        }

        private void Handler_TimerTick(object sender, EventArgs e)
        {
            _view.InvalidateVisual();
        }

        private void LoadHighScore()
        {
            if (!_hiScoreDirectory.Exists) _hiScoreDirectory.Create();
            if (_highscore.Exists) _hiScore = BitConverter.ToUInt32(File.ReadAllBytes(_highscore.FullName), 0);
        }

        private void SaveHighScore()
        {
            File.WriteAllBytes(_highscore.FullName, BitConverter.GetBytes(Game.HiScore));
        }

        public T FindParent<T>(DependencyObject child) where T : DependencyObject
        {
            var parent = VisualTreeHelper.GetParent(child);

            if (parent == null) return null;

            if (parent is T)
                return parent as T;
            else
                return FindParent<T>(parent);
        }
    }
}