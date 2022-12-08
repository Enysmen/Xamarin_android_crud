using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Firebase.Database;
using Firebase.Database.Query;
using Xamarin.Essentials;

namespace App1.HelperZakz
{
    public class FirebaseHelper_zakazy : Class_zakazy
    {
        FirebaseClient __firebase = new FirebaseClient("https://metamaze-36fa6-default-rtdb.firebaseio.com/");

        public async Task<List<Class_zakazy>> GetAllZakazy()
        {
            return (await __firebase
             .Child("Zakazy")
             .OnceAsync<Class_zakazy>()).Select(item => new Class_zakazy
             {
                 Numer_zakazu = item.Object.Numer_zakazu,
                 Ilie_kosztowal = item.Object.Ilie_kosztowal,
                 Co_zakazano = item.Object.Co_zakazano

             }).ToList();

        }

        public async Task AddZakazy(string numer_zakazu, string ilie_kosztowal, string co_zakazano)
        {
            await __firebase
             .Child("Zakazy")
             .PostAsync(new Class_zakazy() { Numer_zakazu = numer_zakazu, Ilie_kosztowal = ilie_kosztowal, Co_zakazano = co_zakazano});
        }

        public async Task UpdateZakazy(string numer_zakazu, string ilie_kosztowal, string co_zakazano)
        {
            var toUpdatePerson = (await __firebase
             .Child("Zakazy")
             .OnceAsync<Class_zakazy>()).Where(a => a.Object.Numer_zakazu == numer_zakazu).FirstOrDefault();

            await __firebase
             .Child("Zakazy")
             .Child(toUpdatePerson.Key)
             .PutAsync(new Class_zakazy() { Numer_zakazu = numer_zakazu, Ilie_kosztowal = ilie_kosztowal, Co_zakazano = co_zakazano });

        }

        public async Task DeleteZakazy(string numer_zakazu)
        {
            var toDeleteZakazy = (await __firebase
             .Child("Zakazy")
             .OnceAsync<Class_zakazy>()).Where(a => a.Object.Numer_zakazu == numer_zakazu).FirstOrDefault();
            await __firebase.Child("Zakazy").Child(toDeleteZakazy.Key).DeleteAsync();
        }



    }
}
