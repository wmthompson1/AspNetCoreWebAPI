using AspNetCoreWebAPI.Entities;
using System.Collections.Generic;
using System.Linq;
using AspNetCoreWebAPI.Models;
using AspNetCoreWebAPI.Data;
using System;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

//William Thompson 1/19/2018

namespace AspNetCoreWebAPI.Services
{
    public class SurveyQuestionDetailSqlRepository : ISurveyQuestionDetailRepository

    {

        private SqlDbContext _db;

        public SurveyQuestionDetailSqlRepository(SqlDbContext db)
        {
            _db = db;
        }



        public IEnumerable<SurveyQuestionDetailDTO> GetSurveyQuestionDetails()
        {
            var DTOs = Mapper.Map<IEnumerable<SurveyQuestionDetailDTO>>(_db.SurveyQuestionDetail);
            try
            {
                Console.WriteLine("test: {0}", "Test");
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                
            }
            return (DTOs);

        }


        public IEnumerable<SurveyQuestionDetailDTO> GetSurveyQuestionDetail(int SurveyId)
        {

            var surveyQuestionDetail = _db.SurveyQuestionDetail
                .FromSql("Select * from test.SurveyQuestionDetail")
                .Where(p => p.SurveyId.Equals(SurveyId));


            var DTOs = Mapper.Map<IEnumerable<SurveyQuestionDetailDTO>>(surveyQuestionDetail);
            try
            {
                Console.WriteLine("test: {0}", "Test");
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {

            }

            return DTOs;
        }

        public void AddSurveyQuestionDetail(SurveyQuestionDetailCreateDTO surveyQuestionDetail)
        {

            // wnt
            var proc = "[test].[usp_SurveyDetail_Add] @p0;";
            //var results = _db.SurveyQuestionDetail.FromSql(proc, surveyQuestionDetail.SurveyId);
            _db.Database
           .ExecuteSqlCommand(proc, surveyQuestionDetail.SurveyId);


            return ;

        }

        //public bool Save()
        //{
        //    return _db.SaveChanges() >= 0;
        //}

        //public void UpdateSurveyQuestionDetail(int id, SurveyQuestionDetailUpdateDTO surveyQuestionDetail)
        //{
        //    var stub = GetSurveyQuestionDetail(id);

        //    var surveyQuestionDetailToUpdateItem = _db.SurveyQuestionDetail.FirstOrDefault(p => p.Id.Equals(id));

        //    if (surveyQuestionDetailToUpdateItem == null) return;

        //    // map dto to entity

        //    var surveyQuestionDetailToUpdate = Mapper.Map<SurveyQuestionDetailDTO>(surveyQuestionDetailToUpdateItem);

        //    //surveyQuestionDetailToUpdate.Name = surveyQuestionDetail.Name;
        //    //surveyQuestionDetailToUpdate.Description = surveyQuestionDetail.Description;
        //    //surveyQuestionDetailToUpdate.SurveyQuestionDetailTypeCode = surveyQuestionDetail.SurveyQuestionDetailTypeCode;
        //    //surveyQuestionDetailToUpdate.Instructions = surveyQuestionDetail.Instructions;
        //    //surveyQuestionDetailToUpdate.IsLocked = surveyQuestionDetail.IsLocked;

        //    //surveyQuestionDetailToUpdate.CloseDate = surveyQuestionDetail.CloseDate;
        //    //surveyQuestionDetailToUpdate.CreateDate = surveyQuestionDetail.CreateDate;
        //    //surveyQuestionDetailToUpdate.CreatedBy = surveyQuestionDetail.CreatedBy;
        //    //surveyQuestionDetailToUpdate.UpdateDate = surveyQuestionDetail.UpdateDate;
        //    //surveyQuestionDetailToUpdate.UpdatedBy = surveyQuestionDetail.UpdatedBy;

        //    //surveyQuestionDetailToUpdate.SchoolYear = surveyQuestionDetail.SchoolYear;
        //    //surveyQuestionDetailToUpdate.LeaverYear = surveyQuestionDetail.LeaverYear;
        //    //surveyQuestionDetailToUpdate.IsReported = surveyQuestionDetail.IsReported;
        //    //surveyQuestionDetailToUpdate.OpenDate = surveyQuestionDetail.OpenDate;

        //}

        //public bool SurveyQuestionDetailExists(int surveyQuestionDetailId)
        //{
        //    return _db.SurveyQuestionDetail.Count(p => p.Id.Equals(surveyQuestionDetailId)).Equals(1);
        //}


        //public void DeleteSurveyQuestionDetail(SurveyQuestionDetailDTO surveyQuestionDetail)
        //{

        //    var surveyQuestionDetailToDelete = _db.SurveyQuestionDetail.FirstOrDefault(p =>
        //    p.Id.Equals(surveyQuestionDetail.Id));

        //    if (surveyQuestionDetailToDelete != null)
        //        _db.SurveyQuestionDetail.Remove(surveyQuestionDetailToDelete);

        //}

    }
}

