namespace App_SaveFood;

public partial class CadastroPage : ContentPage
{
	public CadastroPage()
	{
		InitializeComponent();
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
}