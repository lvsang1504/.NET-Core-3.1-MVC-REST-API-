using System.Collections.Generic;
using AutoMapper;
using Commander.Data;
using Commander.Dtos;
using Commander.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace Commander.Controllers
{
    [Route("api/topics")]
    [ApiController]
    public class TopicsController : ControllerBase
    {
        private readonly ITopicRepo _repository;
        private readonly IMapper _mapper;

        public TopicsController(ITopicRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        //GET api/topics
        [HttpGet]
        public ActionResult<IEnumerable<TopicReadDto>> GetAllTopics()
        {
            var topicItems = _repository.GetAllTopics();

            return Ok(_mapper.Map<IEnumerable<TopicReadDto>>(topicItems));
        }

        //GET api/topics/search={key}
        [HttpGet("search={key}")]
        public ActionResult<IEnumerable<TopicReadDto>> GetSearchTopics(string key)
        {
            var topicItems = _repository.GetSearchTopics(key);

            return Ok(_mapper.Map<IEnumerable<TopicReadDto>>(topicItems));
        }

        //GET api/topics/{id}
        [HttpGet("{id}", Name = "GetTopicById")]
        public ActionResult<CommandReadDto> GetTopicById(int id)
        {
            var topicItem = _repository.GetTopicById(id);
            if (topicItem != null)
            {
                return Ok(_mapper.Map<TopicReadDto>(topicItem));
            }
            return NotFound();
        }
        
        //POST api/topics
        [HttpPost]
        public ActionResult<TopicReadDto> CreateTopic(TopicCreateDto topicCreateDto)
        {
            var topicModel = _mapper.Map<Topic>(topicCreateDto);
            _repository.CreateTopic(topicModel);
            _repository.SaveChanges();

            var topicReadDto = _mapper.Map<TopicReadDto>(topicModel);

            // return Ok(commandReadDto);
            return CreatedAtRoute(nameof(GetTopicById), new {Id = topicReadDto.Id}, topicReadDto);
        }

        //PUT api/topics/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateTopic(int id, TopicUpdateDto topicUpdateDto) 
        {
            var topicModelFromRepo = _repository.GetTopicById(id);
            if(topicModelFromRepo == null) 
            {
                return NotFound();
            }

            _mapper.Map(topicUpdateDto, topicModelFromRepo);

            _repository.UpdateTopic(topicModelFromRepo);

            _repository.SaveChanges();

            return NoContent();
        }
        // PATCH api/topics/{id}
        [HttpPatch("{id}")]
        public ActionResult PartialTopicUpdate(int id, JsonPatchDocument<TopicUpdateDto> patchDoc)
        {
             var topicModelFromRepo = _repository.GetTopicById(id);
            if(topicModelFromRepo == null) 
            {
                return NotFound();
            }

            var commandToPatch = _mapper.Map<TopicUpdateDto>(topicModelFromRepo);
            patchDoc.ApplyTo(commandToPatch,ModelState);

            if(!TryValidateModel(commandToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(commandToPatch, topicModelFromRepo);

            _repository.UpdateTopic(topicModelFromRepo);

            _repository.SaveChanges();

            return NoContent();
        }

        //DELETE api/topics/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteTopic(int id)
        {
            var topicModelFromRepo = _repository.GetTopicById(id);
            if(topicModelFromRepo == null) 
            {
                return NotFound();
            }

            _repository.DeleteTopic(topicModelFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }
    }
}