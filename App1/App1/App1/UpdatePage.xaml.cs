using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App1.Helperprac;
using Firebase.Database;
using Firebase.Database.Query;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
namespace App1
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UpdatePage : ContentPage
    {

        FirebaseHelper firebaseHelper = new FirebaseHelper();
        public UpdatePage()
        {
            InitializeComponent();
        }

        private async void Updatepracowniki_Clicked(object sender, EventArgs e)
        {
            var Nameupd = nameup.Text;
            var EmailUp = EmailADup.Text;
            var Imie_NazwiskoUp = Imie_Nazwiskoup.Text;
            var Kim_pracujeUp = Kim_pracujeup.Text;

            await firebaseHelper.UpdatePracowniki(Nameupd, EmailUp, Imie_NazwiskoUp, Kim_pracujeUp);
            await DisplayAlert("Success", "Pracowniki Updated Successfully", "OK");
            await Navigation.PopAsync();
        }
    }
}