using Commander.Models;
using System.Collections.Generic;

namespace Commander.Data
{
    public interface ICommanderRepo
    {
        IEnumerable<Command> GetCommand();

        Command GetCommandById(int id);

        void CreateCommand(Command cmd);

        bool SaveChanges();

        void UpdateCommand(Command cmd);

        void DeleteCommand(Command cmd);
    }
}
