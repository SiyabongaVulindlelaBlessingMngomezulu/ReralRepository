using System.Collections.Generic;
using Commander.Models;
using Commander.Data;

namespace Commander.Data{
    public class MockCommander//: ICommanderRepo
    {
        
        public IEnumerable<Command> GetCommand(){
            var commandList = new List<Command>{
                 new Command(){Id = 4566, HowTo ="Boil an egg", Line= "Boil water", Platform = "Kettle & pan"}, 
                 new Command(){Id = 90456, HowTo ="Boil an egg", Line= "Boil water", Platform = "Kettle & pan"},
                 new Command(){Id = 34564, HowTo ="Boil an egg", Line= "Boil water", Platform = "Kettle & pan"},
                 new Command(){Id =109234, HowTo ="Boil an egg", Line= "Boil water", Platform = "Kettle & pan"},   
            };

            return commandList;
        }

        public Command GetCommandById(int id){
            return new Command(){Id =id, HowTo ="Boil an egg", Line= "Boil water", Platform = "Kettle & pan"};
        }

        public static void duUMockMe() { 
        
        }
    }
}