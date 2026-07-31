using App_SaveFood.Models;

namespace App_SaveFood;

public partial class TabbedPageMenu : TabbedPage
{
	public Usuario usuario { get; set; }
	public TabbedPageMenu(Models.Usuario? usLogado)
	{
		InitializeComponent();
		usuario = usLogado;
		Children.Clear();

		Children.Add(new inicioPage(usuario));
		Children.Add(new ItensPage(usuario));
		Children.Add(new ConfigPage(usuario));
		Children.Add(new SairPage(usuario));
	}
}