using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Firebase.Database;
using Firebase.Database.Query;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using App1.HelperAdmin;
using App1.Helperprac;

namespace App1
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DeleteAdminPage : ContentPage
    {
        public DeleteAdminPage()
        {
            InitializeComponent();
        }

        FirebaseHelper_admin firebaseHelper_Admin = new FirebaseHelper_admin();

        private async void DeleteAdmin_Clicked(object sender, EventArgs e)
        {
            var DeIDAdmins = DeIDAdmin.Text;

            await firebaseHelper_Admin.DeleteAdmin(DeIDAdmins);
            await DisplayAlert("Success", "Admin Deleted Successfully", "OK");
            await Navigation.PopAsync();

        }


    }
}