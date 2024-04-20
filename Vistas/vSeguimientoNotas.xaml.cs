namespace candinoT2S2.Vistas;

public partial class vSeguimientoNotas : ContentPage
{
	public vSeguimientoNotas(string usuario)
	{
        InitializeComponent();
        DisplayAlert("Alerta", "Bienvenido/a " + usuario, "Salir");
        lblUsuario.Text = "Usuario conectado: " + usuario;
    }
    string strResultado = string.Empty;
    string strNombreEst = string.Empty;

    private void btnCalcular_Clicked(object sender, EventArgs e)
    {
        if (pkNombreEstudiante.SelectedIndex == -1)
        {
            DisplayAlert("Alerta", "Debe seleccionar un estudiante", "Salir");
            return;
        }
        else
        {
            strNombreEst = pkNombreEstudiante.Items[pkNombreEstudiante.SelectedIndex].ToString();
        }
        if (string.IsNullOrEmpty(txtNotaSeguimiento.Text) || string.IsNullOrEmpty(txtNotaSeguimiento2.Text) || string.IsNullOrEmpty(txtNotaExamen.Text) || string.IsNullOrEmpty(txtNotaExamen2.Text))
        {
            DisplayAlert("Atención", "Debe ingresar todas las notas", "Salir");
            return;
        }
        if (txtNotaSeguimiento.Text.Contains('.') || txtNotaSeguimiento2.Text.Contains('.') || txtNotaExamen.Text.Contains('.') || txtNotaExamen2.Text.Contains('.'))
        {
            ConversionComas();
        }

        if (decimal.Parse(txtNotaSeguimiento.Text) == 0 || decimal.Parse(txtNotaSeguimiento2.Text) == 0 || decimal.Parse(txtNotaExamen.Text) == 0 || decimal.Parse(txtNotaExamen2.Text) == 0)
        {
            DisplayAlert("Atención", "No puede ingresar una nota de 0", "Salir");
            return;
        }

        if (decimal.Parse(txtNotaSeguimiento.Text) > 10 || decimal.Parse(txtNotaSeguimiento2.Text) > 10 || decimal.Parse(txtNotaExamen.Text) > 10 || decimal.Parse(txtNotaExamen2.Text) > 10)
        {
            ConversionPuntos();
        }
        
        decimal dNS1 = decimal.Parse(txtNotaSeguimiento.Text) * (0.3m);
        decimal dNS2 = decimal.Parse(txtNotaSeguimiento2.Text) * (0.3m);
        decimal dExamen1 = decimal.Parse(txtNotaExamen.Text) * (0.2m);
        decimal dExamen2 = decimal.Parse(txtNotaExamen2.Text) * (0.2m);

        decimal dNotaP1 = dNS1 + dExamen1;
        decimal dNotaP2 = dNS2 + dExamen2;
        decimal dNotaFinal = dNotaP1 + dNotaP2;
        EstadoEstudiante(dNotaFinal);

        string strfNotaP1 = dNotaP1.ToString("F2");
        string strfNotaP2 = dNotaP2.ToString("F2");
        string strfNotaFinal = dNotaFinal.ToString("F2");              
        string strFecha = dpFecha.Date.ToString("MM/dd/yyyy");

        DisplayAlert("Resultados", "Nombre: " + strNombreEst + "\nFecha: " + strFecha + 
            "\nNota Parcial 1: " + strfNotaP1 + "\nNota Parcial 2: " + strfNotaP2 +
            "\nNota Final: " + strfNotaFinal + "\nEstado: " + strResultado, "Salir");

        LimpiarDatos();
    }

    public void ConversionComas()
    {
        string strConversion = string.Empty;
        if (txtNotaSeguimiento.Text.Contains("."))
        {
            strConversion = txtNotaSeguimiento.Text.ToString();
            txtNotaSeguimiento.Text = strConversion.Replace(".", ",");
        }
        if (txtNotaExamen.Text.Contains("."))
        {
            strConversion = txtNotaExamen.Text.ToString();
            txtNotaExamen.Text = strConversion.Replace(".", ",");
        }
        if (txtNotaSeguimiento2.Text.Contains("."))
        {
            strConversion = txtNotaSeguimiento2.Text.ToString();
            txtNotaSeguimiento2.Text = strConversion.Replace(".", ",");
        }
        if (txtNotaExamen2.Text.Contains("."))
        {
            strConversion = txtNotaExamen2.Text.ToString();
            txtNotaExamen2.Text = strConversion.Replace(".", ",");
        }
    }

    public void ConversionPuntos()
    {
        string strConversion = string.Empty;
        if (txtNotaSeguimiento.Text.Contains(","))
        {
            strConversion = txtNotaSeguimiento.Text.ToString();
            txtNotaSeguimiento.Text = strConversion.Replace(",", ".");
        }
        if (txtNotaExamen.Text.Contains(","))
        {
            strConversion = txtNotaExamen.Text.ToString();
            txtNotaExamen.Text = strConversion.Replace(",", ".");
        }
        if (txtNotaSeguimiento2.Text.Contains(","))
        {
            strConversion = txtNotaSeguimiento2.Text.ToString();
            txtNotaSeguimiento2.Text = strConversion.Replace(",", ".");
        }
        if (txtNotaExamen2.Text.Contains(","))
        {
            strConversion = txtNotaExamen2.Text.ToString();
            txtNotaExamen2.Text = strConversion.Replace(",", ".");
        }
    }


    public string EstadoEstudiante(decimal dNotaFinal)
    {
        
        if (dNotaFinal >= 7)
        {
            strResultado = "Aprobado";
        }
        else if (dNotaFinal >= 5 && dNotaFinal <= 6.9m)
        {
            strResultado = "Complementario";
        }
        else if (dNotaFinal < 5)
        {
            strResultado = "REPROBADO";
        }
        return strResultado;
    }

    public void LimpiarDatos()
    {
        txtNotaSeguimiento.Text = string.Empty;
        txtNotaSeguimiento2.Text = string.Empty;
        txtNotaExamen.Text = string.Empty;
        txtNotaExamen2.Text = string.Empty;
    }
}