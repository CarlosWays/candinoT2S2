namespace candinoT2S2.Vistas;

public partial class vLogin : ContentPage
{
	public vLogin()
	{
		InitializeComponent();
	}

    private void btnInicio_Clicked(object sender, EventArgs e)
    {
        string[] strNombres = { "Carlos", "Ana", "Jos�" };
        string[] strContrase�a = { "carlos123", "ana123", "jose123" };

        if (txtUsuario.Text == strNombres[0] && txtContrasena.Text == strContrase�a[0])
        {
            Navigation.PushAsync(new vSeguimientoNotas("Carlos"));
        }
        else if (txtUsuario.Text == strNombres[1] && txtContrasena.Text == strContrase�a[1])
        {
            Navigation.PushAsync(new vSeguimientoNotas("Ana"));
        }
        else if (txtUsuario.Text == strNombres[2] && txtContrasena.Text == strContrase�a[2])
        {
            Navigation.PushAsync(new vSeguimientoNotas("Jos�"));
        }
        else
        {
            DisplayAlert("Atenci�n", "Usuario/Contrase�a incorrectos", "Cerrar");
        }
    }
}