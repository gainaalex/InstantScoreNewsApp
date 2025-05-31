/************************************************************
 * Autor: Gaina Alexandru
 * Data crearii: 2025-05-20
 * Ultima modificare: 2025-05-20
 * Fisier: matchStats.cs
 * Functionalitate: Conține clasele de date necesare logicii de stocare a datelor despre meciuri.
 ************************************************************/


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MatchStats
{
    /// <summary>
    /// Data class ce stocheaza evenimentul cu minutul aferent producerii lui
    /// </summary>
    public class Event
    {
        public int minut;
        public string descriere;

        /// <summary>
        /// Constructor pentru clasa Event.
        /// Initializeaza un eveniment cu minutul si descrierea sa.
        /// </summary>
        /// <param name="minut">Minutul in care a avut loc evenimentul</param>
        /// <param name="descriere">Descrierea evenimentului</param>
        public Event(int minut, string descriere)
        {
            this.minut = minut;
            this.descriere = descriere;
        }

        /// <summary>
        /// Returneaza reprezentarea textuala a evenimentului (ex: 45' : Gol).
        /// </summary>
        /// <returns>Evenimentul sub forma string</returns>
        public override string ToString()
        {
            return minut + "'" + " : " + descriere;
        }
    }
    /// <summary>
    /// Data class ce stoceaza meciul cu datele despre echipele angrenate si evenimentele de pe parcurs
    /// </summary>
    public class Match
    {
        private string _gazda, _oaspete;
        private int _scorGazda, _scorOaspete;
        private List<Event> _evenimente;

        /// <summary>
        /// Proprietate pentru echipa gazda.
        /// </summary>
        public string Gazda
        {
            get 
            { 
                return _gazda;
            }
            set
            {
                _gazda = value;
            }
        }

        /// <summary>
        /// Proprietate pentru echipa oaspete.
        /// </summary>
        public string Oaspete
        {
            get 
            {
                return _oaspete;
            }
            set
            {
                _oaspete = value;
            }
        }

        /// <summary>
        /// Proprietate pentru scorul echipei gazda.
        /// </summary>
        public int ScorGazda
        {
            get
            { 
                return _scorGazda;
            }
            set 
            {
                _scorGazda = value;
            }
        }

        /// <summary>
        /// Proprietate pentru scorul echipei oaspete.
        /// </summary>
        public int ScorOaspete
        {
            get
            {
                return _scorOaspete;
            }
            set
            {
                _scorOaspete = value;
            }
        }

        /// <summary>
        /// Returneaza lista de evenimente ale meciului.
        /// </summary>
        public List<Event> Evenimente
        {
            get 
            {
                return _evenimente;
            }
        }

        /// <summary>
        /// Constructor de copiere pentru clasa Match.
        /// Creeaza o noua instanta pe baza unui meci existent.
        /// </summary>
        /// <param name="m">Meciul sursa</param>
        public Match(Match m)
        {
            this._gazda = m.Gazda;
            this._oaspete=m.Oaspete;
            this.ScorGazda=m.ScorGazda;
            this._scorOaspete = m.ScorOaspete;
            _evenimente = new List<Event>();
        }

        /// <summary>
        /// Constructor pentru clasa Match.
        /// Initializeaza un meci cu numele echipelor si scorurile initiale.
        /// Valideaza numele echipelor.
        /// </summary>
        /// <param name="gazda">Numele echipei gazda</param>
        /// <param name="oaspete">Numele echipei oaspete</param>
        /// <param name="scorGazda">Scorul echipei gazda</param>
        /// <param name="scorOaspete">Scorul echipei oaspete</param>
        public Match(string gazda, string oaspete, int scorGazda, int scorOaspete)
        {
            //detectie nume nerealiste/ gresite
            Regex regex = new Regex(@"^[a-zA-Z0-9\s-]{3,50}$");
            if (!regex.IsMatch(gazda) || !regex.IsMatch(oaspete))
                throw new ArgumentException("Nume echipa gazda sau oaspete incorecte, trebuie sa " +
                    "contina intre 3-50 caractere formate din litere mici si mari, inclusiv \"-\" si spatii");
            _gazda = gazda;
            _oaspete= oaspete;
            _scorGazda = scorGazda;
            _scorOaspete = scorOaspete;
            _evenimente = new List<Event>();
        }

        /// <summary>
        /// Adauga un eveniment in lista evenimentelor meciului.
        /// </summary>
        /// <param name="e">Evenimentul de adaugat</param>
        public void AddEvent(Event e)
        {
            _evenimente.Add(e);
        }

        /// <summary>
        /// Elimina un eveniment din lista evenimentelor meciului.
        /// </summary>
        /// <param name="e">Evenimentul de eliminat</param>
        public void RemoveEvent(Event e) 
        {
            _evenimente.Remove(e);
        }

        /// <summary>
        /// Returneaza o reprezentare textuala a meciului (ex: Romania 2:1 Franta).
        /// </summary>
        /// <returns>Descrierea meciului sub forma string</returns>
        public override string ToString()
        {
            return _gazda + " " + _scorGazda + ":" + _scorOaspete + " " + _oaspete;
        }
    }
}
