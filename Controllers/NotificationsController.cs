using System.Collections.Generic;
using AutoMapper;
using Commander.Data;
using Commander.Dtos;
using Commander.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace Commander.Controllers
{
    [Route("api/notifications")]
    [ApiController]
    public class NotificationsController : ControllerBase
    {
        private readonly INotificationRepo _repository;
        private readonly IMapper _mapper;

        public NotificationsController(INotificationRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        //GET api/notifications
        [HttpGet]
        public ActionResult<IEnumerable<NotificationReadDto>> GetAllNotifications()
        {
            var commandItems = _repository.GetAllNotifications();

            return Ok(_mapper.Map<IEnumerable<NotificationReadDto>>(commandItems));
        }

        //GET api/notifications/idStudent={id}
        [HttpGet("idStudent={id}")]
        public ActionResult<IEnumerable<NotificationReadDto>> GetNotificationByIdStudent(string id)
        {
            var commandItems = _repository.GetNotificationByIdStudent(id);

            return Ok(_mapper.Map<IEnumerable<NotificationReadDto>>(commandItems));
        }

        //GET api/notifications/{id}
        [HttpGet("{id}", Name = "GetNotificationById")]
        public ActionResult<NotificationReadDto> GetNotificationById(int id)
        {
            var commandItem = _repository.GetNotificationById(id);
            if (commandItem != null)
            {
                return Ok(_mapper.Map<NotificationReadDto>(commandItem));
            }
            return NotFound();
        }
        
        //POST api/notifications
        [HttpPost]
        public ActionResult<NotificationReadDto> CreateNotification(NotificationCreateDto commandCreateDto)
        {
            var commandModel = _mapper.Map<Notification>(commandCreateDto);
            _repository.CreateNotification(commandModel);
            _repository.SaveChanges();

            var commandReadDto = _mapper.Map<NotificationReadDto>(commandModel);

            // return Ok(commandReadDto);
            return CreatedAtRoute(nameof(GetNotificationById), new {Id = commandReadDto.Id}, commandReadDto);
        }

        //PUT api/notifications/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateNotification(int id, NotificationUpdateDto commandUpdateDto) 
        {
            var commandModelFromRepo = _repository.GetNotificationById(id);
            if(commandModelFromRepo == null) 
            {
                return NotFound();
            }

            _mapper.Map(commandUpdateDto, commandModelFromRepo);

            _repository.UpdateNotification(commandModelFromRepo);

            _repository.SaveChanges();

            return NoContent();
        }
        // PATCH api/notifications/{id}
        [HttpPatch("{id}")]
        public ActionResult PartialNotificationUpdate(int id, JsonPatchDocument<NotificationUpdateDto> patchDoc)
        {
             var commandModelFromRepo = _repository.GetNotificationById(id);
            if(commandModelFromRepo == null) 
            {
                return NotFound();
            }

            var commandToPatch = _mapper.Map<NotificationUpdateDto>(commandModelFromRepo);
            patchDoc.ApplyTo(commandToPatch,ModelState);

            if(!TryValidateModel(commandToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(commandToPatch, commandModelFromRepo);

            _repository.UpdateNotification(commandModelFromRepo);

            _repository.SaveChanges();

            return NoContent();
        }

        //DELETE api/notifications/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteNotification(int id)
        {
            var commandModelFromRepo = _repository.GetNotificationById(id);
            if(commandModelFromRepo == null) 
            {
                return NotFound();
            }

            _repository.DeleteNotification(commandModelFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }
    }
}