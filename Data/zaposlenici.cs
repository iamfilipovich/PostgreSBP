using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PostgreHotel.Data
{
    public class zaposlenici
    {
        [Key]
        public int zaposlenikid { get; set; }

        public string ime { get; set; }
        public string prezime { get; set; }
        public string poziija { get; set; }
        public int placa { get; set; }

        // Foreign key property
        public int hotelid { get; set; }

    }
}
