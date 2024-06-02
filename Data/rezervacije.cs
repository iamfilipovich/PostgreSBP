using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PostgreHotel.Data
{
    public class rezervacije
    {
        [Key]
        public int rezervacijaid { get; set; }

        // Foreign key properties
        public int gostid { get; set; }
        public int sobaid { get; set; }
        public DateTime datumdolaska { get; set; } = DateTime.UtcNow;
        public DateTime datumodlaska { get; set; } = DateTime.UtcNow;
    }
}
