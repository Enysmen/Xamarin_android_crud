using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App1.Helperprac;
using Firebase.Database;
using Firebase.Database.Query;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DeletePage : ContentPage
    {
        public DeletePage()
        {
            InitializeComponent();
        }
        FirebaseHelper firebaseHelper = new FirebaseHelper();
        private async void DeletPrac_Clicked(object sender, EventArgs e)
        {
            var Names = Jaki_pracownik.Text;

            await firebaseHelper.DeletePracowniki(Names);
            await DisplayAlert("Success", "Pracowniki Deleted Successfully", "OK");
            await Navigation.PopAsync();
        }
    }
}