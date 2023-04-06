using System;
using System.Collections.Generic;
using System.Linq;
using UniversityCompetition.Core.Contracts;
using UniversityCompetition.Models;
using UniversityCompetition.Models.Contracts;
using UniversityCompetition.Repositories;
using UniversityCompetition.Repositories.Contracts;
using UniversityCompetition.Utilities.Messages;

namespace UniversityCompetition.Core
{
    public class Controller : IController
    {
        //FIXME
        private IRepository<ISubject> subjects = new SubjectRepository();
        private IRepository<IStudent> students = new StudentRepository();
        private IRepository<IUniversity> universities = new UniversityRepository();

        public Controller()
        {
        }

        public string AddStudent(string firstName, string lastName)
        {
            throw new NotImplementedException();
        }

        public string AddSubject(string subjectName, string subjectType)
        {

            if (subjects.FindByName(subjectName) != null)
            {
                return string.Format(OutputMessages.AlreadyAddedSubject, subjectName);
            }

            if (subjectType == "TechnicalSubject")
            {
                TechnicalSubject technicalSubject = new(1, subjectName);
                subjects.AddModel(technicalSubject);

                return string.Format(OutputMessages.SubjectAddedSuccessfully, subjectType, subjectName, subjects);
            }
            else if (subjectType == "EconomicalSubject")
            {
                EconomicalSubject economicalSubject = new(1, subjectName);
                subjects.AddModel(economicalSubject);

                return string.Format(OutputMessages.SubjectAddedSuccessfully, subjectType, subjectName, subjects);
            }
            else if (subjectType == "HumanitySubject")
            {
                HumanitySubject humanitySubject = new(1, subjectName);
                subjects.AddModel(humanitySubject);

                return string.Format(OutputMessages.SubjectAddedSuccessfully, subjectType, subjectName, subjects);
            }
            else
            {
                return string.Format(OutputMessages.SubjectTypeNotSupported, subjectType);
            }
        }

        public string AddUniversity(string universityName, string category, int capacity, List<string> requiredSubjects)
        {
            throw new NotImplementedException();
        }

        public string ApplyToUniversity(string studentName, string universityName)
        {
            throw new NotImplementedException();
        }

        public string TakeExam(int studentId, int subjectId)
        {
            throw new NotImplementedException();
        }

        public string UniversityReport(int universityId)
        {
            throw new NotImplementedException();
        }
    }
}

