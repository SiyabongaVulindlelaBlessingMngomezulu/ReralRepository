using Commander.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Commander.Data
{
    public class SQLCommanderRepo : ICommanderRepo
    {
        //This is the field that allows this class to access data from MS SQL Server 
        private CommanderContext _context;

        public SQLCommanderRepo(CommanderContext context)
        {
            _context = context;
        }

        public void UpdateCommand(Command cmd)//In this case cmd comes from dbset in EF
        {
            //throw new NotImplementedException();
        }

        void ICommanderRepo.CreateCommand(Command cmd)
        {
            if (cmd == null)
            {
                throw new ArgumentException();
            }
            else {
                _context.Commands.Add(cmd);
                
            }
        }

        void ICommanderRepo.DeleteCommand(Command cmd)
        {
            _context.Commands.Remove(cmd);
        }

        IEnumerable<Command> ICommanderRepo.GetCommand()
        {
            //returns abstracted form of database data then converts it into a list 
            return _context.Commands.ToList();
        }

        Command ICommanderRepo.GetCommandById(int id)
        {
            return _context.Commands.FirstOrDefault(
                    p =>  p.Id == id                   
                );
        }

        bool ICommanderRepo.SaveChanges()
        {
            //Commits changes done by entity framework onto the database provider
             return (_context.SaveChanges()>= 0);
        }

        void ICommanderRepo.UpdateCommand(Command cmd)
        {
            throw new NotImplementedException();
        }
    }
}
