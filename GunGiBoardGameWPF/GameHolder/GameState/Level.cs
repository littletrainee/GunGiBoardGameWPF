using System.Windows.Controls;


namespace GunGiBoardGameWPF.GameHolder.GameState.Level
{
	public class Level : IBlock
	{
		public Enum.Level Code { get; set; }
		public System.Windows.Shapes.Rectangle Background { get; set; }
		public TextBlock TextBlock { get; set; }
		public System.Drawing.Point Position { get; set; }



		public void SetPosition(ref Canvas canvas)
		{
			Canvas.SetLeft(this.Background, this.Position.X);
			Canvas.SetTop(this.Background, this.Position.Y);
			canvas.Children.Add(this.Background);

			Canvas.SetLeft(this.TextBlock, this.Position.X + 28);
			Canvas.SetTop(this.TextBlock, this.Position.Y + 38);
			canvas.Children.Add(this.TextBlock);
		}

		public bool OnBlock(System.Windows.Point point)
		{
			return new System.Drawing.Rectangle(
				this.Position.X,
				this.Position.Y,
				Constant.LEVEL_BLOCK_SIZE,
				Constant.LEVEL_BLOCK_SIZE)
				.Contains(new System.Drawing.Point((int)point.X, (int)point.Y));
		}

		public void Hide()
		{
			this.Background.Visibility = System.Windows.Visibility.Hidden;
			this.TextBlock.Visibility = System.Windows.Visibility.Hidden;
		}
	}
}
