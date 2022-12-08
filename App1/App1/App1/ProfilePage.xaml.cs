using Firebase.Database;
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
	public partial class ProfilePage : ContentPage
	{
		public ProfilePage ()
		{
			InitializeComponent ();
		}

        private async void Button_Clicked(object sender, EventArgs e)
        {
            /*using (var firebase = new FirebaseClient("https://metamaze-36fa6-default-rtdb.firebaseio.com/"))
            {
                var result = await firebase.Child("Test_key").OnceSingleAsync<string>();
                await DisplayAlert("title", result, "ok");
            }
            */
            await Navigation.PushAsync(new PracownikiPage ());
        }

        private async void Button_Clicked_1(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AdministratorPage());
        }

        private async void Button_Clicked_2(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ZakazyPage());
        }


    }
}