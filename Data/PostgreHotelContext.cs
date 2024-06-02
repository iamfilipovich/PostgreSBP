using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PostgreHotel.Data;

namespace PostgreHotel.Data
{
    public class PostgreHotelContext : DbContext
    {
        public PostgreHotelContext (DbContextOptions<PostgreHotelContext> options)
            : base(options)
        {
        }

        public DbSet<PostgreHotel.Data.gosti> gosti { get; set; } = default!;
        public DbSet<PostgreHotel.Data.hotel> hotel { get; set; } = default!;
        public DbSet<PostgreHotel.Data.rezervacije> rezervacije { get; set; } = default!;
        public DbSet<PostgreHotel.Data.sobe> sobe { get; set; } = default!;
        public DbSet<PostgreHotel.Data.usluga> usluga { get; set; } = default!;
        public DbSet<PostgreHotel.Data.zaposlenici> zaposlenici { get; set; } = default!;
    }
}
