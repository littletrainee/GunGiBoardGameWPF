//using System.Drawing;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace GunGiBoardGameWPF.GameHolder.Koma
{
	public class Koma
	{
		public Point CurrentPosition { get; set; }
		public Ellipse KomaColor { get; set; } // 駒的所屬顏色
		public Ellipse InnerTextBackground { get; set; } // 駒的文字顯示底色
		public TextBlock TextBlock { get; set; } // 駒文字繪製的區塊
		private Point Center { get; set; }
		public Point[][][] MoveableRange { get; set; }



		public void SetKomaPorperty(string name, Brush color)
		{
			this.KomaColor = new Ellipse
			{
				Width = Constant.KOMA_SIZE,
				Height = Constant.KOMA_SIZE,
				Fill = color,
				Stroke = Brushes.Black,
				StrokeThickness = 1,
				RenderTransformOrigin = new Point(0.5, 0.5),
			};

			this.InnerTextBackground = new Ellipse
			{
				Width = Constant.KOMA_SIZE - 12.5,
				Height = Constant.KOMA_SIZE - 12.5,
				Fill = Brushes.White,
				Stroke = Brushes.Black,
				StrokeThickness = 1,
				RenderTransformOrigin = new Point(0.5, 0.5),
			};

			this.TextBlock = new TextBlock
			{
				Text = name,
				FontFamily = new FontFamily(Constant.FONT_PATH),
				FontWeight = FontWeights.ExtraBold,
				FontSize = 20
			};
		}

		/// <summary>
		/// 設定座標與是否旋轉文字，並繪製在畫布上
		/// </summary>
		/// <param name="point">座標來源</param>
		/// <param name="canvas">目標畫布</param>
		/// <param name="rotate">是否要旋轉，true旋轉，false則否</param>
		public void SetCoordinate(Point point, ref Canvas canvas, bool rotate)
		{
			Canvas.SetLeft(this.KomaColor, point.X);
			Canvas.SetTop(this.KomaColor, point.Y);
			canvas.Children.Add(this.KomaColor);
			Canvas.SetLeft(this.InnerTextBackground, point.X + 6.25);
			Canvas.SetTop(this.InnerTextBackground, point.Y + 6.25);
			canvas.Children.Add(this.InnerTextBackground);
			if (rotate)
			{
				this.TextBlock.RenderTransform = new RotateTransform(180);
				Canvas.SetLeft(this.TextBlock, point.X + 30);
				Canvas.SetTop(this.TextBlock, point.Y + 31);
			}
			else
			{
				Canvas.SetLeft(this.TextBlock, point.X + 10);
				Canvas.SetTop(this.TextBlock, point.Y + 9);
			}
			canvas.Children.Add(this.TextBlock);
			this.Center = new Point()
			{
				X = point.X + this.KomaColor.Width * this.KomaColor.RenderTransformOrigin.X,
				Y = point.Y + this.KomaColor.Height * this.KomaColor.RenderTransformOrigin.Y,
			};
		}

		public bool OnKoma(Point p)
		{
			return Math.Sqrt(Math.Pow(p.X - this.Center.X, 2) + Math.Pow(p.Y - this.Center.Y, 2)) <= this.KomaColor.Width / 2 ? true : false;
		}

		public void Hide()
		{
			this.KomaColor.Visibility = Visibility.Hidden;
			this.InnerTextBackground.Visibility = Visibility.Hidden;
			this.TextBlock.Visibility = Visibility.Hidden;
		}

		public void Show()
		{
			this.KomaColor.Visibility = Visibility.Visible;
			this.InnerTextBackground.Visibility = Visibility.Visible;
			this.TextBlock.Visibility = Visibility.Visible;
		}
	}
}
