using Firebase.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Firebase.Database.Query;
using Xamarin.Essentials;

namespace App1.HelperAdmin
{
    public class FirebaseHelper_admin : Class_admin
    {
        FirebaseClient ___firebase = new FirebaseClient("https://metamaze-36fa6-default-rtdb.firebaseio.com/");

        public async Task<List<Class_admin>> GetAllAdmin()
        {
            return (await ___firebase
             .Child("Admin")
             .OnceAsync<Class_admin>()).Select(item => new Class_admin
             {
                 Emailadmin = item.Object.Emailadmin,
                 Zacodopwiada = item.Object.Zacodopwiada,
                 Nazwisko_imie = item.Object.Nazwisko_imie,
                 Idadmin = item.Object.Idadmin

             }).ToList();
        }

        public async Task AddAdmin(string idadmin ,string nazwisko_imie, string emailadmin, string zacodopwiada)
        {
            await ___firebase
            .Child("Admin")
             .PostAsync(new Class_admin() { Idadmin = idadmin, Nazwisko_imie = nazwisko_imie,  Emailadmin = emailadmin, Zacodopwiada = zacodopwiada});
        }

        public async Task UpdateAdmin(string idadmin, string nazwisko_imie, string emailadmin, string zacodopwiada)
        {

            var toUpdateAdmin = (await ___firebase
             .Child("Admin")
             .OnceAsync<Class_admin>()).Where(a => a.Object.Idadmin == idadmin).FirstOrDefault();

            await ___firebase
            .Child("Admin")
            .Child(toUpdateAdmin.Key)
            .PutAsync(new Class_admin() { Idadmin = idadmin,Nazwisko_imie = nazwisko_imie, Emailadmin = emailadmin, Zacodopwiada = zacodopwiada });
        }

        public async Task DeleteAdmin(string idadmin)
        {
            var toDeleteAdmin = (await ___firebase
              .Child("Admin")
              .OnceAsync<Class_admin>()).Where(a => a.Object.Idadmin == idadmin).FirstOrDefault();
            await ___firebase.Child("Admin").Child(toDeleteAdmin.Key).DeleteAsync();
        }



    }
}
