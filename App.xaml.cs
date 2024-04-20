namespace candinoT2S2;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		MainPage = new NavigationPage(new Vistas.vLogin());
	}
}
