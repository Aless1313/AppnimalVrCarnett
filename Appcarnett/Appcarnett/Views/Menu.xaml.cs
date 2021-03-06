﻿using Appcarnett.clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZXing.Net.Mobile.Forms;

namespace Appcarnett
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Menu : ContentPage
	{
		public Menu ()
		{
			InitializeComponent ();
            NavigationPage.SetHasNavigationBar(this, false);
        }

        private async void btnvisit_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Visita());
        }

        private async void btnfact_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new factura());
        }

        private async void btnlector_Clicked(object sender, EventArgs e)
        {
            Scanner();
        }

        private async void Scanner()
        {
            var scannerPage = new ZXingScannerPage();

            scannerPage.Title = "Lector de QR";
            scannerPage.OnScanResult += (result) =>
            {
                scannerPage.IsScanning = true;

                Device.BeginInvokeOnMainThread(async () =>
                {
                    await Navigation.PopAsync();
                    await DisplayAlert("Codigo", result.Text, "Aceptar");
                    puntos(result.Text.ToString());
                });
            };

            await Navigation.PushAsync(scannerPage);
        }

        public async void puntos(string us)
        {
            
            try
            {
                UseManager manager = new UseManager();
                manager.puntos(us);

                await DisplayAlert("Puntos", "Se han enviado " + 5 + " Zoocoins a la cuenta "+ us, "Aceptar");


            }
            catch (Exception r)
            {
                await DisplayAlert("Error", " :( " + r.Message, "Aceptar");
            }

        }

    }
}