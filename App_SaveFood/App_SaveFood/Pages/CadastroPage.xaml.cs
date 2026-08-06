using App_SaveFood.Models;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;

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

        HttpClient client = new HttpClient();

        try
        {
            var restaurantes = await client.GetFromJsonAsync<List<Restaurante>>(
            "http://192.168.92.27:5123/api/restaurante");
            //"http://10.0.2.2:5123/api/restaurante");

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

    private async void Button_Clicked(object sender, EventArgs e)
    {
        var us = new Usuario();
        us.Email = txtEmail.Text;
        us.Senha = txtSenha.Text;
        us.Nome = txtNome.Text;
        us.Pin = txtPin.Text;

        //Restaurante restaurante = new Restaurante();

        var restauranteSelecionado = pickerRestaurante.SelectedItem as Restaurante;

        if (restauranteSelecionado == null)
        {
            await DisplayAlert("Erro", "Selecione um restaurante.", "OK");
            return;
        }

        us.FkIdRestaurante = restauranteSelecionado.IdRestaurante;

        HttpClient client = new HttpClient();
        
        try
        {
            string url = "http://192.168.92.27:5123/api/user";
            //string url = "http://10.0.2.2:5123/api/user";
            string json = JsonSerializer.Serialize(us); 

            var content = new StringContent(json,Encoding.UTF8,"application/json");
            var res = await client.PostAsync(url, content);

            if (res.IsSuccessStatusCode)
            {
                var resBody = await res.Content.ReadAsStringAsync();
                var usLogado = JsonSerializer.Deserialize<Usuario>(resBody, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

                await DisplayAlert("Sucesso", "Usuário cadastrado com sucesso!","Ok");
                await Navigation.PopAsync();
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Erro", ex.Message, "OK");
        }
    }
}