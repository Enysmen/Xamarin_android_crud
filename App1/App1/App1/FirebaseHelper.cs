using System;
using System.Collections.Generic;
using System.Text;
using Firebase.Database;
using System.Threading.Tasks;
using System.Linq;
using Firebase.Database.Query;
using Xamarin.Essentials;

namespace App1.Helperprac
{
    public class FirebaseHelper : Class_pracownik
    {
        FirebaseClient _firebase = new FirebaseClient("https://metamaze-36fa6-default-rtdb.firebaseio.com/");

        public async Task<List<Class_pracownik>> GetAllPracowniki()
        {
            return (await _firebase
             .Child("Pracowniki")
             .OnceAsync<Class_pracownik>()).Select(item => new Class_pracownik
             {
                 Name = item.Object.Name,
                 Email = item.Object.Email,
                 Imie = item.Object.Imie,
                 Kim_pracuje_w_firmie = item.Object.Kim_pracuje_w_firmie

             }).ToList();

        }

        public async Task AddPracowniki(string name , string email ,string imie,string kim_pracuje_w_firmie)
        {
            await _firebase
              .Child("Pracowniki")
              .PostAsync(new Class_pracownik() { Name = name ,Email = email , Imie = imie ,Kim_pracuje_w_firmie = kim_pracuje_w_firmie});

        }

        public async Task UpdatePracowniki(string name, string email, string imie, string kim_pracuje_w_firmie)
        {
            var toUpdatePerson = (await _firebase
             .Child("Pracowniki")
             .OnceAsync<Class_pracownik>()).Where(a => a.Object.Name == name).FirstOrDefault();


            await _firebase
             .Child("Pracowniki")
             .Child(toUpdatePerson.Key)
             .PutAsync(new Class_pracownik() { Name = name, Email = email, Imie = imie, Kim_pracuje_w_firmie = kim_pracuje_w_firmie });
        }

        public async Task DeletePracowniki(string name)
        {
            var toDeletePerson = (await _firebase
              .Child("Pracowniki")
              .OnceAsync<Class_pracownik>()).Where(a => a.Object.Name == name).FirstOrDefault();
            await _firebase.Child("Pracowniki").Child(toDeletePerson.Key).DeleteAsync();
        }


    }
    
}
