/************************************************************
 * Autor: Turcu Andrei
 * Data crearii: 2025-05-20
 * Ultima modificare: 2025-05-20
 * Fisier: Subcriber.cs
 * Functionalitate: Consituie interfata pentru functionalitatile puse la dispozitia userilor ce primesc mesajele "notificare" de la admin
 ************************************************************/


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverLib
{
    /// <summary>
    /// Interfata folosita in implemenatarae design pattern-ului 
    /// Observer, reprezinta useriii ce asculta actiunile Adminului
    /// </summary>
    public interface Subscriber
    {
        void Update(string notificare);
    }
}
