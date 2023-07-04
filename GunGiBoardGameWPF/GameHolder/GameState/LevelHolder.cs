using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace GunGiBoardGameWPF.GameHolder.GameState
{
	public class LevelHolder
	{
		private TextBlock Title { get; set; }
		public Level.Level BeginnerLevel { get; set; }
		public Level.Level ElementaryLevel { get; set; }
		public Level.Level IntermediateLevle { get; set; }
		public Level.Level AdvancedLevel { get; set; }
		public Enum.Level CurrentLevel { get; set; }
		public int MaxLayer { get; set; }

		public LevelHolder(ref Canvas canvas)
		{
			FontFamily FF = new FontFamily("H:\\GoGit\\GunGi\\GunGiBoardGameGUI\\font\\NotoSansTC-Bold.otf");
			Title = new TextBlock()
			{
				Text = "請選擇階級",
				FontFamily = FF,
				FontWeight = FontWeights.ExtraBold,
				FontSize = 60,
			};
			Canvas.SetLeft(this.Title, Constant.COLOR_AND_LEVEL_TITLE_X);
			Canvas.SetTop(this.Title, Constant.TITLE_Y);
			canvas.Children.Add(Title);

			this.BeginnerLevel = new Level.Level()
			{
				Code = Enum.Level.BEGINNER,
				Background = new Rectangle()
				{
					Width = Constant.LEVEL_BLOCK_SIZE,
					Height = Constant.LEVEL_BLOCK_SIZE,
					Fill = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255)),
					Stroke = Brushes.Black,
					StrokeThickness = 1,
				},
				TextBlock = new TextBlock()
				{
					Text = "入門",
					FontFamily = FF,
					FontWeight = FontWeights.ExtraBold,
					FontSize = 20,
				},
				Position = new System.Drawing.Point(Constant.LEVEL_BEGINNER_X, Constant.LEVEL_Y),
			};
			this.BeginnerLevel.SetPosition(ref canvas);

			this.ElementaryLevel = new Level.Level()
			{
				Code = Enum.Level.ELEMENTARY,
				Background = new Rectangle()
				{
					Width = Constant.LEVEL_BLOCK_SIZE,
					Height = Constant.LEVEL_BLOCK_SIZE,
					Fill = new SolidColorBrush(Color.FromArgb(255, 170, 170, 170)),
					Stroke = Brushes.Black,
					StrokeThickness = 1,
				},
				TextBlock = new TextBlock()
				{
					Text = "初級",
					FontFamily = FF,
					FontWeight = FontWeights.ExtraBold,
					FontSize = 20,
				},
				Position = new System.Drawing.Point(Constant.LEVEL_ELEMENTARY_X, Constant.LEVEL_Y),
			};
			this.ElementaryLevel.SetPosition(ref canvas);

			this.IntermediateLevle = new Level.Level()
			{
				Code = Enum.Level.INTERMEDIATE,
				Background = new Rectangle()
				{
					Width = Constant.LEVEL_BLOCK_SIZE,
					Height = Constant.LEVEL_BLOCK_SIZE,
					Fill = new SolidColorBrush(Color.FromArgb(255, 85, 85, 85)),
					Stroke = Brushes.Black,
					StrokeThickness = 1,
				},
				TextBlock = new TextBlock()
				{
					Text = "中級",
					FontFamily = FF,
					FontWeight = FontWeights.ExtraBold,
					FontSize = 20,
					Foreground = Brushes.White,
				},
				Position = new System.Drawing.Point(Constant.LEVEL_INTERMEDIATE_X, Constant.LEVEL_Y),
			};
			this.IntermediateLevle.SetPosition(ref canvas);

			this.AdvancedLevel = new Level.Level()
			{
				Code = Enum.Level.ADVANCED,
				Background = new Rectangle()
				{
					Width = Constant.LEVEL_BLOCK_SIZE,
					Height = Constant.LEVEL_BLOCK_SIZE,
					Fill = Brushes.Black,
					Stroke = Brushes.Black,
					StrokeThickness = 1,
				},
				TextBlock = new TextBlock()
				{
					Text = "高級",
					FontFamily = FF,
					FontWeight = FontWeights.ExtraBold,
					FontSize = 20,
					Foreground = Brushes.White,
				},
				Position = new System.Drawing.Point(Constant.LEVEL_ADVANCED_X, Constant.LEVEL_Y),
			};
			this.AdvancedLevel.SetPosition(ref canvas);
		}

		public void Hide()
		{
			this.Title.Visibility = Visibility.Hidden;
			this.BeginnerLevel.Hide();
			this.ElementaryLevel.Hide();
			this.IntermediateLevle.Hide();
			this.AdvancedLevel.Hide();
		}
	}
}
