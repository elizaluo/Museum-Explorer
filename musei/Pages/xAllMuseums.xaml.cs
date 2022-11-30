namespace musei;
using musei.Pages;
public partial class xAllMuseums : ContentPage
{
	public xAllMuseums()
	{
		InitializeComponent();
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();
        System.Diagnostics.Debug.WriteLine("I'm appearing");
        InvalidateMeasure();
        
    }
}
