using Microsoft.AspNetCore.Mvc;
using Commander.Models;
using Commander.Data;
using System.Collections.Generic;
using AutoMapper;
using Commander.Dtos;
using Microsoft.AspNetCore.JsonPatch;

namespace Commander.Controllers{

    [ApiController]
    [Route("api/commands")]
    public class CommandsController : ControllerBase
    {
        private readonly ICommanderRepo _repository;
        private readonly IMapper _mapper;

        public CommandsController(ICommanderRepo repository, IMapper mapper) {
            _repository = repository;
            _mapper = mapper;
        }
        // private readonly MockCommander repository = new MockCommander();
        [HttpGet]
        public ActionResult<IEnumerable<CommandReadDto>> GetCommand() {
            var httpCommand = _repository.GetCommand();
            if (httpCommand != null) {
                return Ok(_mapper.Map<IEnumerable<CommandReadDto>>(httpCommand));
            } else {
                return NotFound();
            }

        }


        [HttpGet("{id}", Name = "GetCommandById")]
        public ActionResult<CommandReadDto> GetCommandById(int id) {
            var httpCommand = _repository.GetCommandById(id);

            if (httpCommand != null)
            {
                return Ok(_mapper.Map<CommandReadDto>(httpCommand)/*_repository.GetCommandById(id)*/);
            }
            else {
                return NotFound();
            }
        }

        [HttpPost]

        //Perhaps c# is able to take the json data from the client and then convert it into a DTO
        //on the server side
        public ActionResult<CommandCreateDto> CreateCommand(CommandCreateDto cmd) {

            var commandModel = _mapper.Map<Command>(cmd);
            _repository.CreateCommand(commandModel);

            //Commit changes to data provider 
            _repository.SaveChanges();

            var commandReadDto = _mapper.Map<CommandReadDto>(commandModel);

            //return Ok(commandModel);
            return CreatedAtRoute(nameof(GetCommandById), new { Id = commandModel.Id }, commandModel);


        }

        [HttpPut("{id}")]
        public ActionResult<CommandUpdateDto> UpdateCommand(int id, CommandUpdateDto cudto) {



            var commandModel = _repository.GetCommandById(id);//_mapper.Map<Command>(cudto);

            if (commandModel == null) {
                return NotFound();
            }
            else {
                _mapper.Map(cudto, commandModel);
                _repository.UpdateCommand(commandModel);
                _repository.SaveChanges();
                return NoContent();
            }

            //_repository.UpdateCommand(commandModel);
            //return Ok();
        }


        [HttpPatch("{id}")]
        public ActionResult PartialCommandUpdate(int id, JsonPatchDocument<CommandUpdateDto> patchDoc) {

            var httpCommand = _repository.GetCommandById(id);

            if (httpCommand == null)
            {
                return NotFound();
            }
                 var commandTopatch = _mapper.Map<CommandUpdateDto>(httpCommand);
                patchDoc.ApplyTo(commandTopatch, ModelState);//ModelState ensures validations are valid 

                //if (TryValidateModel(commandTopatch)) {
                //    return ValidationProblem();
                //}

                _mapper.Map(commandTopatch, httpCommand);
                _repository.UpdateCommand(httpCommand);
                _repository.SaveChanges();

                return NoContent();
            
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteCommand(int id) {
            var httpCommand = _repository.GetCommandById(id);

            if (httpCommand == null)
            {
                return NotFound();
            }

            _repository.DeleteCommand(httpCommand);
            _repository.SaveChanges();
            return NoContent();
        }
    }
}