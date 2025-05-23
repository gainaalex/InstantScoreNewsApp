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
using MatchStats;


namespace MatchManager
{
    public interface IMatchManager
    {
        Stack<Match> GetMatches();
        Stack<Event> GetEvents(Match match);

        void AddMatch(Match match);
        void RemoveMatch(Match match);
        void UpdateMatch(Match match,Match newMatch);

        void AddEvent(Match match, Event e);
        void DeleteEvent(Match match, Event e);

        void UpdateEvent(Match match, Event e,Event newEvent);
    }
}
