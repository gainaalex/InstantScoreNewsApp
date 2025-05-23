/************************************************************
 * Autor: Gaina Alexandru
 * Data crearii: 2025-05-20
 * Ultima modificare: 2025-05-20
 * Fisier: User.cs
 * Functionalitate: Constituie implementarea interfetei Subscriber, clasa fiind folosita pentru a stoca date despre user/admin
 ************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using ObserverLib;

namespace UserLib
{
    public class User:Subscriber
    {
        private readonly string _username, _password;
        private readonly int _accesType;
        
        public List<string> Notificari { get; }
        public User(in string username, in string password,in int accesType) 
        {
            //cerinta de format al username ului
            Regex regex = new Regex(@"^[a-zA-Z0-9_]{3,16}$");
            if (!regex.IsMatch(username))
                throw new ArgumentException("Username invalid, trebuie sa contina intre " +
                    "3-16 caractere ce constau in litere mari si mici, cifre si underscore (_)");
            _username = username;
            _password = password;
            if (accesType > 0 || accesType<-1)
                throw new Exception("Tip de acces neindentificat");
            _accesType = accesType;
            Notificari = new List<string>();
        }
        public string Username
        {
            get
            {
                return _username;
            }
        }
        public string Password 
        { 
            get 
            { 
                return _password; 
            } 
        }
        public int AccesType
        {
            get
            {
                return _accesType;
            }
        }
        public bool isAdmin()
        {
            return _accesType == -1?  true:  false;
        }

        public void Update(string notificare)
        {
            Notificari.Add(notificare);
        }
        public override string ToString() 
        {
            return _username + " " + _accesType;
        }
    }
}
