using App1.Helperprac;
using Firebase.Database;
using Firebase.Database.Query;
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
	public partial class PracownikiPage : ContentPage
	{
		public PracownikiPage ()
		{
			InitializeComponent ();
		}
        FirebaseHelper firebaseHelper = new FirebaseHelper();
        protected  override async void OnAppearing()
        {
            var AllPracowniki = await firebaseHelper.GetAllPracowniki();
            lstPracowniki.ItemsSource = AllPracowniki;

            base.OnAppearing();
        }

       private  async void Addatrybuty_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddPage());
        }

        private async void UpadatePracowniki_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new UpdatePage());

        }

        private async void DeletePracowniki_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new DeletePage());

        }


















        /*using (var firebase = new FirebaseClient("https://metamaze-36fa6-default-rtdb.firebaseio.com/"))
        }
            var result_imie_prac1 = await firebase.Child("prac1_imie").OnceSingleAsync<string>();
            var result_email_prac1 = await firebase.Child("prac1_email").OnceSingleAsync<string>();
            await DisplayAlert("teest", $"{result_imie_prac1} {result_email_prac1}", "OK");
        {*/

    }
}