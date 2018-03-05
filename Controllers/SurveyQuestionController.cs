using AspNetCoreWebAPI.Models;
using AspNetCoreWebAPI.Services;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System;
using AutoMapper;
using System.Collections.Generic;
using Microsoft.Extensions.Options;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using AspNetCoreWebAPI.Entities;
using Microsoft.AspNetCore.Cors;
using Microsoft.Extensions.Logging;

namespace AspNetCoreWebAPI.Controllers
{
    [EnableCors("CorsPolicy")]
    [Route("api/admin/surveyQuestion")]
    public class SurveyQuestionController : Controller
    {


        ISurveyQuestionRepository _rep;
        public SurveyQuestionController(ISurveyQuestionRepository rep, IMapper mapper) // 
        {
            _rep = rep;

        }

        //[HttpGet]
        //public IActionResult Get()
        //{

        //    return Ok(_rep.GetSurveyQuestion());
        //}

        [HttpGet("{id}", Name = "GetSurveyQuestion")]
        public IActionResult Get(int id)
        {
            var surveyQuestion = _rep.GetSurveyQuestion(id);

            if (surveyQuestion == null) return NotFound();

            return Ok(surveyQuestion);
        }

        // TODO: William Thompson


        //[HttpPost("{id}", Name = "PostSurveyQuestion")]
        //public IActionResult Post([FromBody] SurveyQuestionCreateDTO surveyQuestion)

        //{

        //    if (surveyQuestion == null) return BadRequest();
        //    if (!ModelState.IsValid) return BadRequest(ModelState);

        //    _rep.AddSurveyQuestion(surveyQuestion);

        //    return NoContent();

        //}
    }
}
