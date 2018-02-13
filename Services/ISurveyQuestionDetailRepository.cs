using AspNetCoreWebAPI.Models;
using System.Collections.Generic;

namespace AspNetCoreWebAPI.Services
{
    public interface ISurveyQuestionDetailRepository
    {
        IEnumerable<SurveyQuestionDetailDTO> GetSurveyQuestionDetails();
        IEnumerable<SurveyQuestionDetailDTO> GetSurveyQuestionDetail(int SurveyId);
        //SurveyQuestionDetailDTO GetSurveyQuestionDetail(int SurveyId);
        void AddSurveyQuestionDetail(SurveyQuestionDetailCreateDTO SurveyQuestionDetail);
        //void UpdateSurveyQuestionDetail(int id, SurveyQuestionUpdateDTO SurveyQuestionDetail);
        //void DeleteSurveyQuestionDetail(SurveyQuestionDetailDTO SurveyQuestionDetail);
        //bool Save();
        //bool SurveyQuestionDetailExists(int SurveyId);

    }
}