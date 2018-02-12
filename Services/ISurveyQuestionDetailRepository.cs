using AspNetCoreWebAPI.Models;
using System.Collections.Generic;

namespace AspNetCoreWebAPI.Services
{
    public interface ISurveyQuestionDetailRepository
    {
        IEnumerable<SurveyQuestionDetailDTO> GetSurveyQuestionDetails();
        SurveyQuestionDetailDTO GetSurveyQuestionDetail(int SurveyId);
        void AddSurveyQuestionDetail(SurveyQuestionDetailDTO SurveyQuestionDetail);
        //void UpdateSurveyQuestionDetail(int id, SurveyQuestionUpdateDTO SurveyQuestionDetail);
        //void DeleteSurveyQuestionDetail(SurveyQuestionDetailDTO SurveyQuestionDetail);
        //bool Save();
        //bool SurveyQuestionDetailExists(int SurveyId);

    }
}