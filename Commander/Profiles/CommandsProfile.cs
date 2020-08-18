using AutoMapper;
using Commander.Dtos;
using Commander.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Commander.Profiles
{
    public class CommandsProfile: Profile // Used for mapping POCOs to DTOs and vice versa 
    {
        public CommandsProfile()
        {
            //What we are mapping from and what \we're mapping to 
            //Source -> Target
            CreateMap<Command, CommandReadDto>(); // get
            CreateMap<CommandCreateDto, Command>(); //post
            CreateMap<CommandUpdateDto, Command>(); //put
            CreateMap<Command, CommandUpdateDto>(); // patch map 
        }
    }
}
