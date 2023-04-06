using System;
using System.Collections.Generic;
using UniversityCompetition.Models;
using UniversityCompetition.Models.Contracts;
using UniversityCompetition.Repositories.Contracts;

namespace UniversityCompetition.Repositories
{
    public class StudentRepository : IRepository<IStudent>
    {
        public StudentRepository()
        {
            models = new List<IStudent>();
        }

        private List<IStudent> models;

        public IReadOnlyCollection<IStudent> Models
        {
            get { return models; }
        }


        public void AddModel(IStudent model)
        {
            IStudent student = new Student(models.Count + 1, model.FirstName, model.LastName);
            models.Add(student);
        }

        public IStudent FindById(int id)
        {
            foreach (var model in models)
            {
                if (model.Id == id)
                {
                    return model;
                }
            }

            return null;
        }

        public IStudent FindByName(string name)
        {
            string[] names = name.Split();

            foreach (var model in models)
            {
                if (model.FirstName == names[0] && model.LastName == names[1])
                {
                    return model;
                }
            }

            return null;
        }
    }
}

