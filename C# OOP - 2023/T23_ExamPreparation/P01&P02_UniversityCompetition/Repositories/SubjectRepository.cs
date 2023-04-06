﻿using System;
using System.Collections.Generic;
using UniversityCompetition.Models;
using UniversityCompetition.Models.Contracts;
using UniversityCompetition.Repositories.Contracts;

namespace UniversityCompetition.Repositories
{
    public class SubjectRepository : IRepository<ISubject>
    {
        public SubjectRepository()
        {
            models = new List<ISubject>();
        }

        private List<ISubject> models;

        public IReadOnlyCollection<ISubject> Models
        {
            get { return models; }
        }


        public void AddModel(ISubject model)
        {
            ISubject subject = null;

            if (model is TechnicalSubject)
            {
                subject = new TechnicalSubject(models.Count + 1, model.Name);
            }
            if (model is EconomicalSubject)
            {
                subject = new EconomicalSubject(models.Count + 1, model.Name);
            }
            if (model is HumanitySubject)
            {
                subject = new HumanitySubject(models.Count + 1, model.Name);
            }


            models.Add(subject);
        }

        public ISubject FindById(int id)
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

        public ISubject FindByName(string name)
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