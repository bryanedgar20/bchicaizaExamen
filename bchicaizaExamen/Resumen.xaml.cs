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
    public partial class Resumen : ContentPage
    {
        public Resumen(Informacion informacion)
        {
            InitializeComponent();

            lblUsuario.Text = informacion.Usuario;
            lblNombre.Text = informacion.Nombre;
            lblApellido.Text = informacion.Apellido;    
            lblEdad.Text = informacion.Edad;
            lblFecha.Text = informacion.Fecha;
            lblPais.Text = informacion.Pais;
            lblCiudad.Text = informacion.Ciudad;
            lblMontoInicial.Text = informacion.MontoInicial;
            lblMontoMensual.Text = informacion.MontoMensual;
            lblPagoTotal.Text = informacion.MontoTotal;

        }

        private void btnSalir_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Login());
        }
    }
}