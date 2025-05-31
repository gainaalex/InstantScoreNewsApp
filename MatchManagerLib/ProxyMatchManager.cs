/************************************************************
 * Autor: Gaina Alexandru
 * Data crearii: 2025-05-20
 * Ultima modificare: 2025-05-23
 * Fisier: ProxyMatchManager.cs
 * Functionalitate: Conține logica de identificare a utilizatotului conectat si posibilitatile acestuia
 ************************************************************/


using System;
using System.IO;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserLib;
using ObserverLib;
using PasswordHasher;
using MatchStats;


namespace MatchManager
{
    /// <summary>
    /// Clasa care actioneaza ca un proxy intre interfata utilizatorului si gestionarea reala a meciurilor.
    /// Se ocupa de autentificare, controlul accesului si notificarea utilizatorilor non-admin.
    /// </summary>
    public class ProxyMatchManager:IMatchManager,Subject
    {
        private const string Path = "Data\\";
        private List<User> _users;
        private User _currentUser;
        private RealMatchManager _realMatchManager;
        //lista userilor ce ascullta modificarile facute de admin
        private List<Subscriber> _subscribers;

        /// <summary>
        /// Returneaza sau seteaza utilizatorul curent autentificat in aplicatie.
        /// </summary>
        public User CurrentUser 
        { 
            get 
            { 
                return _currentUser; 
            } 
            set 
            { 
                _currentUser = value;
            }
        }
        /// <summary>
        /// Constructorul clasei. Incarca utilizatorii din fisierul text si ii aboneaza pe cei non-admin.
        /// </summary>
        public ProxyMatchManager()
        {
            //introducere utilizatorul admin
            try
            {
                StreamReader sr = new StreamReader(Path + "utilizatori.txt");
                string[] lines = sr.ReadToEnd().Split("\r\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                sr.Close();

                int numberOfLevels = lines.Length;

                _users = new List<User>();
                for (int i = 0; i < numberOfLevels; i++)
                {
                    string[] infos = lines[i].Split('\t');
                    _users.Add(new User(infos[0], infos[1], int.Parse(infos[2])));
                }
            }catch (Exception ex) 
            {
                Debug.WriteLine(ex.Message);
            }
            _realMatchManager = new RealMatchManager();
            _subscribers = new List<Subscriber>();
            SubscribeAllUsers();
        }

        /// <summary>
        /// Aboneaza toti utilizatorii non-admin la notificari.
        /// </summary>
        private void SubscribeAllUsers()
        {
            foreach (User user in _users)
            {
                if (!user.isAdmin())
                    Attach(user);
            }
        }

        /// <summary>
        /// Verifica daca datele introduse de utilizator corespund unui cont existent.
        /// </summary>
        /// <param name="username">Numele de utilizator introdus.</param>
        /// <param name="password">Parola introdusa (necriptata).</param>
        /// <returns>Adevarat daca autentificarea este reusita, altfel fals.</returns>
        public bool Login(String username, String password)
        {
            // determinare hash parola introdusa de user
            String hashedPassword=PasswordHasher.PasswordHasher.HashString(password);
            foreach (User user in _users) 
            {
                if(user.Username==username && user.Password== hashedPassword)
                {
                    _currentUser = user;
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Verifica daca utilizatorul curent are drepturi de administrator.
        /// </summary>
        /// <returns>Adevarat daca este admin, altfel fals.</returns>
        public bool UserIsAdmin()
        {
            if(_currentUser!=null && _currentUser.AccesType==-1)
                return true;
            return false;
        }

        /// <summary>
        /// Returneaza lista meciurilor din managerul real.
        /// </summary>
        public Stack<Match> GetMatches()
        {
            return _realMatchManager.GetMatches();
        }

        /// <summary>
        /// Returneaza evenimentele asociate unui meci.
        /// </summary>
        /// <param name="match">Meciul pentru care se cer evenimentele.</param>
        public Stack<Event> GetEvents(Match match)
        {
            return _realMatchManager.GetEvents(match);
        }

        /// <summary>
        /// Adauga un meci daca utilizatorul este admin si trimite notificare.
        /// </summary>
        /// <param name="match">Meciul de adaugat.</param>
        public void AddMatch(Match match)
        {
            if(UserIsAdmin())
            {
                _realMatchManager.AddMatch(match);
                Notify(match.ToString());
            }
        }

        /// <summary>
        /// Sterge un meci daca utilizatorul este admin si trimite notificare.
        /// </summary>
        /// <param name="match">Meciul de sters.</param>
        public void RemoveMatch(Match match)
        {
            if (UserIsAdmin())
            {
                _realMatchManager.RemoveMatch(match);
                Notify(match.ToString());
            }
        }

        /// <summary>
        /// Actualizeaza un meci daca utilizatorul este admin si trimite notificare.
        /// </summary>
        /// <param name="match">Meciul original.</param>
        /// <param name="newMatch">Noul meci cu datele actualizate.</param>
        public void UpdateMatch(Match match, Match newMatch)
        {
            if (UserIsAdmin())
            {
                Match copy = new Match(match);
                _realMatchManager.UpdateMatch(match,newMatch);
                Notify("Meci actualizat: "+ copy.ToString()+" -> "+newMatch.ToString());
            }
        }

        /// <summary>
        /// Adauga un eveniment la un meci daca utilizatorul este admin si trimite notificare.
        /// </summary>
        public void AddEvent(Match match, Event e)
        {
            if (UserIsAdmin())
            {
                _realMatchManager.AddEvent(match, e);
                Notify("In meciul: "+match.ToString()+" -> "+e.ToString());
            }
        }

        /// <summary>
        /// Sterge un eveniment dintr-un meci daca utilizatorul este admin si trimite notificare.
        /// </summary>
        public void DeleteEvent(Match match, Event e)
        {
            if (UserIsAdmin())
            {
                _realMatchManager.DeleteEvent(match, e);
                Notify("In meciul: " + match.ToString() + " a fost eliminat evenimentul " + e.ToString());
            }
        }

        /// <summary>
        /// Actualizeaza un eveniment intr-un meci daca utilizatorul este admin si trimite notificare.
        /// </summary>
        public void UpdateEvent(Match match, Event e, Event newEvent)
        {
            if (UserIsAdmin())
            {
                _realMatchManager.UpdateEvent(match, e, newEvent);
                Notify("In meciul: " + match.ToString() + " a fost actualizat evenimentul : " + 
                    e.ToString()+" cu :"+newEvent.ToString());
            }
        }
        /// <summary>
        /// Aduce mofificarile efectuate in aplicatie in fisierul .txt
        /// </summary>
        private void SaveUsers()
        {
            StreamWriter sw = new StreamWriter(Path + "utilizatori.txt");
            foreach (User user in _users)
            {
                sw.WriteLine($"{user.Username}\t{user.Password}\t{user.AccesType}");
            }
            sw.Close();
        }

        /// <summary>
        /// Adauga un nou utilizator normal (non-admin), il salveaza in fisier si il aboneaza.
        /// </summary>
        public void AddUser(string username, string password)
        {
            //utilizatorul e salvat cu parola hash
            User newUser = new User(username, PasswordHasher.PasswordHasher.HashString (password), 0);
            _users.Add(newUser);
            //abonam fiecare cont nou
            Attach(newUser);
            SaveUsers();
        }

        /// <summary>
        /// Ataseaza un nou abonat pentru notificari (daca nu este deja abonat).
        /// </summary>
        public void Attach(Subscriber subscriber)
        {
            if(!_subscribers.Contains(subscriber))
                _subscribers.Add(subscriber);
        }

        /// <summary>
        /// Elimina un abonat din lista de notificare.
        /// </summary>
        public void Detach(Subscriber subscriber)
        {
            _subscribers.Remove(subscriber);
        }

        /// <summary>
        /// Trimite o notificare tuturor abonatilor existenti.
        /// </summary>
        public void Notify(string notificare)
        {
            foreach(Subscriber subscriber in _subscribers)
            {
                subscriber.Update(notificare);
            }
        }
    }
}
