using DiabetesAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DiabetesAPI.View_Model;

namespace DiabetesAPI.Repo
{
    public interface IDiabetes
    {

        List<Posts> GetPosts(int CategoryId);
        Posts AddPost(int Userid, int CategoryId, string postcontent, int reactid, string image);
        List<Category> GetAllCategories();
        List<Reactions> GetAllReacts();

        List<Test> GetAllTests(int patientid, int type);
        List<Notification> GetPatientNotifications(int patientid);
        List<Notification> GetDoctorNOtifications(int doctorid);

        List<ChecksUps> GetPatientCheckups(int patientid);

        List<Drugs> GetAllDrugs();
        void AddDrug(int drugid, int patientid, string note, int dose);

        List<GetMyDoctors> GetMyDoctors(int? patientid);

        void AddCheckup(int patientid, int checkuptype, string notes, DateTime date);

        ChecksUps UpdateCheckup(ChecksUps checkup);

        List<SavedPosts> GetSavedPosts(int userId);
        List<Questions> GetSavedQuestions(int userId);

        List<Questions> GetMyQuestions(int userId);

        void FollowDoctor(int patientid, int doctorid);

        bool UnfollowDoctor(int patientid, int doctorid);

        Questions AddQuestion(int doctorid, int patientid, string question);

        //doctor
        List<FollowingPatients> GetMyPatients(int doctorid);

        void AddCertificate(int doctorid, string certificate, string university);
        Answers AddAnswer(int userid, int questionid, string answer);
        //Mine
        void AddTest(DateTime date, int result, string type, int patientid, bool medication);//change result in db to int **DONE**

        PatientDoctorsFollow request_access_medicalInfo(int id, short status);
        List<Questions> getAnsweredQuestions(int drid);
        List<Questions> getMentionedInQuestions(int drid);
        Doctor GetDoctor(int drid);
        Doctor UpdateDoctor(Doctor doctor);
    }
}
