using System;
using System.Collections.Generic;

namespace DiabetesAPI.Models
{
    public partial class NotificationMedicalInfo
    {
        public int NotificationId { get; set; }
        public int MedicalInfoId { get; set; }

        public virtual PatientDoctorsFollow MedicalInfo { get; set; }
        public virtual Notification Notification { get; set; }
    }
}
