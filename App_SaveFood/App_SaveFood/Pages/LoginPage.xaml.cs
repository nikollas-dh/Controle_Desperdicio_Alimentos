using App_SaveFood.Models;
using App_SaveFood.Pages;
using System.Text;
using System.Text.Json;


namespace App_SaveFood;

public partial class LoginPage : ContentPage
{
	public LoginPage()
	{
		InitializeComponent();
	}

    private async void btnLogin_Clicked(object sender, EventArgs e)
    {
		var usuario = new Usuario();
		usuario.Email = txtEmail.Text;
        usuario.Senha = txtSenha.Text;
        try
        {
            HttpClient client = new HttpClient();
            string url = "http://10.0.2.2:5123/api/user/login";
            string json = JsonSerializer.Serialize(usuario);

            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var res = await client.PostAsync(url, content);
            if (res.IsSuccessStatusCode)
            {
                var resBody = await res.Content.ReadAsStringAsync();
                var usLogado = JsonSerializer.Deserialize<Usuario>(resBody, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });
                await DisplayAlert("Sucesso", "Seja Bem-Vindo", "Ok");
                Application.Current.MainPage = new TabbedPageMenu(usLogado);
            }
            else
            {
                await DisplayAlert("Erro", "Usuário ou senha inválidos!", "Ok");
                return;
            }
        }
        catch
        {
            await DisplayAlert("Erro", "Não foi possível conectar com a API!", "Ok");
            return;
        }


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

    private void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
        Navigation.PushAsync(new MudarSenhaPage());
    }
}