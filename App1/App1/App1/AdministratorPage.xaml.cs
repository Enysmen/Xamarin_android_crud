using App1.HelperAdmin;
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
	public partial class AdministratorPage : ContentPage
	{
		public AdministratorPage ()
		{
			InitializeComponent ();
		}

        FirebaseHelper_admin firebaseHelper_Admin = new FirebaseHelper_admin ();
        protected override async void OnAppearing()
        {
            var AllAdmin = await firebaseHelper_Admin.GetAllAdmin();
            lstAdmin.ItemsSource = AllAdmin;

            base.OnAppearing();
        }



        private async void Addadmin_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddPage());
        }

        private async void Updateadmin_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new UpdateAdminPage());
        }

        private async void DeleteAdmin_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new DeleteAdminPage());
        }
    }
}