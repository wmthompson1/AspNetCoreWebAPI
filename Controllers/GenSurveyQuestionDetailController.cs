using AspNetCoreWebAPI.Entities;
using AspNetCoreWebAPI.Models;
using AspNetCoreWebAPI.Services;
using AutoMapper;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace AspNetCoreWebAPI.Controllers
{
    [EnableCors("CorsPolicy")]
    [Route("api/admin/gensurveyQuestionDetails")]
    public class GenSurveyQuestionDetailController : Controller
    {
        IGenericEFRepository _rep;

        public GenSurveyQuestionDetailController(IGenericEFRepository rep)
        {
            _rep = rep;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var item = _rep.Get<SurveyQuestionDetail>();
            var DTOs = Mapper.Map<IEnumerable<SurveyQuestionDetailDTO>>(item);
            return Ok(DTOs);
        }

        [HttpGet("{id}", Name = "GetGenericSurveyQuestionDetail")]
        public IActionResult Get(int id, bool includeRelatedEntities = false)
        {
            var item = _rep.Get<SurveyQuestionDetail>(id, includeRelatedEntities);

            if (item == null) return NotFound();

            var DTO = Mapper.Map<SurveyQuestionDetailDTO>(item);
            return Ok(DTO);
        }

        [HttpPost]
        public IActionResult Post([FromBody]SurveyQuestionDetailDTO DTO)
        {
            if (DTO == null) return BadRequest();
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var itemToCreate = Mapper.Map<SurveyQuestionDetail>(DTO);

            _rep.Add(itemToCreate);

            if (!_rep.Save()) return StatusCode(500,
                "A problem occurred while handling your request.");

            var createdDTO = Mapper.Map<SurveyQuestionDetailDTO>(itemToCreate);

            return CreatedAtRoute("GetGenericSurveyQuestionDetail",
                new { id = createdDTO.Id }, createdDTO);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]SurveyQuestionDetailUpdateDTO DTO)
        {
            if (DTO == null) return BadRequest();
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var entity = _rep.Get<SurveyQuestionDetail>(id);
            if (entity == null) return NotFound();

            Mapper.Map(DTO, entity);

            if (!_rep.Save()) return StatusCode(500,
                "A problem happened while handling your request.");

            return NoContent();
        }

        [HttpPatch("{id}")]
        public IActionResult Patch(int id, [FromBody]JsonPatchDocument<SurveyQuestionDetailUpdateDTO> DTO)
        {
            if (DTO == null) return BadRequest();
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var entity = _rep.Get<SurveyQuestionDetail>(id);
            if (entity == null) return NotFound();

            var entityToPatch = Mapper.Map<SurveyQuestionDetailUpdateDTO>(entity);
            DTO.ApplyTo(entityToPatch, ModelState);
            TryValidateModel(entityToPatch);
            if (!ModelState.IsValid) return BadRequest(ModelState);

            Mapper.Map(entityToPatch, entity);

            if (!_rep.Save()) return StatusCode(500,
                "A problem happened while handling your request.");

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (!_rep.Exists<SurveyQuestionDetail>(id)) return NotFound();

            var entityToDelete = _rep.Get<SurveyQuestionDetail>(id);

            _rep.Delete(entityToDelete);

            if (!_rep.Save()) return StatusCode(500,
                "A problem occurred while handling your request.");

            return NoContent();
        }

    }
}
