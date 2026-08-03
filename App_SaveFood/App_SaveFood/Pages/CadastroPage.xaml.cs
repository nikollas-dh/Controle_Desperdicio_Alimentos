using App_SaveFood.Models;
using System.Net.Http.Json;

namespace App_SaveFood;

public partial class CadastroPage : ContentPage
{
	public CadastroPage()
	{
		InitializeComponent();
        CarregarRestaurantes();
	}

    private async void CarregarRestaurantes()
    {
        await DisplayAlert("Teste", "Método iniciado", "OK");

        HttpClient client = new HttpClient();

        try
        {
            await DisplayAlert("Teste", "Método iniciado2", "OK");

            var restaurantes = await client.GetFromJsonAsync<List<Restaurante>>(
      "http://10.0.2.2:5123/api/restaurante");

            pickerRestaurante.ItemsSource = restaurantes;
        }
        catch (Exception ex)
        {
            await DisplayAlert("Erro", ex.ToString(), "OK");
        }
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
            txtSenha.IsPassword = true;
        }
    }

    private void eyeButton2_Clicked(object sender, EventArgs e)
    {
        if (txtConfirmarSenha.IsPassword)
        {
            eyeButton2.Source = "eye_off.png";
            txtConfirmarSenha.IsPassword = false;
        }
        else
        {
            eyeButton2.Source = "eye.png";
            txtConfirmarSenha.IsPassword = true;
        }
    }

    private void eyePin_Clicked(object sender, EventArgs e)
    {
        if (txtPin.IsPassword)
        {
            eyePin.Source = "eye_off.png";
            txtPin.IsPassword = false;
        }
        else
        {
            eyePin.Source = "eye.png";
            txtPin.IsPassword = true;
        }
    }
}