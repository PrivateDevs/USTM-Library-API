using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using USTMLibrary_API.model;

namespace USTMLibrary_API.Data
{
    public class USTMLibrary_APIContext : DbContext
    {
        public USTMLibrary_APIContext (DbContextOptions<USTMLibrary_APIContext> options)
            : base(options)
        {
        }

        public DbSet<USTMLibrary_API.model.Bibliography> Bibliography { get; set; } = default!;
    }
}
