using App_SaveFood.Models;

namespace App_SaveFood;

public partial class LoginPage : ContentPage
{
	public LoginPage()
	{
		InitializeComponent();
	}

    private void btnLogin_Clicked(object sender, EventArgs e)
    {
		Usuario usuario = new Usuario();
		usuario.Email = txtEmail.Text;
		usuario.Senha= txtSenha.Text;

        Application.Current.MainPage = new TabbedPageMenu();

    }

    private void Button_Clicked(object sender, EventArgs e)
    {
		Navigation.PushAsync(new CadastroPage());
    }

    private void eyeButton_Clicked(object sender, EventArgs e)
    {
        if (txtSenha.IsPassword)
        {
            eyeButton.Source = "eye_off.png";
            txtSenha.IsPassword = false;
        }
        else
        {
            eyeButton.Source = "eye.png";
            txtSenha.IsPassword=true;
        }
    }
}