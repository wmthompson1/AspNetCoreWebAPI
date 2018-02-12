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

        //[HttpGet("{id}", Name = "GetSurveyQuestionDetail")]
        //public IActionResult Get(int id)
        //{
        //    var surveyQuestionDetail = _rep.GetSurveyQuestionDetail(id);

        //    if (surveyQuestionDetail == null) return NotFound();

        //    return Ok(surveyQuestionDetail);
        //}

        //// TODO: William Thompson

        //[HttpPost]
        //public IActionResult Post([FromBody] SurveyQuestionDetailDTO surveyQuestionDetail)

        //{

        //    if (surveyQuestionDetail == null) return BadRequest();
        //    if (!ModelState.IsValid) return BadRequest(ModelState);

        //    _rep.AddSurveyQuestionDetail(surveyQuestionDetail);

        //    return NoContent();

        //}



    }
}
