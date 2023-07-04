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
					this.GameState.SetLevel(ref p1, ref p2, ref this.Canvas);
					this.Player1 = p1;
					this.Player2 = p2;
					this.Board = new Board.Board(ref this.Canvas);
					break;
				case Enum.Phase.SELECT_RECOMMEND_OR_MANUAL_ARRANGEMENT:
					Debug.WriteLine("check");
					break;
			}
		}
	}
}

