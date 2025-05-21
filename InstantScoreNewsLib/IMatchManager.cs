/************************************************************
 * Autor: Gaina Alexandru
 * Data crearii: 2025-05-20
 * Ultima modificare: 2025-05-20
 * Fisier: IMatchManager.cs
 * Functionalitate: Constituie interfata pentru clasele ProxyMatchManager si RealMatchManager
 ************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstantScoreNewsLib
{
    public interface IMatchManager
    {
        public Stack<Match> GetMatches();
        public Stack<Event> GetEvents(Match match);

        public void AddMatch(Match match);
        public void RemoveMatch(Match match);
        public void UpdateMatch(Match match,Match newMatch);

        public void AddEvent(Match match, Event e);
        public void DeleteEvent(Match match, Event e);

        public void UpdateEvent(Match match, Event e,Event newEvent);
    }
}
