using System.Collections.Generic;
using System.Linq;
using AspNetCoreWebAPI.Models;
using AspNetCoreWebAPI.Data;
using System;

namespace AspNetCoreWebAPI.Services
{
    public class SurveyMockRepository : ISurveyRepository
    {
        public IEnumerable<SurveyDTO> GetSurveys()
        {
            return MocksurveyData.Current.Surveys;
        }

        public SurveyDTO GetSurvey(int Id)
        {
            var Survey = MocksurveyData.Current.Surveys.FirstOrDefault(p =>
                p.Id.Equals(Id));


            return Survey;
        }

        public void AddSurvey(SurveyDTO survey)
        {
            // For Demo purposes only: Get next id
            var id = GetSurveys().Max(m => m.Id) + 1;
            survey.Id = id;
            MocksurveyData.Current.Surveys.Add(survey);
        }

        public bool Save()
        {
            return true;
        }

        //TODO: Add remaining fields from table
        public void UpdateSurvey(int id, SurveyUpdateDTO survey)
        {
            var surveyToUpdate = GetSurvey(id);
 
            surveyToUpdate.Name = survey.Name;
            surveyToUpdate.Description = survey.Description;
            surveyToUpdate.SurveyTypeCode = survey.SurveyTypeCode;
            surveyToUpdate.Instructions = survey.Instructions;
            surveyToUpdate.IsLocked = survey.IsLocked;
            
            surveyToUpdate.CloseDate = survey.CloseDate;
            surveyToUpdate.CreateDate = survey.CreateDate;
            surveyToUpdate.CreatedBy = survey.CreatedBy;
            surveyToUpdate.UpdateDate = survey.UpdateDate;
            surveyToUpdate.UpdatedBy = survey.UpdatedBy;

            surveyToUpdate.SchoolYear = survey.SchoolYear;
            surveyToUpdate.LeaverYear = survey.LeaverYear;
            surveyToUpdate.IsReported = survey.IsReported;
            surveyToUpdate.OpenDate = survey.OpenDate;

        }

        public bool SurveyExists(int surveyId)
        {
            return MocksurveyData.Current.Surveys.Count(p => p.Id.Equals(surveyId)).Equals(1);
        }


        public void DeleteSurvey(SurveyDTO survey)
        {

            // Alternative implementation to remove the books from a survey
            // MockData.Current.Books.RemoveAll(b => b.SurveyId.Equals(survey.Id));

            MocksurveyData.Current.Surveys.Remove(survey);
        }





    }
}

