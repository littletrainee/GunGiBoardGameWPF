using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

using GunGiBoardGameWPF.GameHolder.Koma.MoveableRange;

namespace GunGiBoardGameWPF.GameHolder
{
	/// <summary>
	/// 玩家物件
	/// </summary>
	public class Player
	{
		List<List<Koma.Koma>> KomaDai { get; set; }
		Rectangle KomaDaiBackground { get; set; }
		Point KomaDaiCoordinate { get; set; }
		Point KomaOnKomaDaiCoorDinate { get; set; }
		public Brush SelfColor { get; set; }
		bool IsOwn { get; set; }
		bool IsSetSuI { get; set; }
		bool IsSuMi { get; set; }
		int MaxRange { get; set; }
		bool SelectBouShou { get; set; }



		public Player(Brush selfColor, bool isOwn)
		{
			this.SelfColor = selfColor;
			this.IsOwn = isOwn;
		}

		/// <summary>
		/// 設定駒台的位置
		/// </summary>
		/// <param name="level">玩家選擇的階級</param>
		/// <param name="canvas">目標畫布</param>
		public void SetKomaDaiPosition(Enum.Level level, ref Canvas canvas)
		{
			if (this.IsOwn)
			{
				this.KomaDaiCoordinate = new Point()
				{
					X = Constant.OWN_KOMADAI_X,
					Y = Constant.OWN_KOMADAI_Y,
				};
				this.KomaOnKomaDaiCoorDinate = new Point()
				{
					X = Constant.KOMA_ON_OWN_KOMADAI_X,
					Y = Constant.KOMA_ON_OWN_KOMADAI_Y,
				};
			}
			else
			{
				this.KomaDaiCoordinate = new Point()
				{
					X = Constant.OPPONENT_KOMADAI_X,
					Y = Constant.OPPONENT_KOMADAI_Y,
				};
				this.KomaOnKomaDaiCoorDinate = new Point()
				{
					X = Constant.KOMA_ON_OPPONENT_KOMADAI_X,
					Y = Constant.KOMA_ON_OPPONENT_KOMADAI_Y,
				};
			}
			this.KomaDaiBackground = new Rectangle()
			{
				Width = Constant.KOMADAI_SIZE,
				Height = Constant.KOMADAI_SIZE,
				Fill = CustmerColor.BoardColor,
				Stroke = Brushes.Black,
				StrokeThickness = 1,
			};
			Canvas.SetLeft(this.KomaDaiBackground, this.KomaDaiCoordinate.X);
			Canvas.SetTop(this.KomaDaiBackground, this.KomaDaiCoordinate.Y);
			canvas.Children.Add(this.KomaDaiBackground);
			this.KomaDai = new List<List<Koma.Koma>>();
			this.SetKomaDai(level, ref canvas);
		}

		/// <summary>
		/// 設定駒台
		/// </summary>
		/// <param name="level">選擇的等級</param>
		/// <param name="canvas">目標畫布</param>
		private void SetKomaDai(Enum.Level level, ref Canvas canvas)
		{
			string source = (level) switch
			{
				Enum.Level.BEGINNER => Constant.ALLKOMA.Substring(0, Constant.ALLKOMA.IndexOf("兵") + 1),
				Enum.Level.ELEMENTARY => Constant.ALLKOMA.Substring(0,Constant.ALLKOMA.IndexOf("弓") + 1),
				_ => Constant.ALLKOMA,
			};

			int distance = Constant.KOMA_SIZE +1;

			if (!this.IsOwn)
			{
				distance *= -1;
				this.MaxRange = 3;
			}
			else
			{
				this.MaxRange = 7;
			}

			int column = 0;
			int row = 0;

			FontFamily FF = new FontFamily(Constant.FONT_PATH);


			foreach (char s in source)
			{
				int c = (int)this.KomaOnKomaDaiCoorDinate.X +distance *column;
				int r = (int)this.KomaOnKomaDaiCoorDinate.Y +distance *row;
				Koma.Koma tempKoma = new Koma.Koma()
				{
					TextBlock = new TextBlock()
					{
						Text = s.ToString(),
						FontFamily = FF,
						FontWeight = FontWeights.ExtraBold,
						FontSize = 20,
					},
					KomaColor = new Ellipse()
					{
						Width = Constant.KOMA_SIZE,
						Height = Constant.KOMA_SIZE,
						Fill = this.SelfColor,
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
				if (this.IsOwn)
				{
					tempKoma.SetCoordinate(new Point(c, r), ref canvas, false);
				}
				else
				{
					tempKoma.SetCoordinate(new Point(c, r), ref canvas, true);
				}

				int repeat = 0;
				switch (s.ToString())
				{
					case "帥":
						tempKoma.MoveableRange = MoveableRange.MoveableRange帥();
						repeat = 1;
						break;
					case "大":
						tempKoma.MoveableRange = MoveableRange.MoveableRange大();
						repeat = 1;
						break;
					case "中":
						tempKoma.MoveableRange = MoveableRange.MoveableRange中();
						repeat = 1;
						break;
					case "小":
						tempKoma.MoveableRange = MoveableRange.MoveableRange小();
						repeat = 2;
						break;
					case "侍":
						tempKoma.MoveableRange = MoveableRange.MoveableRange侍();
						repeat = 2;
						break;

					case "忍":
						tempKoma.MoveableRange = MoveableRange.MoveableRange忍();
						repeat = 2;
						break;
					case "槍":
						tempKoma.MoveableRange = MoveableRange.MoveableRange槍();
						repeat = 3;
						break;
					case "砦":
						tempKoma.MoveableRange = MoveableRange.MoveableRange砦();
						repeat = 2;
						break;
					case "馬":
						tempKoma.MoveableRange = MoveableRange.MoveableRange馬();
						repeat = 2;
						break;
					case "兵":
						tempKoma.MoveableRange = MoveableRange.MoveableRange兵();
						repeat = 4;
						break;

					case "弓":
						tempKoma.MoveableRange = MoveableRange.MoveableRange弓();
						repeat = 2;
						break;
					case "砲":
						tempKoma.MoveableRange = MoveableRange.MoveableRange砲();
						repeat = 1;
						break;
					case "筒":
						tempKoma.MoveableRange = MoveableRange.MoveableRange筒();
						repeat = 1;
						break;
					case "謀":
						tempKoma.MoveableRange = MoveableRange.MoveableRange謀();
						repeat = 1;
						break;
				}

				List<Koma.Koma> tempKomaList = new List<Koma.Koma>{};
				for (int i = 0; i < repeat; i++)
				{
					tempKomaList.Add(tempKoma);
				}
				this.KomaDai.Add(tempKomaList);

				if (column < 3)
				{
					column++;
				}
				else
				{
					row++;
					column = 0;
				}
			}
		}
	}
}
