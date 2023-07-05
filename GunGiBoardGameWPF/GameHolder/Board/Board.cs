using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace GunGiBoardGameWPF.GameHolder.Board
{
	public class Board
	{
		public Rectangle BaseColor { get; set; }
		public Dictionary<Point, Block> Blocks { get; set; }

		/// <summary>
		/// 初始化Board物件，並繪製到canvas上
		/// </summary>
		/// <param name="canvas">畫布物件</param>
		public Board(ref Canvas canvas)
		{
			this.BaseColor = new Rectangle()
			{
				Width = Constant.BOARD_WIDTH,
				Height = Constant.BOARD_HEIGHT,
				Fill = Brushes.Black,
				Stroke = Brushes.Black,
				StrokeThickness = 1,
			};
			Canvas.SetLeft(this.BaseColor, Constant.BOARD_X);
			Canvas.SetTop(this.BaseColor, Constant.BOARD_Y);
			canvas.Children.Add(this.BaseColor);

			int distance = Constant.BLOCK_SIZE +1;
			this.Blocks = new Dictionary<Point, Block>();

			for (int row = 0; row < 9; row++)
			{
				for (int column = 0; column < 9; column++)
				{
					Point targetPosition = new Point(9 - column, row);
					Block tempBlock = new Block()
					{
						Name = new Point(9 - column, row),
						Coordinate = new Point(Constant.BOARD_X + 1 + column * distance, Constant.BOARD_Y + 1 + row * distance),
						Background = new Rectangle()
						{
							Width = Constant.BLOCK_SIZE,
							Height = Constant.BLOCK_SIZE,
							Fill = CustmerColor.BoardColor,
							Stroke = Brushes.Black,
							StrokeThickness = 1,
						}
					};
					Canvas.SetLeft(tempBlock.Background, tempBlock.Coordinate.X);
					Canvas.SetTop(tempBlock.Background, tempBlock.Coordinate.Y);
					canvas.Children.Add(tempBlock.Background);
					this.Blocks.Add(targetPosition, tempBlock);
				}
			}
		}
	}
}
