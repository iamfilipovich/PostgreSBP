using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PostgreHotel.Data
{
    public class usluga
    {
        [Key]
        public int uslugaid { get; set; }

        public string naziv { get; set; }
        public int cijena { get; set; }

        // Foreign key property
        public int hotelid { get; set; }


    }
}
