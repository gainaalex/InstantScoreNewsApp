/************************************************************
 * Autor: Turcu Andrei
 * Data crearii: 2025-05-20
 * Ultima modificare: 2025-05-23
 * Fisier: User.cs
 * Functionalitate: Constituie implementarea interfetei Subscriber, clasa fiind folosita pentru a stoca date despre user/admin
 ************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
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
        
        public List<string> Notificari 
        { 
            get; 
        }

        /// <summary>
        /// Constructor pentru clasa User.
        /// Verifica formatul username-ului si initializeaza datele utilizatorului.
        /// </summary>
        /// <param name="username">Numele de utilizator (3-16 caractere, litere, cifre, underscore)</param>
        /// <param name="password">Parola (hashuita)</param>
        /// <param name="accesType">Tipul de acces (-1 pentru admin, 0 pentru user obisnuit)</param>
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

        /// <summary>
        /// Returneaza numele de utilizator.
        /// </summary>
        public string Username
        {
            get
            {
                return _username;
            }
        }

        /// <summary>
        /// Returneaza parola utilizatorului (hashuita).
        /// </summary>
        public string Password 
        { 
            get 
            { 
                return _password; 
            } 
        }


        /// <summary>
        /// Returneaza tipul de acces al utilizatorului.
        /// </summary>
        public int AccesType
        {
            get
            {
                return _accesType;
            }
        }


        /// <summary>
        /// Verifica daca utilizatorul este admin.
        /// </summary>
        /// <returns>True daca este admin, altfel false</returns>
        public bool isAdmin()
        {
            return _accesType == -1?  true:  false;
        }

        /// <summary>
        /// Metoda apelata de subiect pentru a trimite o notificare catre acest utilizator.
        /// </summary>
        /// <param name="notificare">Mesajul de notificare</param>
        public void Update(string notificare)
        {
            Notificari.Add(notificare);
        }

        /// <summary>
        /// Returneaza o reprezentare textuala a obiectului User.
        /// </summary>
        /// <returns>Username-ul si tipul de acces sub forma string</returns>

        public override string ToString() 
        {
            return _username + " " + _accesType;
        }
    }
}
