using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PostgreHotel.Data
{
    public class sobe
    {
        [Key]
        public int sobaid { get; set; }

        public string tipsobe { get; set; }
        public int brojkreveta { get; set; }
        public int cijena { get; set; }

        // Foreign key property
        public int hotelid { get; set; }


    }
}
