using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreWebAPI.Models
{
    public class SurveyQuestionDetailUpdateDTO
    {
        [Required(ErrorMessage = "You must enter an Id.")]
        //  [Key]
        //  [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //  This is a DTO for editing, so no id here.
        //  public int64 Id { get; set; }

        [StringLength(500)]
        public string Name { get; set; }

    }
}
