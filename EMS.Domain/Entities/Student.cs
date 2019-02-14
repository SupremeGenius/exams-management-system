﻿using System;
using System.Collections.Generic;
using System.Text;

namespace EMS.Domain.Entities
{
    public class Student : Entity, IUpdatable<Student>
    {
        public Guid UserId { get; private set; }

        public string Name { get; private set; }

        public string RegistrationNumber { get; private set; }

        public string FatherInitial { get; private set; }

        public string Group { get; private set; }

        public int Year { get; set; }

        public List<StudentCourse> StudentCourses { get; private set; }

        public List<StudentExam> StudentExams { get; private set; }

        public static Student Create (Guid userId, string fInitial, string group, int year, string rnumber) => new Student
        {
            UserId = userId,
            RegistrationNumber = rnumber,
            FatherInitial = fInitial,
            Group = group,
            Year = year
        };

        public void Update(Student updatedEntity)
        {
            FatherInitial = updatedEntity.FatherInitial == null ? FatherInitial : updatedEntity.FatherInitial;
            Name = updatedEntity.Name == null ? Name : updatedEntity.Name;
            Group = updatedEntity.Group == null ? Group : updatedEntity.Group;
            RegistrationNumber = updatedEntity.RegistrationNumber == null ? RegistrationNumber : updatedEntity.RegistrationNumber;
        }
    }
}
