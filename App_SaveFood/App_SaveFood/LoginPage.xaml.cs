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

    }

    private void Button_Clicked(object sender, EventArgs e)
    {
		Navigation.PushAsync(new CadastroPage());
    }
}