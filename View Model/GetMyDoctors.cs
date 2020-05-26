using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiabetesAPI.View_Model
{
    public class GetMyDoctors
    {
        public int id { get; set; }
        public int? patient_id { get; set; }
        public int? doctor_id { get; set; }
        public int access_med_info { get; set; }
        public int user_id { get; set; }
        public string user_name { get; set; }
        public string img { get; set; }
        public bool? type { get; set; }
        public string identity_id { get; set; }
    }
}
