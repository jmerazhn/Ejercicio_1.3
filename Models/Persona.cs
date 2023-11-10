using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio_1._3.Models
{
    //[Table("personas")]
    public class Persona
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }


        [MaxLength(60)]
        public string Nombre { get; set; }


        [MaxLength(60)]
        public string Apellidos { get; set; }



        public String Edad { get; set; }

        [MaxLength(60)]
        public string Correo { get; set; }

        [MaxLength(60)]
        public string Direccion { get; set; }
    }
}
