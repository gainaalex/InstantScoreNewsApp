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
    public class ProxyMatchManager:IMatchManager,Subject
    {
        private const string Path = "Data\\";
        private List<User> _users;
        private User _currentUser;
        private RealMatchManager _realMatchManager;
        //lista userilor ce ascullta modificarile facute de admin
        private List<Subscriber> _subscribers;

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

        private void SubscribeAllUsers()
        {
            foreach (User user in _users)
            {
                if (!user.isAdmin())
                    Attach(user);
            }
        }

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

        public bool UserIsAdmin()
        {
            if(_currentUser!=null && _currentUser.AccesType==-1)
                return true;
            return false;
        }

        public Stack<Match> GetMatches()
        {
            return _realMatchManager.GetMatches();
        }
        public Stack<Event> GetEvents(Match match)
        {
            return _realMatchManager.GetEvents(match);
        }

        public void AddMatch(Match match)
        {
            if(UserIsAdmin())
            {
                _realMatchManager.AddMatch(match);
                Notify(match.ToString());
            }
        }
        public void RemoveMatch(Match match)
        {
            if (UserIsAdmin())
            {
                _realMatchManager.RemoveMatch(match);
                Notify(match.ToString());
            }
        }
        public void UpdateMatch(Match match, Match newMatch)
        {
            if (UserIsAdmin())
            {
                Match copy = new Match(match);
                _realMatchManager.UpdateMatch(match,newMatch);
                Notify("Meci actualizat: "+ copy.ToString()+" -> "+newMatch.ToString());
            }
        }

        public void AddEvent(Match match, Event e)
        {
            if (UserIsAdmin())
            {
                _realMatchManager.AddEvent(match, e);
                Notify("In meciul: "+match.ToString()+" -> "+e.ToString());
            }
        }
        public void DeleteEvent(Match match, Event e)
        {
            if (UserIsAdmin())
            {
                _realMatchManager.DeleteEvent(match, e);
                Notify("In meciul: " + match.ToString() + " a fost eliminat evenimentul " + e.ToString());
            }
        }

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

        public void AddUser(string username, string password)
        {
            //utilizatorul e salvat cu parola hash
            User newUser = new User(username, PasswordHasher.PasswordHasher.HashString (password), 0);
            _users.Add(newUser);
            //abonam fiecare cont nou
            Attach(newUser);
            SaveUsers();
        }

        public void Attach(Subscriber subscriber)
        {
            if(!_subscribers.Contains(subscriber))
                _subscribers.Add(subscriber);
        }

        public void Detach(Subscriber subscriber)
        {
            _subscribers.Remove(subscriber);
        }

        public void Notify(string notificare)
        {
            foreach(Subscriber subscriber in _subscribers)
            {
                subscriber.Update(notificare);
            }
        }
    }
}
