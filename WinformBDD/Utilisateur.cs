﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectinBDD
{
    /// <summary>
    /// Creation de la class Utilisateur avec les champ correspondant a la BDD
    /// elle sera utiliser tout au long de l'application
    /// </summary>
    internal class Utilisateur
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string DtNaiss { get; set; }
    }
}
