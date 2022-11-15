using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eindopdracht {
    // Klasse gemaakt op basis van de database tabel User
    internal class User {
        public int Id { get; set; }
        public static string Username { get; set; }
        public string Password { get; set; }
        public bool LoggedIn { get; set; }
    }
}
