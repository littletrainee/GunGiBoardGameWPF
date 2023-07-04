using System.Windows;

namespace GunGiBoardGameWPF
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
			GameHolder.GameHolder gameHolder = new GameHolder.GameHolder();
			this.Content = gameHolder.Canvas;
			MouseLeftButtonDown += gameHolder.PlayerSelect;
		}
	}
}
