using System.Windows.Controls;

namespace GunGiBoardGameWPF.GameHolder.GameState
{
	public class Arrangement : IBlock
	{
		public Enum.Arrangement ArrangementSelect { get; set; }
		public System.Windows.Shapes.Rectangle Background { get; set; }
		public TextBlock TextBlock { get; set; }
		public System.Drawing.Point Position { get; set; }



		public void SetPosition(ref Canvas canvas)
		{
			Canvas.SetLeft(this.Background, this.Position.X);
			Canvas.SetTop(this.Background, this.Position.Y);
			canvas.Children.Add(this.Background);

			Canvas.SetLeft(this.TextBlock, this.Position.X + 35);
			Canvas.SetTop(this.TextBlock, this.Position.Y + 60);
			canvas.Children.Add(this.TextBlock);
		}

		public bool OnBlock(System.Windows.Point point)
		{
			return new System.Drawing.Rectangle(
				this.Position.X,
				this.Position.Y,
				Constant.ARRANGEMENT_BUTTON_SIZE,
				Constant.ARRANGEMENT_BUTTON_SIZE)
				.Contains(new System.Drawing.Point((int)point.X, (int)point.Y));
		}

		public void Hide()
		{

		}
	}
}
