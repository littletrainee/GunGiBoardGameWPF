using System;
using System.Threading.Channels;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;

using GunGiBoardGameWPF.GameHolder.Enum;

namespace GunGiBoardGameWPF.GameHolder
{
	public class Timer
	{
		public int RemainingTime { get; set; }
		public Rectangle Background { get; set; }
		public Channel<bool> StopCountDown { get; set; }
		public TextBlock TextBlock { get; set; }
		public Point CurrentCoordinate { get; set; }

		public Timer(int amontOfTime, Point point, ref Canvas canvas, Phase phase)
		{

			this.RemainingTime = amontOfTime;
			this.StopCountDown = Channel.CreateBounded<bool>(1);
			this.CurrentCoordinate = point;
			if (phase == Phase.COUNTDOWN_FOR_GAMING)
			{
				this.TextBlock = new TextBlock()
				{
					Text = this.RemainingTime.ToString(),
					FontFamily = new System.Windows.Media.FontFamily(Constant.FONT_PATH),
					FontWeight = FontWeights.ExtraBold,
					FontSize = 100,
				};
				Canvas.SetLeft(this.TextBlock, this.CurrentCoordinate.X + 475);
				Canvas.SetTop(this.TextBlock, this.CurrentCoordinate.Y + 325);
				canvas.Children.Add(this.TextBlock);
			}
		}

		/// <summary>
		/// 非同步的方式控制棋鐘的剩餘時間
		/// </summary>
		public async void CountDown(Phase phase)
		{
			bool loop = true;
			while (loop)
			{
				Application.Current.Dispatcher.Invoke(() =>
				{
					if (this.StopCountDown.Reader.TryPeek(out bool value) || this.TextBlock.Text == "0" && phase == Phase.COUNTDOWN_FOR_GAMING)
					{
						loop = false;
					}
					else
					{
						int temp = int.Parse(this.TextBlock.Text);
						temp--;
						this.TextBlock.Text = temp.ToString();
					}
				});
				if (loop)
				{
					await Task.Delay(TimeSpan.FromSeconds(1));
				}
			}
		}
	}
}
