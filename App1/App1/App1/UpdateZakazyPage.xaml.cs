using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Firebase.Database;
using Firebase.Database.Query;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using App1.HelperZakz;

namespace App1
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UpdateZakazyPage : ContentPage
    {
        public UpdateZakazyPage()
        {
            InitializeComponent();
        }

        FirebaseHelper_zakazy firebaseHelper_zakazy = new FirebaseHelper_zakazy();
        private async void UpdateZakazys_Clicked(object sender, EventArgs e)
        {
            var Numer_zakazs = Numer_zakaz.Text;
            var ilie_koszts = ilie_koszt.Text;
            var Co_zakazs = Co_zakaz.Text;

            await firebaseHelper_zakazy.UpdateZakazy(Numer_zakazs, ilie_koszts, Co_zakazs);
            await DisplayAlert("Success", "Zakazy Updated Successfully", "OK");
            await Navigation.PopAsync();

        }
    }
}