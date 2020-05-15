using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Drawing;
using ZXing;
using ZXing.QrCode.Internal;

namespace Appcarnett
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Page1 : ContentPage
	{
		public Page1 ()
		{
			InitializeComponent ();
		}

		private void generateqr_Clicked(object sender, EventArgs e)
		{
			// TODO Implement error handling and 

			qr.IsVisible = true;
		}
	}
}