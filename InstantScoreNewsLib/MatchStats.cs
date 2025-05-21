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

namespace InstantScoreNewsLib
{
    /// <summary>
    /// Data class ce stocheaza evenimentul cu minutul aferent producerii lui
    /// </summary>
    public class Event
    {
        public int minut;
        public String descriere;

        public Event(int minut, string descriere)
        {
            this.minut = minut;
            this.descriere = descriere;
        }

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

        public List<Event> Evenimente
        {
            get 
            {
                return _evenimente;
            }
        }
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

        public void AddEvent(Event e)
        {
            _evenimente.Add(e);
        }
        public void RemoveEvent(Event e) 
        {
            _evenimente.Remove(e);
        }

        public override string ToString()
        {
            return _gazda + " " + _scorGazda + ":" + _scorOaspete + " " + _oaspete;
        }
    }
}
