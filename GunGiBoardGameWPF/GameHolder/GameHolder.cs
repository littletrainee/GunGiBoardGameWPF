using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace GunGiBoardGameWPF.GameHolder
{
	public class GameHolder
	{
		private GameState.GameState GameState { get; set; }

		public Player Player1 { get; set; }
		public Player Player2 { get; set; }
		public Board.Board Board { get; set; }
		public Timer PrepareForGaming { get; set; }
		public Timer Player1Timer { get; set; }
		public Timer Player2Timer { get; set; }

		public Canvas Canvas = new Canvas();


		public GameHolder()
		{
			this.GameState = new GameState.GameState(ref this.Canvas);
		}


		public async void PlayerSelect(object sender, MouseButtonEventArgs e)
		{
			Point p = e.GetPosition(this.Canvas);
			Player p1,p2;
			switch (this.GameState.Phase)
			{
				case Enum.Phase.SELECT_COLOR:
					this.GameState.SelectColor(p);

					// 延遲0.5秒再繼續執行，先返為主線程待0.5秒後再回到這邊
					await Task.Delay(Constant.DELAY);
					p1 = this.Player1;
					p2 = this.Player2;
					this.GameState.SetColor(ref p1, ref p2, ref this.Canvas);
					this.Player1 = p1;
					this.Player2 = p2;
					break;
				case Enum.Phase.SELECT_LEVEL:
					this.GameState.SelectLevel(p);
					// 延遲0.5秒再繼續執行，先返為主線程待0.5秒後再回到這邊
					await Task.Delay(Constant.DELAY);
					p1 = this.Player1;
					p2 = this.Player2;
					this.GameState.SetLevel(ref this.Canvas);
					this.Player1 = p1;
					this.Player2 = p2;
					break;
				case Enum.Phase.SELECT_RECOMMEND_OR_MANUAL_ARRANGEMENT:
					this.GameState.SelectRecommendOrManualArrangement(p);
					await Task.Delay(Constant.DELAY);
					this.PrepareForGaming = new Timer(Constant.PREPARE_FOR_GAMING_TIME, new Point(0, 0), ref this.Canvas, Enum.Phase.COUNTDOWN_FOR_GAMING);
					this.GameState.Phase = Enum.Phase.COUNTDOWN_FOR_GAMING;
					this.PrepareForGaming.CountDown(Enum.Phase.COUNTDOWN_FOR_GAMING);
					this.BeginCountDownForGaming();
					break;
			}
		}

		/// <summary>
		/// 由另一個線程監控this.PrepareForGaming.TextBlock.Text的值是否為"0"
		/// </summary>
		private async void BeginCountDownForGaming()
		{
			// 迴圈持續依據
			bool loop = true;
			while (loop)
			{
				// 使用另一個線程來監控
				await Task.Run(() =>
				{
					Application.Current.Dispatcher.Invoke(() =>
					{
						Debug.Write($"This.PrepareForGaming.TextBlock.Text is {this.PrepareForGaming.TextBlock.Text}, ");
						// 當監控的數值達到目標數值時
						if (this.PrepareForGaming.TextBlock.Text == "0")
						{
							Debug.WriteLine("InitilizationEachObject");
							this.PrepareForGaming.TextBlock.Visibility = Visibility.Hidden;
							loop = false;
						}
						else
						{
							Debug.WriteLine("continue Check");
						}
					});
				});
			}
			// 延遲0.5秒後再進行後續的物件初始化
			await Task.Delay(Constant.DELAY);
			this.InitilizationEachObject();
		}

		/// <summary>
		/// 初始化棋盤、雙方的駒台、雙方的棋鐘
		/// </summary>
		public void InitilizationEachObject()
		{
			this.Board = new Board.Board(ref this.Canvas);
			this.Player1.SetKomaDaiPosition(this.GameState.LevelHolder.CurrentLevel, ref this.Canvas);
			this.Player2.SetKomaDaiPosition(this.GameState.LevelHolder.CurrentLevel, ref this.Canvas);

		}
	}
}

