namespace candinoT2S2.Vistas;

public partial class vLogin : ContentPage
{
	public vLogin()
	{
		InitializeComponent();
	}

    private void btnInicio_Clicked(object sender, EventArgs e)
    {
        string[] strNombres = { "Carlos", "Ana", "José" };
        string[] strContraseña = { "carlos123", "ana123", "jose123" };

        if (txtUsuario.Text == strNombres[0] && txtContrasena.Text == strContraseña[0])
        {
            Navigation.PushAsync(new vSeguimientoNotas("Carlos"));
        }
        else if (txtUsuario.Text == strNombres[1] && txtContrasena.Text == strContraseña[1])
        {
            Navigation.PushAsync(new vSeguimientoNotas("Ana"));
        }
        else if (txtUsuario.Text == strNombres[2] && txtContrasena.Text == strContraseña[2])
        {
            Navigation.PushAsync(new vSeguimientoNotas("José"));
        }
        else
        {
            DisplayAlert("Atención", "Usuario/Contraseña incorrectos", "Cerrar");
        }
    }
}