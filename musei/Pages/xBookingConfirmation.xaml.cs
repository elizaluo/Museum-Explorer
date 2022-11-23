namespace musei;

public partial class xBookingConfirmation : ContentPage
{
	public xBookingConfirmation()
	{
		InitializeComponent();
	}

    async void OnButtonClicked(object sender, EventArgs args)
    {
        await App.Current.MainPage.Navigation.PopToRootAsync();
    }

}
