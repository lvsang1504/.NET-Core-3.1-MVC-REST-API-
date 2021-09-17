using System.Collections.Generic;
using AutoMapper;
using Commander.Data;
using Commander.Dtos;
using Commander.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace Commander.Controllers
{
    [Route("api/registers")]
    [ApiController]
    public class RegistersController : ControllerBase
    {
        private readonly IRegisterRepo _repository;
        private readonly IMapper _mapper;

        public RegistersController(IRegisterRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        //GET api/Registers
        [HttpGet]
        public ActionResult<IEnumerable<RegisterReadDto>> GetAllRegisters()
        {
            var registerItems = _repository.GetAllRegisters();

            return Ok(_mapper.Map<IEnumerable<RegisterReadDto>>(registerItems));
        }

        //GET api/Registers/{id}
        [HttpGet("{id}", Name = "GetRegisterById")]
        public ActionResult<RegisterReadDto> GetRegisterById(int id)
        {
            var registerItem = _repository.GetRegisterById(id);
            if (registerItem != null)
            {
                return Ok(_mapper.Map<RegisterReadDto>(registerItem));
            }
            return NotFound();
        }


        //GET api/registers/firebaseKey={id}
        [HttpGet("firebaseKey={id}", Name = "GetRegisterByIdFirebase")]
        public ActionResult<RegisterReadDto> GetRegisterByIdFirebase(string id)
        {
            var registerItem = _repository.GetRegisterByIdFirebase(id);
            if (registerItem != null)
            {
                return Ok(_mapper.Map<RegisterReadDto>(registerItem));
            }
            return NotFound();
        }

        //POST api/registers
        [HttpPost]
        public ActionResult<RegisterReadDto> CreateRegister(RegisterCreateDto registerCreateDto)
        {
            var registerModel = _mapper.Map<Register>(registerCreateDto);
            _repository.CreateRegister(registerModel);
            _repository.SaveChanges();

            var commandReadDto = _mapper.Map<RegisterReadDto>(registerModel);

            // return Ok(commandReadDto);
            return CreatedAtRoute(nameof(GetRegisterById), new {Id = commandReadDto.Id}, commandReadDto);
        }

        //PUT api/registers/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateRegister(int id, RegisterUpdateDto registerUpdateDto) 
        {
            var registerModelFromRepo = _repository.GetRegisterById(id);
            if(registerModelFromRepo == null) 
            {
                return NotFound();
            }

            _mapper.Map(registerUpdateDto, registerModelFromRepo);

            _repository.UpdateRegister(registerModelFromRepo);

            _repository.SaveChanges();

            return NoContent();
        }

        //PUT api/registers/firebaseKey={firebaseKey}
        [HttpPut("update={firebaseKey}")]
        public ActionResult UpdateRegisterByFirebaseKey(string  firebaseKey, RegisterUpdateDto registerUpdateDto)
        {
            var registerModelFromRepo = _repository.GetRegisterByIdFirebase(firebaseKey);
            if (registerModelFromRepo == null)
            {
                return NotFound();
            }

            _mapper.Map(registerUpdateDto, registerModelFromRepo);

            _repository.UpdateRegister(registerModelFromRepo);

            _repository.SaveChanges();

            return NoContent();
        }

        // PATCH api/registers/{id}
        [HttpPatch("{id}")]
        public ActionResult PartialRegisterUpdate(int id, JsonPatchDocument<RegisterUpdateDto> patchDoc)
        {
             var registerModelFromRepo = _repository.GetRegisterById(id);
            if(registerModelFromRepo == null) 
            {
                return NotFound();
            }

            var commandToPatch = _mapper.Map<RegisterUpdateDto>(registerModelFromRepo);
            patchDoc.ApplyTo(commandToPatch,ModelState);

            if(!TryValidateModel(commandToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(commandToPatch, registerModelFromRepo);

            _repository.UpdateRegister(registerModelFromRepo);

            _repository.SaveChanges();

            return NoContent();
        }

        //DELETE api/registers/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteRegister(int id)
        {
            var registerModelFromRepo = _repository.GetRegisterById(id);
            if(registerModelFromRepo == null) 
            {
                return NotFound();
            }

            _repository.DeleteRegister(registerModelFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }
    }
}