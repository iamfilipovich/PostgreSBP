using System.ComponentModel.DataAnnotations;

namespace PostgreHotel.Data
{
    public class hotel
    {
        [Key]
        public int hotelid { get; set; }

        public string imehotela { get; set; }
        public string adresa { get; set; }


    }
}
