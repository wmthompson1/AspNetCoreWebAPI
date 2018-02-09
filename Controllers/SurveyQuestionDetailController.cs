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
    [Route("api/admin/surveyQuestionDetails")]
    public class SurveyQuestionDetailController : Controller
    {


        ISurveyQuestionDetailRepository _rep;
        public SurveyQuestionDetailController(ISurveyQuestionDetailRepository rep, IMapper mapper) // 
        {
            _rep = rep;

        }

        [HttpGet]
        public IActionResult Get()
        {
 
            return Ok(_rep.GetSurveyQuestionDetails());
        }

    }
}
