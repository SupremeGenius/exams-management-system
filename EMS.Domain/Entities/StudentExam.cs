using System;
using System.Collections.Generic;
using System.Text;

namespace EMS.Domain.Entities
{
    public class StudentExam 
    {
        public Guid StudentId { get; private set; }

        public Student Student { get; private set; }

        public string Checked{ get; private set; }

        public Guid ExamId { get; private set; }

        public Exam Exam { get; private set; }


        public StudentExam()
        {

        }

        public StudentExam(Student student, Exam exam)
        {
            StudentId = student.Id;
            Student = student;
            ExamId = exam.Id;
            Exam  = exam;
            Checked = "yes";
        }

    }


}
