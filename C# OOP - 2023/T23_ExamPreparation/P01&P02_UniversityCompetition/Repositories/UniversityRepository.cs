using System;
using System.Collections.Generic;
using System.Linq;
using UniversityCompetition.Models;
using UniversityCompetition.Models.Contracts;
using UniversityCompetition.Repositories.Contracts;

namespace UniversityCompetition.Repositories
{
    public class UniversityRepository : IRepository<IUniversity>
    {
        public UniversityRepository()
        {
            models = new List<IUniversity>();
        }

        private List<IUniversity> models;

        public IReadOnlyCollection<IUniversity> Models
        {
            get { return models; }
        }


        public void AddModel(IUniversity model)
        {
            IUniversity university = new University(models.Count + 1, model.Name, model.Category, model.Capacity, model.RequiredSubjects.ToList());

            models.Add(university);
        }

        public IUniversity FindById(int id)
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

        public IUniversity FindByName(string name)
        {
            foreach (var model in models)
            {
                if (model.Name == name)
                {
                    return model;
                }
            }

            return null;
        }
    }
}

