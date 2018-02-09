using System;
using System.ComponentModel.DataAnnotations;

namespace AspNetCoreWebAPI.Models
{
    public class SurveyQuestionDetailCreateDTO
    {

        //  This is a DTO for editing, so no id here.
        //public int64 Id { get; set; }

        [Required(ErrorMessage = "You must enter a name.")]
        //[StringLength(500)]
        [MaxLength(500)]
        public string Name { get; set; }
  
    }
}