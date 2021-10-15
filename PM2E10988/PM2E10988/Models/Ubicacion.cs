using SQLite;
using System;

namespace PM2E10988.Models
{
    public class Ubicacion
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [MaxLength(50)]
        public double Lat { get; set; }

        [MaxLength(50)]
        public double Lon { get; set; }

        [MaxLength(300)]
        public String Descl { get; set; }

        [MaxLength(100)]
        public String Descc { get; set; }
    }
}
