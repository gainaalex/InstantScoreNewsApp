/************************************************************
 * Autor: Gaina Alexandru
 * Data crearii: 2025-05-20
 * Ultima modificare: 2025-05-20
 * Fisier: Subject.cs
 * Functionalitate: Consituie interfata pentru functionalitatile puse la dispozitia adminului ce poate trimite notificari userilor
 ************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstantScoreNewsLib
{
    /// <summary>
    /// Clasa ce constituie subiectul observatorilor, 
    /// aceasta notifica toti userii de actiunile Adminului
    /// </summary>
    public interface Subject
    {
        void Attach(Subscriber subscriber);
        void Detach(Subscriber subscriber);
        void Notify(string notificare);
    }
}
