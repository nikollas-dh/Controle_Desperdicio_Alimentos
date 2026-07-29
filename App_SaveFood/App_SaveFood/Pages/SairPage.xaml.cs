namespace App_SaveFood;

public partial class SairPage : ContentPage
{
	public SairPage()
	{
		InitializeComponent();
	}

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        bool sair = await DisplayAlert(
                    "Sair",
                    "Deseja realmente sair da sua conta?",
                    "Sim",
                    "Cancelar");

        if (sair)
        {
            Application.Current.MainPage = new LoginPage();
        }
        else
        {
            Application.Current.MainPage = new TabbedPageMenu();
        }
    }
}