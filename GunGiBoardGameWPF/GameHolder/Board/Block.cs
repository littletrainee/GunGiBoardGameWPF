using System.Collections.Generic;
using System.Windows;
using System.Windows.Shapes;

namespace GunGiBoardGameWPF.GameHolder.Board
{
	public class Block
	{
		public Point Name { get; set; }
		public Rectangle Background { get; set; }
		public Point Coordinate { get; set; }
		public List<Koma.Koma> KomaStack { get; set; }
	}
}
