using Firebase.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App1.HelperAdmin;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Firebase.Database.Query;

namespace App1
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UpdateAdminPage : ContentPage
    {
        public UpdateAdminPage()
        {
            InitializeComponent();
        }
        FirebaseHelper_admin firebaseHelper_Admin = new FirebaseHelper_admin();

        private async void UpdateAdmin_Clicked(object sender, EventArgs e)
        {
            var IdupAdmins = IdupAdmin.Text;
            var Nazwisko_imies = Nazwisko_imie.Text;
            var EmailAdmins = EmailAdmin.Text;
            var Zacoodpowiadas = Zacoodpowiada.Text;

            await firebaseHelper_Admin.UpdateAdmin(IdupAdmins,Nazwisko_imies, EmailAdmins,Zacoodpowiadas);
            await DisplayAlert("Success", "Admin Updated Successfully", "OK");
            await Navigation.PopAsync();
        }
    }
}