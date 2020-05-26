using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DiabetesAPI.Models;
using DiabetesAPI.View_Model;
using Microsoft.EntityFrameworkCore;

namespace DiabetesAPI.Repo
{
    public class DiabetesRepo : IDiabetes
    {
        DiabetesSysContext db;

        public DiabetesRepo(DiabetesSysContext _db)
        {
            db = _db;
        }
        
        //ahmed

        public void AddCertificate(int doctorid, string certificate, string university)
        {
            db.Certificates.FromSqlRaw("AddCertificate  {0}, {1} ,{2}  ", certificate, university, doctorid).ToList();
        }

        public void AddCheckup(int patientid, int checkuptype, string notes, DateTime date)
        {
            db.ChecksUps.FromSqlRaw("addcheckup  {0}, {1} ,{2}", patientid, checkuptype, notes).ToList();
        }


        public void AddTest(DateTime date, int result, string type, int patientid, bool medication) //edited to void, may return testID
        {
            db.Database.ExecuteSqlRawAsync("EXEC dbo.AddTest {0},{1},{2},{3},{4}", date, result, type, patientid, medication);
            //int test_id = db.Test.OrderByDescending(p => p.Id).FirstOrDefault().Id;                                             
        }

        public void FollowDoctor(int patientid, int doctorid)
        {
            db.Database.ExecuteSqlRawAsync("EXEC dbo.FollowDoctor {0},{1},{2},{3},{4}", patientid, doctorid, 0, DateTime.Now, 2);

        }


        //dina
        public List<Category> GetAllCategories()
        {
            return db.Category.ToList<Category>();
        }

        public List<Reactions> GetAllReacts()
        {
            return db.Reactions.ToList();
        }


        public List<Notification> GetDoctorNOtifications(int doctorid)
        {
            return db.Notification.FromSqlRaw("Notification_Doctor_Select  {0}", doctorid).ToList();
        }

        public List<GetMyDoctors> GetMyDoctors(int? patient_id)
        {
            var sp = from f in db.PatientDoctorsFollow
                     join u in db.Users
                     on f.DoctorId equals u.UserId
                     where f.PatienId == patient_id
                     select new GetMyDoctors
                     {
                         id = f.Id,
                         doctor_id = f.DoctorId,
                         access_med_info = f.AccessMedicalInfo,
                         user_id = u.UserId,
                         user_name = u.UserName,
                         img = u.ImageSource,
                         type = u.Type,
                         identity_id = u.Id
                     };
            return sp.ToList();
        }

        public List<FollowingPatients> GetMyPatients(int doctorid)
        {
            var sp = from u in db.Users
                     join p in db.Patient
                     on u.UserId equals p.PatientId
                     join f in db.PatientDoctorsFollow
                     on p.PatientId equals f.PatienId
                     where f.DoctorId == doctorid
                     select new FollowingPatients
                     {
                         userID = u.UserId,
                         user_name = u.UserName,
                         img = u.ImageSource,
                         medical_cond = p.MedicalCondetion,
                         birth_date = p.BirthDate,
                         gender = p.Gender,
                         weight = p.Weight,
                         height = p.Height,
                         life_style = p.LifeStyle,
                         access_med_info = f.AccessMedicalInfo
                     };
            return sp.ToList();
        }


        public List<Notification> GetPatientNotifications(int patientid)
        {
            return db.Notification.FromSqlRaw("EXECUTE dbo.Notification_Patient {0}", patientid).ToList();
        }

        public List<Posts> GetPosts(int CategoryId)
        {
            return db.Posts.FromSqlRaw("Posts_Select  {0}", CategoryId).ToList();
        }

