using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreWebAPI.Models
{
    public class SurveyQuestionDetailDTO
    {
        public Int64 Id { get; set; }
        public string Name { get; set; }

    }
}
