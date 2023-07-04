using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace GunGiBoardGameWPF.GameHolder.GameState
{
	public class ArrangementHolder
	{
		private TextBlock Title { get; set; }
		public Arrangement RecommendArrangement { get; set; }
		public Arrangement ManualArrangement { get; set; }
		public Enum.Arrangement ArrangementBy { get; set; }


		public ArrangementHolder(ref Canvas canvas)
		{
			FontFamily FF = new FontFamily(Constant.FONT_PATH);
			this.Title = new TextBlock()
			{
				Text = "請選擇推薦或自訂布陣",
				FontFamily = FF,
				FontWeight = FontWeights.ExtraBold,
				FontSize = 60,
			};
			Canvas.SetLeft(this.Title, Constant.ARRANGEMENT_TITLE_X);
			Canvas.SetTop(this.Title, Constant.TITLE_Y);
			canvas.Children.Add(this.Title);

			this.RecommendArrangement = new Arrangement()
			{
				ArrangementSelect = Enum.Arrangement.RECOMMEND,
				Background = new System.Windows.Shapes.Rectangle()
				{
					Width = Constant.ARRANGEMENT_BUTTON_SIZE,
					Height = Constant.ARRANGEMENT_BUTTON_SIZE,
					Fill = Brushes.White,
					Stroke = Brushes.Black,
					StrokeThickness = 1,
				},
				TextBlock = new TextBlock()
				{
					Text = "推薦布陣",
					FontFamily = FF,
					FontWeight = FontWeights.ExtraBold,
					FontSize = 20,
				},
				Position = new System.Drawing.Point(Constant.RECOMMENDED_ARRANGEMENT_BUTTON_X, Constant.ARRANGEMENT_BUTTON_Y),
			};
			this.RecommendArrangement.SetPosition(ref canvas);

			this.ManualArrangement = new Arrangement()
			{
				ArrangementSelect = Enum.Arrangement.MANUAL,
				Background = new System.Windows.Shapes.Rectangle()
				{
					Width = Constant.ARRANGEMENT_BUTTON_SIZE,
					Height = Constant.ARRANGEMENT_BUTTON_SIZE,
					Fill = Brushes.Gray,
					Stroke = Brushes.Black,
					StrokeThickness = 1,
				},
				TextBlock = new TextBlock()
				{
					Text = "自訂布陣",
					FontFamily = FF,
					FontWeight = FontWeights.ExtraBold,
					FontSize = 20,
				},
				Position = new System.Drawing.Point(Constant.MANUAL_ARRANGEMENT_BUTTON_X, Constant.ARRANGEMENT_BUTTON_Y),
			};
			this.ManualArrangement.SetPosition(ref canvas);
		}
	}
}
