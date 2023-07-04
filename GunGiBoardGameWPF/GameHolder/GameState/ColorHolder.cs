using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace GunGiBoardGameWPF.GameHolder.GameState
{
	/// <summary>
	/// ColorHolder 物件，控制當前的執駒權、玩家顏色與顏色選擇
	/// </summary>
	public class ColorHolder
	{
		private TextBlock Title { get; set; }
		public Koma.Koma WhiteKoma { get; set; }
		public Koma.Koma BlackKoma { get; set; }
		public Brush Own { get; set; }
		public Brush Turn { get; set; }



		/// <summary>
		/// 初始化 ColorHolder物件
		/// </summary>
		/// <param name="canvas">Canvas的參考來源</param>
		public ColorHolder(ref Canvas canvas)
		{
			FontFamily FF = new FontFamily(Constant.FONT_PATH);
			// 標題文字
			this.Title = new TextBlock()
			{
				Text = "請選擇顏色",
				FontFamily = FF,
				FontWeight = FontWeights.ExtraBold,
				FontSize = 60,
			};
			Canvas.SetLeft(this.Title, Constant.COLOR_AND_LEVEL_TITLE_X);
			Canvas.SetTop(this.Title, Constant.TITLE_Y);
			canvas.Children.Add(this.Title);


			// 白駒
			this.WhiteKoma = new Koma.Koma()
			{
				TextBlock = new TextBlock()
				{
					Text = "帥",
					FontFamily = FF,
					FontWeight = FontWeights.ExtraBold,
					FontSize = 20,
				},
				KomaColor = new Ellipse()
				{
					Width = Constant.KOMA_SIZE,
					Height = Constant.KOMA_SIZE,
					Fill = Brushes.White,
					Stroke = Brushes.Black,
					StrokeThickness = 1,
					RenderTransformOrigin = new Point(0.5, 0.5),
				},
				InnerTextBackground = new Ellipse()
				{
					Width = Constant.KOMA_SIZE - 12.5,
					Height = Constant.KOMA_SIZE - 12.5,
					Fill = Brushes.White,
					Stroke = Brushes.Black,
					StrokeThickness = 1,
					RenderTransformOrigin = new Point(0.5, 0.5),
				}
			};
			this.WhiteKoma.SetCoordinate(new Point(452, 384), ref canvas, false);

			// 黑駒
			this.BlackKoma = new Koma.Koma()
			{
				TextBlock = new TextBlock()
				{
					Text = "帥",
					FontFamily = FF,
					FontWeight = FontWeights.ExtraBold,
					FontSize = 20,
				},
				KomaColor = new Ellipse()
				{
					Width = Constant.KOMA_SIZE,
					Height = Constant.KOMA_SIZE,
					Fill = Brushes.Black,
					Stroke = Brushes.Black,
					StrokeThickness = 1,
					RenderTransformOrigin = new Point(0.5, 0.5),
				},
				InnerTextBackground = new Ellipse()
				{
					Width = Constant.KOMA_SIZE - 12.5,
					Height = Constant.KOMA_SIZE - 12.5,
					Fill = Brushes.White,
					Stroke = Brushes.Black,
					StrokeThickness = 1,
					RenderTransformOrigin = new Point(0.5, 0.5),
				}
			};
			this.BlackKoma.SetCoordinate(new Point(532, 384), ref canvas, false);
		}


		public void Hide()
		{
			this.Title.Visibility = Visibility.Hidden;
			this.WhiteKoma.Hide();
			this.BlackKoma.Hide();
		}
	}
}
