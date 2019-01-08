using EMS.Domain;
using System;
using System.ComponentModel.DataAnnotations;

namespace EMS.Business
{
    public class StudentDetailsModel
    {
        public Guid Id { get; set; }

        public Guid UserId { get; set; }

        public string FatherInitial { get; set; }
    }
}
