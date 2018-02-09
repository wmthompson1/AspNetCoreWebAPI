using AspNetCoreWebAPI.Models;
using System.Collections.Generic;

namespace AspNetCoreWebAPI.Services
{
    public interface ISurveyQuestionDetailRepository
    {
        IEnumerable<SurveyQuestionDetailDTO> GetSurveyQuestionDetails();
        //SurveyDTO GetSurvey(int SurveyId);
        //void AddSurvey(SurveyDTO Survey);
        //void UpdateSurvey(int id, SurveyUpdateDTO Survey);
        //void DeleteSurvey(SurveyDTO Survey);
        //bool Save();
        //bool SurveyExists(int SurveyId);

    }
}