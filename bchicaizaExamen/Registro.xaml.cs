using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace bchicaizaExamen
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Registro : ContentPage
    {
        Double valorCurso = 1800.0;
        Double interesCuota = 1800.0 * 5 / 100;
        Double montoCuota = 0;
        Double montoTotal = 0;
        string username = string.Empty;
        public Registro(string userName)
        {
            InitializeComponent();
            lblUsuario.Text = "El usuario conectado es:" + userName;
            this.username = userName;   
        }

        private void btnPagoMensual_Clicked(object sender, EventArgs e)
        {

            Double inputMonto = 0;
            Double subTotal = 0;
            Double cuota = 0;

            if (string.IsNullOrWhiteSpace(txtMonto.Text))
            {
                DisplayAlert("Error", "Inserte el monto", "Cancelar");
                return;
            }
            inputMonto = Double.Parse(txtMonto.Text);
            subTotal = valorCurso - inputMonto;
            cuota = (subTotal / 3) + interesCuota;
            Decimal cuotaDecimal = Convert.ToDecimal(cuota);
            this.montoTotal = (double)(cuotaDecimal * 3);
            this.montoCuota = (double)cuotaDecimal;
            lblPagoMensual.Text = Decimal.Round(cuotaDecimal, 2).ToString() + " $";

        }

        private void btnResumen_Clicked(object sender, EventArgs e)
        {
            Informacion informacion = new Informacion();
            if (this.validateFields())
            {
                informacion.Nombre = txtNombre.Text;
                informacion.Apellido = txtApellido.Text;    
                informacion.Edad = txtEdad.Text;
                informacion.Fecha = fechaRegistro.Date.ToString("dd/MM/yyyy");
                informacion.Pais = pickerPaises.SelectedItem.ToString();
                informacion.Ciudad = pickerCiudades.SelectedItem.ToString();
                informacion.MontoInicial = "1800$";
                informacion.MontoMensual = this.montoCuota.ToString();
                informacion.MontoTotal = this.montoTotal.ToString();
                informacion.Usuario = this.username;
                Navigation.PushAsync(new Resumen(informacion));
            }
            else {
                DisplayAlert("Error", "Complete toda la informacion", "Cancelar");
            }
        }

        private void txtMonto_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!this.validateNumber(e.NewTextValue))
            {
                txtMonto.Text = string.Empty;
            }
        }

        private Boolean validateNumber(string input)
        {
            if (!string.IsNullOrWhiteSpace(input))
            {
                // Validar que el valor sea un número válido
                if (!double.TryParse(input, out double value))
                {
                    // Valor no válido, puedes mostrar un mensaje de error o tomar alguna acción
                    // Por ejemplo, mostrar un mensaje de error en un Label
                    getValidation("Ingrese un valor numérico válido");
                    return false;

                }

                // Validar que el valor esté dentro del rango de 1 a 1800
                if (value < 1 || value > 1800)
                {
                    // Valor fuera de rango, puedes mostrar un mensaje de error o tomar alguna acción
                    // Por ejemplo, mostrar un mensaje de error en un Label

                    getValidation("Ingrese un valor del 1 al 1800");
                    return false;

                }

                // Validar que el valor tenga máximo dos decimales
                int decimalPlaces = BitConverter.GetBytes(decimal.GetBits((decimal)value)[3])[2];
                if (decimalPlaces > 2)
                {
                    // Más de dos decimales, puedes mostrar un mensaje de error o tomar alguna acción
                    // Por ejemplo, mostrar un mensaje de error en un Label
                    getValidation("Ingrese máximo dos decimales");
                    return false;

                }
                return true;
            }
            return false;
        }

        private void getValidation(String message)
        {
            DisplayAlert("Error", message, "Cancelar");
        }

        private Boolean validateFields()
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                DisplayAlert("Error", "Ingrese nombre", "Cancelar");
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtApellido.Text))
            {
                DisplayAlert("Error", "Ingrese apellido", "Cancelar");
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtMonto.Text))
            {
                DisplayAlert("Error", "Ingrese monto", "Cancelar");
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtEdad.Text))
            {
                DisplayAlert("Error", "Ingrese edad", "Cancelar");
                return false;
            }
            if (string.IsNullOrWhiteSpace(fechaRegistro.Date.ToString("dd/MM/yyyy")))
            {
                DisplayAlert("Error", "Ingrese fecha", "Cancelar");
                return false;
            }
            if (string.IsNullOrWhiteSpace(pickerCiudades.SelectedItem.ToString()))
            {
                DisplayAlert("Error", "Seleccione ciudad", "Cancelar");
                return false;
            }
            if (string.IsNullOrWhiteSpace(pickerPaises.SelectedItem.ToString()))
            {
                DisplayAlert("Error", "Seleccione pais", "Cancelar");
                return false;
            }
            if (string.IsNullOrWhiteSpace(this.montoTotal.ToString()) || this.montoTotal == 0)
            {
                DisplayAlert("Error", "Calcule el valor de la cuota", "Cancelar");
                return false;
            }
            return true;
        }
    }
}