        public List<SavedPosts> GetSavedPosts(int userID)
        {
            // return db.savedposts.FromSqlRaw($"SavedPosts {userID}").ToList();
            var sp = from p in db.Posts
                     join u in db.UserSavedPosts
                     on p.PostId equals u.PostId
                     where p.UserId == userID
                     select new SavedPosts
                     {
                         post_id = p.PostId,
                         user_id = p.UserId,
                         category_id = p.CategoryId,
                         img = p.ImageSource,
                         content = p.PostContent,
                         react_id = p.ReactionId,
                         date = p.PostDate
                     };
            return sp.ToList();
        }

        public List<Questions> GetSavedQuestions(int userId)
        {
            return db.Questions.FromSqlRaw("SavedQuestions_Select  {0}", userId).ToList();
        }

        public bool UnfollowDoctor(int patientid, int doctorid)
        {
            bool flag = false;
            int x = db.Database.ExecuteSqlRaw("unfollowdoctor {0}, {1}", doctorid, patientid);
            if (x != 0) flag = true;
            return flag;
        }


        // ANDALEEB //
        Posts IDiabetes.AddPost(int Userid, int CategoryId, string postcontent, int reactid, string image)
        {
            return db.Posts.FromSqlRaw("AddPost {0}, {1},{2},{3},{4}", Userid, CategoryId, postcontent, image, reactid).AsEnumerable().FirstOrDefault();
        }

        List<Test> IDiabetes.GetAllTests(int patientid, int type)
        {
            return db.Test.ToList();

        }

        void IDiabetes.AddDrug(int drugid, int patientid, string note, int dose)
        {
            db.Drugs.FromSqlRaw("AddDrugForPatient {0},{1},{2},{3}", drugid, patientid, note, dose);
        }

        ChecksUps IDiabetes.UpdateCheckup(ChecksUps checkup)
        {
            db.ChecksUps.Update(checkup);
            return checkup;
        }

        List<Questions> IDiabetes.GetMyQuestions(int userId)
        {
            return db.Questions.FromSqlRaw("Questions_Select {0}", userId).ToList();
        }

        Questions IDiabetes.AddQuestion(int doctorid, int patientid, string question)
        {
            return db.Questions.FromSqlRaw("addquestion {0},{1},{2}", doctorid, question, patientid).AsEnumerable().FirstOrDefault();
        }

        Answers IDiabetes.AddAnswer(int userid, int questionid, string answer)
        {
            return db.Answers.FromSqlRaw("AddAnswer {0},{1},{2}", questionid, answer, userid).AsEnumerable().FirstOrDefault();
        }

        List<ChecksUps> IDiabetes.GetPatientCheckups(int patientid)
        {
            return db.ChecksUps.FromSqlRaw("ChecksUps_Select {0}", patientid).ToList();
        }

        List<Drugs> IDiabetes.GetAllDrugs()
        {
            return db.Drugs.ToList();
        }

        //Andaleeb
        
        List<Questions> IDiabetes.getAnsweredQuestions(int drid)
        {
            var query = from q in db.Questions
                        join a in db.Answers
                        on q.QuestionId equals a.QuestionId
                        where a.UserId == drid
                        select new Questions
                        {
                            QuestionId = q.QuestionId
                        };
            return query.ToList();
        }

        List<Questions> IDiabetes.getMentionedInQuestions(int drid)
        {
            var query = from q in db.QuestionDoctorsMention
                        where q.DoctorId == drid
                        select new Questions
                        {
                            QuestionId = q.QuestionId
                        };
            return query.ToList();
        }

        Doctor IDiabetes.GetDoctor (int drid)
        {
            Doctor dr = db.Doctor.Find(drid);
          
                return dr;
        }

        Doctor IDiabetes.UpdateDoctor(Doctor doctor)
        {
            db.Doctor.Update(doctor);
            db.SaveChanges();
            return doctor;
        }
        public PatientDoctorsFollow request_access_medicalInfo(int id, short status)
        {
            var x = db.PatientDoctorsFollow.First(a => a.Id == id);
            x.AccessMedicalInfo = status;
            return x;
        }
    }
}
