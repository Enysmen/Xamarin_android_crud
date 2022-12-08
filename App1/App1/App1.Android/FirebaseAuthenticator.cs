using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using App1;
using App1.Droid;
using Firebase.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using DependencyAttribute = Xamarin.Forms.DependencyAttribute;

[assembly: Dependency(typeof(FirebaseAuthenticator))]
namespace App1.Droid
{
    public class FirebaseAuthenticator : IFirebaseAuthenticator
    {
        public async Task<string> CreateUserWithEmailAndPasswordAsync(string email, string password)
        {
            var authResult = await FirebaseAuth.Instance.CreateUserWithEmailAndPasswordAsync(email, password);

            var getTokenResult = await authResult.User.GetIdTokenAsync(false);

            return getTokenResult.Token;

            //throw new NotImplementedException();
        }
        public async Task<string> SignInWithEmailAndPasswordAsync(string email, string password)
        {
            try
            {

                var authResult = await FirebaseAuth.Instance.SignInWithEmailAndPasswordAsync(email, password);

                var getTokenResult = await authResult.User.GetIdTokenAsync(false);

                return getTokenResult.Token;
            }
            catch(FirebaseAuthInvalidUserException e)
            {
                e.PrintStackTrace();
                return "";
            }


            // throw new NotImplementedException();
        }





    }
}