namespace musei;
using musei.Data;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();
        MainPage = new NavigationPage(new MainPage());
	}
}

