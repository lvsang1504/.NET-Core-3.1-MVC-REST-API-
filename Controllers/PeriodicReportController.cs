using System.Collections.Generic;
using AutoMapper;
using Commander.Data;
using Commander.Dtos;
using Commander.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace Commander.Controllers
{
    [Route("api/periodic-report")]
    [ApiController]
    public class PeriodicReportController : ControllerBase
    {
        private readonly IPeriodicReportItemRepo _repository;
        private readonly IMapper _mapper;

        public PeriodicReportController(IPeriodicReportItemRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        //GET api/periodic-report
        [HttpGet]
        public ActionResult<IEnumerable<PeriodicReportItemReadDto>> GetAllPeriodicReport()
        {
            var commandItems = _repository.GetAllPeriodicReports();

            return Ok(_mapper.Map<IEnumerable<PeriodicReportItemReadDto>>(commandItems));
        }

        //GET api/periodic-report/idStudent={id}
        [HttpGet("idStudent={id}")]
        public ActionResult<IEnumerable<PeriodicReportItemReadDto>> GetPeriodicReportByIdStudent(string id)
        {
            var commandItems = _repository.GetPeriodicReportByIdStudent(id);

            return Ok(_mapper.Map<IEnumerable<PeriodicReportItemReadDto>>(commandItems));
        }

        //GET api/periodic-report/{id}
        [HttpGet("{id}", Name = "GetPeriodicReportById")]
        public ActionResult<PeriodicReportItemReadDto> GetPeriodicReportById(int id)
        {
            var commandItem = _repository.GetPeriodicReportById(id);
            if (commandItem != null)
            {
                return Ok(_mapper.Map<PeriodicReportItemReadDto>(commandItem));
            }
            return NotFound();
        }
        
        //POST api/periodic-report
        [HttpPost]
        public ActionResult<PeriodicReportItemReadDto> CreateCommand(PeriodicReportItemCreateDto commandCreateDto)
        {
            var commandModel = _mapper.Map<PeriodicReportItem>(commandCreateDto);
            _repository.CreatePeriodicReport(commandModel);
            _repository.SaveChanges();

            var commandReadDto = _mapper.Map<PeriodicReportItemReadDto>(commandModel);

            // return Ok(commandReadDto);
            return CreatedAtRoute(nameof(GetPeriodicReportById), new {Id = commandReadDto.Id}, commandReadDto);
        }

        //PUT api/periodic-report/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateCommand(int id, PeriodicReportItemUpdateDto commandUpdateDto) 
        {
            var commandModelFromRepo = _repository.GetPeriodicReportById(id);
            if(commandModelFromRepo == null) 
            {
                return NotFound();
            }

            _mapper.Map(commandUpdateDto, commandModelFromRepo);

            _repository.UpdatePeriodicReport(commandModelFromRepo);

            _repository.SaveChanges();

            return NoContent();
        }
        // PATCH api/periodic-report/{id}
        [HttpPatch("{id}")]
        public ActionResult PartialCommandUpdate(int id, JsonPatchDocument<PeriodicReportItemUpdateDto> patchDoc)
        {
             var commandModelFromRepo = _repository.GetPeriodicReportById(id);
            if(commandModelFromRepo == null) 
            {
                return NotFound();
            }

            var commandToPatch = _mapper.Map<PeriodicReportItemUpdateDto>(commandModelFromRepo);
            patchDoc.ApplyTo(commandToPatch,ModelState);

            if(!TryValidateModel(commandToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(commandToPatch, commandModelFromRepo);

            _repository.UpdatePeriodicReport(commandModelFromRepo);

            _repository.SaveChanges();

            return NoContent();
        }

        //DELETE api/periodic-report/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteCommand(int id)
        {
            var commandModelFromRepo = _repository.GetPeriodicReportById(id);
            if(commandModelFromRepo == null) 
            {
                return NotFound();
            }

            _repository.DeletePeriodicReport(commandModelFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }
    }
}