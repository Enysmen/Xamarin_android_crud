using App1.HelperZakz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ZakazyPage : ContentPage
	{
		public ZakazyPage ()
		{
			InitializeComponent ();
		}

        FirebaseHelper_zakazy firebaseHelper_Zakazy = new FirebaseHelper_zakazy ();
        protected override async void OnAppearing()
        {
            var AllZakazy = await firebaseHelper_Zakazy.GetAllZakazy();
            lstZakazy.ItemsSource = AllZakazy;

            base.OnAppearing();
        }


        private async void AddZakazy_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddPage());
        }

        private async void UpdateZakazy_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new UpdateZakazyPage());
        }

        private async void DeleteZakazy_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync (new DeletPage());
        }
    }
}