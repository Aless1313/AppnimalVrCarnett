using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Appcarnett.clases;

namespace Appcarnett
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Registrar : ContentPage
	{
		public Registrar ()
		{
			InitializeComponent ();
		}


        public async void registrar()
        {
            try
            {
                UseManager manager = new UseManager();
                manager.registrarusuario(txtid.Text.ToString(), txtnomb.Text.ToString(), txtapp.Text.ToString(), txtcontra.Text.ToString());

                await DisplayAlert("Registro", "Cuenta creada con exito", "Aceptar");
                txtid.Text = "";
                txtcontra.Text = "";
                txtapp.Text = "";
                txtnomb.Text = "";
            }
            catch (Exception ee)
            {
                await DisplayAlert("Error", ee.Message, "Aceptar");
            }
        }

        public async void verificar()
        {
            if (String.IsNullOrWhiteSpace(txtnomb.Text))
            {
                await DisplayAlert("Error", "Campo vacio", "Aceptar");
            }
            else
            {
                if (String.IsNullOrWhiteSpace(txtid.Text))
                {
                    await DisplayAlert("Error", "Campo vacio", "Aceptar");
                }
                else
                {
                    if (String.IsNullOrWhiteSpace(txtcontra.Text))
                    {
                        await DisplayAlert("Error", "Campo vacio", "Aceptar");
                    }
                    else
                    {
                        if (String.IsNullOrWhiteSpace(txtapp.Text))
                        {
                            await DisplayAlert("Error", "Campo vacio", "Aceptar");
                        }
                        else
                        {
                            registrar();
                        }
                    }
                }
            }
        }

        private void guardar_Clicked(object sender, EventArgs e)
        {
            verificar();
        }
    }
}