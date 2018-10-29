using AwesomeAppIdea.Core.Contracts;
using AwesomeAppIdea.UI.Constants;
using System.Collections.Generic;
using System.Globalization;
using System.Windows;
using System.Windows.Media;

namespace SIG.Model
{
    internal class Game
    {
        public Game(uint hiscore, IClientTheme clientTheme)
        {
            SetTheme(clientTheme);
            SetBoard();
            SetPlayer();
            HiScore = hiscore;
            Level = new Level(Screen.Size, PixelSize, this);
        }

        public Brush _BackgroundBrush;
        public Brush _BrushBomb;
        public Brush _BrushInvader1;
        public Brush _BrushInvader2;
        public Brush _BrushInvader3;
        public Brush _BrushMissile;
        public Brush _BrushPlayer;
        public Brush _BrushSaucer;
        public Brush _BrushShield;
        public Brush _BrushTextGameOver;
        public Brush _BrushTextTitle;
        public Brush _BrushTextValue;
        public Pen _BorderPen;

        public Point _PosTextGameOver;
        public Point _PosTextLevelCompleted;
        public Point _PosTextLevelStart;
        public Point _PosTextRestart;
        public Point _PosTextStartNewLevel;
        public Point _PosTitleHiScore;
        public Point _PosTitleLevel;
        public Point _PosTitleLives;
        public Point _PosTitleScore;
        public Point _PosValueHiScore;
        public Point _PosValueLevel;
        public Point _PosValueLives;
        public Point _PosValueScore;

        public static Typeface _TextTypeFace;
        public FormattedText _TitleScore;
        public FormattedText _TitleHiScore;
        public FormattedText _TitleLives;
        public FormattedText _TitleLevel;
        public FormattedText _TextLevelStart;
        public FormattedText _TextGameOver;
        public FormattedText _TextLevelCompleted;
        public FormattedText _TextRestart;
        public FormattedText _TextStartNewLevel;
        public List<Player> _playerLives;

        public Level Level { get; private set; }
        public Rect Screen { get; private set; }
        public Size PixelSize { get; private set; }
        public uint HiScore { get; private set; }

        private void SetBoard()
        {
            Screen = new Rect(0, 0, 640, 480);
            PixelSize = new Size(3, 3);

            _TextTypeFace = new Typeface(Constants.TEXTFONTNAME);
            _TitleScore = new FormattedText("SCORE:", CultureInfo.CurrentUICulture, FlowDirection.LeftToRight, _TextTypeFace, Constants.TEXTFONTSIZE, _BrushTextTitle);
            _TitleHiScore = new FormattedText("HI-SCORE:", CultureInfo.CurrentUICulture, FlowDirection.LeftToRight, _TextTypeFace, Constants.TEXTFONTSIZE, _BrushTextTitle);
            _TitleLives = new FormattedText("LIVES:", CultureInfo.CurrentUICulture, FlowDirection.LeftToRight, _TextTypeFace, Constants.TEXTFONTSIZE, _BrushTextTitle);
            _TitleLevel = new FormattedText("LEVEL:", CultureInfo.CurrentUICulture, FlowDirection.LeftToRight, _TextTypeFace, Constants.TEXTFONTSIZE, _BrushTextTitle);
            _TextLevelStart = new FormattedText("LEVEL START", CultureInfo.CurrentUICulture, FlowDirection.LeftToRight, _TextTypeFace, Constants.TEXTFONTSIZE, _BrushTextValue);
            _TextGameOver = new FormattedText("GAME OVER", CultureInfo.CurrentUICulture, FlowDirection.LeftToRight, _TextTypeFace, Constants.TEXTFONTSIZE, _BrushTextGameOver);
            _TextLevelCompleted = new FormattedText("LEVEL COMPLETED", CultureInfo.CurrentUICulture, FlowDirection.LeftToRight, _TextTypeFace, Constants.TEXTFONTSIZE, _BrushTextTitle);
            _TextRestart = new FormattedText("ENTER TO START NEW GAME", CultureInfo.CurrentUICulture, FlowDirection.LeftToRight, _TextTypeFace, Constants.TEXTFONTSIZE, _BrushTextValue);
            _TextStartNewLevel = new FormattedText("ENTER TO START NEXT LEVEL", CultureInfo.CurrentUICulture, FlowDirection.LeftToRight, _TextTypeFace, Constants.TEXTFONTSIZE, _BrushTextValue);

            _PosTextGameOver = new Point((Screen.Width - _TextGameOver.Width) / 2, (Screen.Height - _TextGameOver.Height) / 2);
            _PosTextLevelCompleted = new Point((Screen.Width - _TextLevelCompleted.Width) / 2, (Screen.Height - _TextLevelCompleted.Height) / 2);
            _PosTextLevelStart = new Point((Screen.Width - _TextLevelStart.Width) / 2, (Screen.Height - _TextLevelStart.Height) / 2);
            _PosTextRestart = new Point((Screen.Width - _TextRestart.Width) / 2, (Screen.Height - _TextRestart.Height) / 2);
            _PosTextStartNewLevel = new Point((Screen.Width - _TextStartNewLevel.Width) / 2, (Screen.Height - _TextStartNewLevel.Height) / 2);
            _PosTitleHiScore = new Point(468, 5);
            _PosTitleLevel = new Point(540, Screen.Height - 30 + 4);
            _PosTitleLives = new Point(10, Screen.Height - 30 + 4);
            _PosTitleScore = new Point(10, 5);
            _PosValueHiScore = new Point(575, 5);
            _PosValueLevel = new Point(611, Screen.Height - 30 + 4);
            _PosValueLives = new Point(75, Screen.Height - 30 + 4);
            _PosValueScore = new Point(90, 5);
        }

