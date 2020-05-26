using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DiabetesAPI.Models;
using DiabetesAPI.Repo;

namespace DiabetesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiabetesController : ControllerBase
    {
        IDiabetes d;

        public DiabetesController(IDiabetes _d)
        {
            this.d = _d;
        }
        //1 get dr info
        [HttpGet("{drid}")]
        [Route("doctor/{drid}")]
        public IActionResult getDrInfo(int drid)
        {
            var n = d.GetDoctor(drid);
            return Ok(n);
            
        }
        //2 update dr info
        [HttpPut("{drid}")]
        [Route("drupdate/{drid}")]
        public IActionResult updateDrInfo(Doctor doctor)
        {
            var n = d.UpdateDoctor(doctor);
            return Ok(n);
        }
        //3 get all following patients
        [HttpGet("{drid}")]
        [Route("getpatients/{drid}")]
        public IActionResult getAllFollowingPatients(int drid)
        {
            var n = d.GetMyPatients(drid);
            return Ok(n);
        }
        //4 request access for medical info
        [HttpPost("{drid}")]
        [Route("request/")]
        public IActionResult request_access_medicalinfo(int id, short status)
        {
            var n = d.request_access_medicalInfo(id, status);
            return Ok(n);
        }
        //5 get dr posts

        [HttpGet]
        [Route("posts/{drid}")]
        public ActionResult drPosts(int drid)
        {
            var n = d.GetPosts(drid);
            return Ok();
        }
        //6 get dr questions

        [HttpGet]
        [Route("doctor/quest/{drid}")]
        public ActionResult getDrQuestions(int drid)
        {
            var n = d.GetMyQuestions(drid);
            return Ok(n);

        }

        //7 get dr questions he was mentioned in
        [HttpGet]
        [Route("dr/mquest/{id}")]
        public ActionResult getMentionedQues(int id)
        {
            var n = d.getMentionedInQuestions(id);
            return Ok(n);
        }
        //8 add answer
        [HttpPost]
        public ActionResult addAnswer(int userid, int questionid, string answer)
        {
            var n = d.AddAnswer(userid, questionid, answer);
            return Ok(n);
        }

        //9 get answered questions
        [HttpGet("{drid}")]
        [Route("ansques/{drid}")]
        public ActionResult getAnsweredQues(int drid)
        {
            var n = d.getAnsweredQuestions(drid);
            return Ok(n);
        }
    }
}