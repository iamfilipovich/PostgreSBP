using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PostgreHotel.Data
{
    public class gosti
    {
        [Key]
        public int gostid { get; set; }

        public string ime { get; set; }
        public string prezime { get; set; }
        public string adresa { get; set; }
        public string telefon { get; set; }
        public string email { get; set; }

    }
}
