/************************************************************
 * Autor: Gaina Alexandru
 * Data crearii: 2025-05-20
 * Ultima modificare: 2025-05-23
 * Fisier: RealMatchManager.cs
 * Functionalitate: Conține logica manipulare a datelor despre meciuri si despre evenimentele din acestea
 ************************************************************/

using System;
using System.IO;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MatchStats;



namespace MatchManager
{
    public class RealMatchManager:IMatchManager
    {
        private static List<Match> _matches;
        private const string Path = "Data\\";
        
        public RealMatchManager()
        {

        }

        static RealMatchManager()
        {
            //incarca in memoria programului datele despre meciuri
            try
            {
                StreamReader sr = new StreamReader(Path + "meciuri.txt");
                string[] lines = sr.ReadToEnd().Split("\r\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                sr.Close();

                int numberOfLevels = lines.Length;

                _matches = new List<Match>();
                for (int i = 0; i < numberOfLevels; i++)
                {
                    string[] infos = lines[i].Split('\t');
                    _matches.Add(new Match(infos[0], infos[1], int.Parse(infos[2]), int.Parse(infos[3])));
                }
            }
            catch (Exception exc)
            {
                Debug.WriteLine(exc.Message);
            }
        }

        public Stack<Match> GetMatches()
        {
            //folosesc Stack pt ca ultimele update uri sa fie afisate cu prioritate
            Stack<Match> stack= new Stack<Match>();
            foreach (Match m in _matches)
            {
                stack.Push(m);
            }
            return stack;
        }
        public Stack<Event> GetEvents(Match m)
        {
            Stack<Event> stack = new Stack<Event>();
            int index = _matches.IndexOf(m);
            if (index != -1)
            {
                foreach (Event e in _matches[index].Evenimente)
                {
                    stack.Push(e);
                }
            }
            return stack;
        }

        public void AddMatch(Match match)
        {
            _matches.Add(match);
        }
        public void RemoveMatch(Match match)
        {
            _matches.Remove(match);
        }
        public void UpdateMatch(Match match, Match newMatch)
        {
            int index=_matches.IndexOf(match);
            if (index != -1)
            { 
                _matches[index].Gazda = newMatch.Gazda;
                _matches[index].Oaspete = newMatch.Oaspete;
                _matches[index].ScorGazda = newMatch.ScorGazda;
                _matches[index].ScorOaspete=newMatch.ScorOaspete;
            }
        }

        public void AddEvent(Match match, Event e)
        {
            int index = _matches.IndexOf(match);
            if (index!=-1)
            {
                _matches[index].Evenimente.Add(e);    
            }
            
        }
        public void DeleteEvent(Match match, Event e)
        {
            int index = _matches.IndexOf(match);
            if (index != -1)
            {
                int cont = _matches[index].Evenimente.IndexOf(e);
                if(cont!=-1)
                {
                    _matches[index].Evenimente.Remove(e);
                }
            }
        }

        public void UpdateEvent(Match match, Event e, Event newEvent)
        {
            int index = _matches.IndexOf(match);
            if(index!=-1)
            {
                int cont = _matches[index].Evenimente.IndexOf(e);
                if(cont!=-1)
                {
                    _matches[index].Evenimente[cont] = newEvent;
                }
            }
        }
    }
}
