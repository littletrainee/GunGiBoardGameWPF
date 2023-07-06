using System;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

using GunGiBoardGameWPF.GameHolder.Enum;

namespace GunGiBoardGameWPF.GameHolder.GameState
{
	public class GameState
	{
		public ColorHolder ColorHolder { get; set; }
		public LevelHolder LevelHolder { get; set; }
		public ArrangementHolder ArrangementHolder { get; set; }
		public Phase Phase { get; set; }

		/// <summary>
		/// 初始化建立GameState與設定當前程式階段，
		/// </summary>
		/// <param name="canvas">要繪製的畫布參考</param>
		public GameState(ref Canvas canvas)
		{
			this.Phase = Phase.SELECT_COLOR;
			this.ColorHolder = new ColorHolder(ref canvas);
		}

		/// <summary>
		/// 延遲切換階段，讓程式進入延遲階段，帶0.5秒後再進入要進入的階段
		/// </summary>
		/// <param name="phase">要進入的目標階段</param>
		public void DelayChangePhaseTo(Phase phase)
		{
			this.Phase = phase switch
			{
				Phase.SELECT_LEVEL or Phase.SELECT_RECOMMEND_OR_MANUAL_ARRANGEMENT => Phase.BEFORE_GAMING_BUFFER_ZONE,
				_ => Phase.GAMING_BUFFER_ZONE,
			};
			ThreadPool.QueueUserWorkItem((state) =>
			{
				Thread.Sleep(TimeSpan.FromSeconds(0.5));
				this.Phase = (Phase)state;
			}, phase);

		}

		/// <summary>
		///	玩家選擇顏色 
		/// </summary>
		/// <param name="mousePosition">滑鼠當前在畫面上的位置</param>
		/// <param name="player1">玩家1物件</param>
		/// <param name="player2">玩家2物件</param>
		/// <param name="canvas">畫布物件</param>
		public void SelectColor(Point mousePosition)
		{
			if (this.ColorHolder.WhiteKoma.OnKoma(mousePosition))
			{
				this.ColorHolder.Own = this.ColorHolder.WhiteKoma.KomaColor.Fill;
				this.ColorHolder.Hide();
				DelayChangePhaseTo(Phase.SELECT_LEVEL);
			}
			else if (this.ColorHolder.BlackKoma.OnKoma(mousePosition))
			{
				this.ColorHolder.Own = this.ColorHolder.BlackKoma.KomaColor.Fill;
				this.ColorHolder.Hide();
				DelayChangePhaseTo(Phase.SELECT_LEVEL);
			}
		}


		/// <summary>
		/// 非同步執行0.5秒後在設定雙方的顏色並初始化LevelHolder
		/// </summary>
		/// <param name="player1">玩家1物件</param>
		/// <param name="player2">玩家2物件</param>
		/// <param name="canvas">畫布物件</param>
		public void SetColor(ref Player player1, ref Player player2, ref Canvas canvas)
		{
			if (this.ColorHolder.Own == Brushes.Black)
			{
				player1 = new Player(Brushes.Black, true);
				player2 = new Player(Brushes.White, false);
			}
			else
			{
				player1 = new Player(Brushes.White, true);
				player2 = new Player(Brushes.Black, false);
			}
			this.LevelHolder = new LevelHolder(ref canvas);

		}

		/// <summary>
		/// 玩家選擇階級
		/// </summary>
		/// <param name="mousePosition">滑鼠當前在畫面上的位置</param>
		public void SelectLevel(Point mousePosition)
		{
			if (this.LevelHolder.BeginnerLevel.OnBlock(mousePosition))
			{
				this.LevelHolder.CurrentLevel = this.LevelHolder.BeginnerLevel.Code;
				this.LevelHolder.Hide();
			}
			else if (this.LevelHolder.ElementaryLevel.OnBlock(mousePosition))
			{
				this.LevelHolder.CurrentLevel = this.LevelHolder.ElementaryLevel.Code;
				this.LevelHolder.Hide();
			}
			else if (this.LevelHolder.IntermediateLevle.OnBlock(mousePosition))
			{
				this.LevelHolder.CurrentLevel = this.LevelHolder.IntermediateLevle.Code;
				this.LevelHolder.Hide();
			}
			else if (this.LevelHolder.AdvancedLevel.OnBlock(mousePosition))
			{
				this.LevelHolder.CurrentLevel = this.LevelHolder.AdvancedLevel.Code;
				this.LevelHolder.Hide();
			}
		}

		/// <summary>
		/// 非同步執行0.5秒後設定選擇的遊玩階級並依照選擇的階級判斷是否初始化ArrangementHolder物件
		/// </summary>
		/// <param name="player1">玩家1物件</param>
		/// <param name="player2">玩家2物件</param>
		/// <param name="canvas">畫布物件</param>
		public void SetLevel(ref Canvas canvas)
		{
			if (this.LevelHolder.CurrentLevel == Enum.Level.BEGINNER || this.LevelHolder.CurrentLevel == Enum.Level.ELEMENTARY)
			{
				this.DelayChangePhaseTo(Phase.SELECT_RECOMMEND_OR_MANUAL_ARRANGEMENT);
				this.ArrangementHolder = new ArrangementHolder(ref canvas);
			}
			else
			{
				this.ArrangementHolder.ArrangementBy = Enum.Arrangement.MANUAL;
				this.DelayChangePhaseTo(Phase.COUNTDOWN_FOR_GAMING);
			}

			if (this.LevelHolder.CurrentLevel == Enum.Level.ADVANCED)
			{
				this.LevelHolder.MaxLayer = 3;
			}
			else
			{
				this.LevelHolder.MaxLayer = 2;
			}

			this.SetFirst();
		}

		/// <summary>
		/// 設定先手與最初的執駒權
		/// </summary>
		private void SetFirst()
		{
			this.ColorHolder.Own = Brushes.White;
			this.ColorHolder.Turn = Brushes.White;
		}

		/// <summary>
		/// 若玩家選擇入門或初階時選取推薦布陣或是自訂布陣選項的判斷
		/// </summary>
		/// <param name="point"></param>
		public void SelectRecommendOrManualArrangement(Point point)
		{
			if (this.ArrangementHolder.RecommendArrangement.OnBlock(point))
			{
				this.ArrangementHolder.ArrangementBy = Enum.Arrangement.RECOMMEND;
				this.ArrangementHolder.Hide();
			}
			else if (this.ArrangementHolder.ManualArrangement.OnBlock(point))
			{
				this.ArrangementHolder.ArrangementBy = Enum.Arrangement.MANUAL;
				this.ArrangementHolder.Hide();
			}
		}
	}
}

