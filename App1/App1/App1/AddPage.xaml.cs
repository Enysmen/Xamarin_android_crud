using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Firebase.Database;
using Firebase.Database.Query;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using App1.Helperprac;
using System.Xml.Linq;
using App1.HelperZakz;
using App1.HelperAdmin;


namespace App1
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddPage : ContentPage
    {
        public AddPage()
        {
            InitializeComponent();
        }

        FirebaseHelper firebaseHelper = new FirebaseHelper();
        FirebaseHelper_zakazy firebaseHelper_zakazy = new FirebaseHelper_zakazy();
        FirebaseHelper_admin firebaseHelper_Admin = new FirebaseHelper_admin();
        public async void AddSavedata_Clicked(object sender, EventArgs e)
        {
            // jaki atrybut
            var Atrybutt = Atrybut.Text;
            // pracowniki
            var Jakii = name.Text;
            var EmailAd = EmailADD.Text;
            var imie = Imie_Nazwisko.Text;
            var Kim = Kim_pracuje.Text;
            //Zakazy
            var Numer_zakazus = Numer_zakazu.Text;
            var ilie_kosztowals = ilie_kosztowal.Text;
            var Co_zakazanos = Co_zakazano.Text;
            // administartor 
            var EmaillAdmins = EmaillAdmin.Text;
            var Zacoodpows = Zacoodpow.Text;
            var nazwisko_Imie = Nazwisko_Imie.Text;
            var idAdmin = IdAdmin.Text;


            if (Atrybutt == "Pracowniki")
            {
                await firebaseHelper.AddPracowniki(Jakii,EmailAd,imie,Kim);
                await DisplayAlert("Success", "Pracowniki Added Successfully", "OK");
                await Navigation.PopAsync();

            }


            if (Atrybutt == "Zakazy")
            {
                await firebaseHelper_zakazy.AddZakazy(Numer_zakazus, ilie_kosztowals, Co_zakazanos);
                await DisplayAlert("Success", "Zakazy Added Successfully", "OK");
                await Navigation.PopAsync();
            }

            if(Atrybutt =="Administrator")
            {
                await firebaseHelper_Admin.AddAdmin(idAdmin, nazwisko_Imie,EmaillAdmins, Zacoodpows);
                await DisplayAlert("Success", "Admin Added Successfully", "OK");
                await Navigation.PopAsync();

            }


        }
    }
}