using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Appcarnett.clases;

namespace Appcarnett
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }
        private async void btnentrar_Clicked(object sender, EventArgs e)
        {
            verificar();
        }
        private async void btnregistrar_Clicked(object sender,EventArgs e)
        {
            await Navigation.PushAsync(new Registrar());
        }

        //Iniciar sesion
        public async void iniciar()
        {
            try
            {
                UseManager manager = new UseManager();
                var result = await manager.userlogin(user.Text.ToString(), pass.Text.ToString());

                if (result.Count() > 0)
                {
                    //Inicio de sesión
                    await Navigation.PushAsync(new Menu());
                }
                else
                {
                    await DisplayAlert("Error", "Usuario o contraseña incorrecto", "Aceptar");
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.Message, "Aceptar");
            }
        }

        public async void verificar()
        {
            if (String.IsNullOrWhiteSpace(user.Text))
            {
                await DisplayAlert("Error", "Campo usuario vacio", "Aceptar");
            }
            else
            {
                if (String.IsNullOrWhiteSpace(pass.Text))
                {
                    await DisplayAlert("Error", "Campo contraseña vacio", "Aceptar");
                }
                else
                {
                    iniciar();
                }
            }
        }
    }
}