        private void SetTheme(IClientTheme clientTheme)
        {
            _BackgroundBrush = clientTheme.Background;
            _BackgroundBrush.Freeze();
            _BorderPen = clientTheme.BorderPen;
            _BorderPen.Freeze();
            _BrushBomb = clientTheme.Bomb;
            _BrushBomb.Freeze();
            _BrushInvader1 = clientTheme.Invader1;
            _BrushInvader1.Freeze();
            _BrushInvader2 = clientTheme.Invader2;
            _BrushInvader2.Freeze();
            _BrushInvader3 = clientTheme.Invader3;
            _BrushInvader3.Freeze();
            _BrushMissile = clientTheme.Missile;
            _BrushMissile.Freeze();
            _BrushPlayer = clientTheme.Player;
            _BrushPlayer.Freeze();
            _BrushSaucer = clientTheme.Saucer;
            _BrushSaucer.Freeze();
            _BrushShield = clientTheme.Shield;
            _BrushShield.Freeze();
            _BrushTextGameOver = clientTheme.TextGameOver;
            _BrushTextGameOver.Freeze();
            _BrushTextTitle = clientTheme.TextTitle;
            _BrushTextTitle.Freeze();
            _BrushTextValue = clientTheme.TextValue;
            _BrushTextValue.Freeze();
        }

        private void SetPlayer()
        {
            _playerLives = new List<Player>();

            for (int i = 0; i < Constants.TOTALLIVESONSTART; i++)
            {
                _playerLives.Add(new Player(Constants.PATTERNPLAYER, _BrushPlayer, new Size(2, 2), new Point(110 + i * 35, Screen.Height - 16)));
            }
        }

        public void Reset()
        {
            if (Level != null) Level.Exit();
            Level.Start(Constants.TOTALLIVESONSTART);
        }

        public void Exit()
        {
            if (Level != null) Level.Exit();
        }

        public void Draw(DrawingContext drawingcontext)
        {
            drawingcontext.DrawRectangle(_BackgroundBrush, null, Screen);
            Level.Draw(drawingcontext);

            if (Level.Score > HiScore) HiScore = Level.Score;

            drawingcontext.DrawText(_TitleScore, _PosTitleScore);
            drawingcontext.DrawText(new FormattedText(this.Level.Score.ToString("00000"), CultureInfo.CurrentUICulture, FlowDirection.LeftToRight, _TextTypeFace, Constants.TEXTFONTSIZE, _BrushTextValue), _PosValueScore);

            drawingcontext.DrawText(_TitleHiScore, _PosTitleHiScore);
            drawingcontext.DrawText(new FormattedText(this.HiScore.ToString("00000"), CultureInfo.CurrentUICulture, FlowDirection.LeftToRight, _TextTypeFace, Constants.TEXTFONTSIZE, _BrushTextValue), _PosValueHiScore);

            drawingcontext.DrawText(_TitleLives, _PosTitleLives);
            drawingcontext.DrawText(new FormattedText(this.Level.Lives.ToString("0"), CultureInfo.CurrentUICulture, FlowDirection.LeftToRight, _TextTypeFace, Constants.TEXTFONTSIZE, _BrushTextValue), _PosValueLives);

            for (int i = 0; i < Level.Lives; i++)
            {
                _playerLives[i].Draw(drawingcontext);
            }

            drawingcontext.DrawText(_TitleLevel, _PosTitleLevel);
            drawingcontext.DrawText(new FormattedText(this.Level.Number.ToString("00"), CultureInfo.CurrentUICulture, FlowDirection.LeftToRight, _TextTypeFace, Constants.TEXTFONTSIZE, _BrushTextValue), _PosValueLevel);

            drawingcontext.DrawLine(_BorderPen, new Point(0, Screen.Height - 30), new Point(Screen.Width, Screen.Height - 30));
            drawingcontext.DrawRectangle(null, _BorderPen, Screen);
        }
    }
}