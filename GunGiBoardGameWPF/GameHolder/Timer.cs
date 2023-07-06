using System;
using System.Threading.Channels;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
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

		/// <summary>
		///	初始化計時器物件 
		/// </summary>
		/// <param name="amontOfTime">倒數的時間長度</param>
		/// <param name="point">文字的位置</param>
		/// <param name="canvas">目標畫布</param>
		/// <param name="beforeGaming">是否是遊戲開始前的計時</param>
		public Timer(int amontOfTime, Point point, ref Canvas canvas, TimerChoice timerChoice)
		{

			this.RemainingTime = amontOfTime;
			this.StopCountDown = Channel.CreateBounded<bool>(1);
			this.CurrentCoordinate = point;
			if (timerChoice == TimerChoice.BEFORE_GAMING)
			{
				this.TextBlock = new TextBlock()
				{
					Text = this.RemainingTime.ToString(),
					FontFamily = new FontFamily(Constant.FONT_PATH),
					FontWeight = FontWeights.ExtraBold,
					FontSize = 100,
				};
				Canvas.SetLeft(this.TextBlock, this.CurrentCoordinate.X + 475);
				Canvas.SetTop(this.TextBlock, this.CurrentCoordinate.Y + 325);
				canvas.Children.Add(this.TextBlock);
			}
			else
			{
				this.Background = new Rectangle()
				{
					Width = Constant.TIMER_SIZE,
					Height = Constant.TIMER_SIZE,
					Fill = CustmerColor.TimerPauseColor,
					Stroke = Brushes.Black,
					StrokeThickness = 1,
				};
				Canvas.SetLeft(this.Background, this.CurrentCoordinate.X);
				Canvas.SetTop(this.Background, this.CurrentCoordinate.Y);
				canvas.Children.Add(this.Background);

				this.TextBlock = new TextBlock()
				{
					Text = this.GetRemainingTimeString(),
					FontFamily = new FontFamily(Constant.FONT_PATH),
					FontWeight = FontWeights.ExtraBold,
					FontSize = 30
				};
				if (timerChoice == TimerChoice.OPPONENT)
				{
					this.TextBlock.RenderTransform = new RotateTransform(180);
					Canvas.SetLeft(this.TextBlock, this.CurrentCoordinate.X + 90);
					Canvas.SetTop(this.TextBlock, this.CurrentCoordinate.Y + 75);
				}
				else
				{
					Canvas.SetLeft(this.TextBlock, this.CurrentCoordinate.X + 30);
					Canvas.SetTop(this.TextBlock, this.CurrentCoordinate.Y + 40);
				}
				canvas.Children.Add(this.TextBlock);
			}
		}

		/// <summary>
		/// 將本身的RemainingTime的數值轉換為其中所顯示的文字
		/// </summary>
		/// <returns></returns>
		private string GetRemainingTimeString()
		{
			this.RemainingTime--;
			if (this.RemainingTime < 60)
			{
				if (this.RemainingTime < 10)
				{
					return "0:0" + this.RemainingTime.ToString();
				}
				else
				{
					return "0:" + this.RemainingTime.ToString();
				}
			}
			else
			{
				int m = this.RemainingTime / 60;
				int s = this.RemainingTime % 60;
				return m.ToString() + ":" + s.ToString();
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
					if (this.StopCountDown.Reader.TryPeek(out bool value))//|| this.RemainingTime == 0 && phase == Phase.COUNTDOWN_FOR_GAMING)
					{
						loop = false;
					}
					else if (phase == Phase.COUNTDOWN_FOR_GAMING)
					{
						this.RemainingTime--;
						this.TextBlock.Text = this.RemainingTime.ToString();
					}
					else
					{
						this.TextBlock.Text = GetRemainingTimeString();
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
