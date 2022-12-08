using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App1.HelperZakz;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Firebase.Database;
using Firebase.Database.Query;

namespace App1
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DeletPage : ContentPage
    {
        public DeletPage()
        {
            InitializeComponent();
        }
        FirebaseHelper_zakazy firebaseHelper_zakazy = new FirebaseHelper_zakazy();
        private async void DeletZakazy_Clicked(object sender, EventArgs e)
        {
            var Numer_zakazs = Numer_zakazss.Text;

            await firebaseHelper_zakazy.DeleteZakazy(Numer_zakazs);
            await DisplayAlert("Success", "Zakazy Updated Successfully", "OK");
            await Navigation.PopAsync();

        }
    }
}