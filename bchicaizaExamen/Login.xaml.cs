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
    public partial class Login : ContentPage
    {
        string usuario = "estudiante2023";
        string clave = "uisrael2023";
        public Login()
        {
            InitializeComponent();
        }

        private void btnIngresar_Clicked(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(txtUsuario.Text)) {
                DisplayAlert("Error", "Ingrese usuario", "Cerrar");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtClave.Text))
            {
                DisplayAlert("Error", "Ingrese clave", "Cerrar");
                return;
            }

            if (txtUsuario.Text.Equals(this.usuario) && txtClave.Text.Equals(this.clave))
            {
                Navigation.PushAsync(new Registro(txtUsuario.Text));
            }
            else
            {
                this.cleanFields();
                DisplayAlert("Error", "Credenciales invalidas", "Cerrar");
            }
        }


        private void btnCancelar_Clicked(object sender, EventArgs e)
        {
            this.cleanFields();
        }

        private void cleanFields()
        {
            txtClave.Text = "";
            txtUsuario.Text = "";
        }
    }
}