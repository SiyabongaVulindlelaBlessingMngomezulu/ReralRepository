//using Microsoft.AspNetCore
using Microsoft.EntityFrameworkCore;
using Commander.Models;

namespace Commander.Data{
    public class CommanderContext: DbContext
    {
        public CommanderContext(DbContextOptions<CommanderContext> opt):  base(opt){ 

        }


        //Fetches database data into a data structure DbSet
        public DbSet<Command> Commands{ get; set; }

    }
}