using Appcarnett.clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Appcarnett
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Visita : ContentPage
	{
		public Visita ()
		{
			InitializeComponent ();
            informacion();
		}
        public async void informacion()
        {
            try
            {
                UseManager manager = new UseManager();
                var result = await manager.visitas();

                if (result.Count() > 0)
                {
                    informacioan.ItemsSource = result;
                }
                else
                {
                    await DisplayAlert("Error", "No hay información del usuario", "Aceptar");
                }
            }
            catch (Exception ei)
            {
                await DisplayAlert("Error", ei.Message, "Aceptar");
            }
        }
    }
   
}