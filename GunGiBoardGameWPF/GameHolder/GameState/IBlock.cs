using System.Drawing;
using System.Windows.Controls;

namespace GunGiBoardGameWPF.GameHolder.GameState
{
	public interface IBlock
	{
		public System.Windows.Shapes.Rectangle Background { get; set; }
		public TextBlock TextBlock { get; set; }
		public Point Position { get; set; }




		public void SetPosition(ref Canvas canvas);
		public bool OnBlock(System.Windows.Point point);
		public void Hide();
	}
}
