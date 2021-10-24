using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace PropertyApp.Models
{
    class Tareas
    {
        [PrimaryKey, AutoIncrement]
        public int TarId { get; set; }
        public bool TarStatus { get; set; }
        public string TarNombre { get; set; }
        public string TarDescripcion { get; set; }
    }
}
