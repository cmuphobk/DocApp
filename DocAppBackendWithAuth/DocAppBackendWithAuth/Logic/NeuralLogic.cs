using DocAppBackendWithAuth.Common.IoCContainer;
using DocAppBackendWithAuth.Entity.POCO;
using DocAppBackendWithAuth.Entity.Repository;
using DocAppBackendWithAuth.Entity.Specifications.POCO.Diagnos;
using DocAppBackendWithAuth.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace DocAppBackendWithAuth.Logic
{
    public class NeuralLogic
    {


        public List<Departament> getDepartaments(int? id)
        {
            var departaments = new List<Departament>();
            using (var context = IoCContainer.Get<IEntity>())
            {
                var repository = context.GetRepository<IRepository<Departament>>();

                if (id.HasValue)
                {
                    departaments.Add(repository.Find(new Entity.Specifications.POCO.Departament.ById((int)id), new List<Expression<Func<Departament, object>>>
                    {
                        t => t.groups,
                        t => t.groups.Select(q=>q.symptoms)
                    }).First());
                }
                else
                {
                    departaments = repository.GetAll(new List<Expression<Func<Departament, object>>>
                    {
                        t => t.groups,
                        t => t.groups.Select(q=>q.symptoms)
                    }).ToList();
                }

                return departaments;
            }
        }

        public List<Group> getGroups(int? id)
        {
            var groups = new List<Group>();
            using (var context = IoCContainer.Get<IEntity>())
            {
                var repository = context.GetRepository<IRepository<Group>>();

                if (id.HasValue)
                {
                    groups.Add(repository.Find(new Entity.Specifications.POCO.Group.ById((int)id), new List<Expression<Func<Group, object>>>
                    {
                        t => t.symptoms
                    }).First());
                }
                else
                {
                    groups = repository.GetAll(new List<Expression<Func<Group, object>>>
                    {
                        t => t.symptoms
                    }).ToList();
                }

                return groups;
            }
        }

        public List<Group> getGroupsByDepartament(int idDepartament)
        {
            var groups = new List<Group>();
            using (var context = IoCContainer.Get<IEntity>())
            {
                var repository = context.GetRepository<IRepository<Departament>>();

                var departament = repository.Find(new Entity.Specifications.POCO.Departament.ById(idDepartament), new List<Expression<Func<Departament, object>>>
                {
                    t => t.groups,
                    t => t.groups.Select(q=>q.symptoms)
                }).First();

                departament.groups.ForEach(t =>
                {
                    groups.Add(t);
                });          

                return groups;
            }
        }

        public List<Symptom> getSymptomsByGroup(int idGroup)
        {
            var symptoms = new List<Symptom>();
            using (var context = IoCContainer.Get<IEntity>())
            {
                var repository = context.GetRepository<IRepository<Group>>();

                var group = repository.Find(new Entity.Specifications.POCO.Group.ById(idGroup), new List<Expression<Func<Group, object>>>
                {
                    t => t.symptoms
                }).First();

                group.symptoms.ForEach(t =>
                {
                    symptoms.Add(t);
                });

                return symptoms;
            }
        }

        public List<Diagnos> getDiagnoses(int? id)
        {
            var diagnoses = new List<Diagnos>();
            using (var context = IoCContainer.Get<IEntity>())
            {
                var repository = context.GetRepository<IRepository<Diagnos>>();

                if (id.HasValue)
                {
                    diagnoses.Add(repository.Find(new Entity.Specifications.POCO.Diagnos.ById((int)id)).First());
                }
                else
                {
                    diagnoses = repository.GetAll().ToList();
                }

                return diagnoses;
            }
        }

        public List<Symptom> getSymptoms(int? id)
        {
            var symptoms = new List<Symptom>();
            using (var context = IoCContainer.Get<IEntity>())
            {
                var repository = context.GetRepository<IRepository<Symptom>>();

                if (id.HasValue)
                {
                    symptoms.Add(repository.Find(new Entity.Specifications.POCO.Symptom.ById((int)id)).First());
                }
                else
                {
                    symptoms = repository.GetAll().ToList();
                }

                return symptoms;
            }
        }


        public Departament manageDepartament(DepartamentModel model)
        {
            using (var context = IoCContainer.Get<IEntity>())
            {
                Departament departament;
                var repositoryDepartament = context.GetRepository<IRepository<Departament>>();
                var repositoryGroups = context.GetRepository<IRepository<Group>>();
                if (model.id.HasValue)
                {
                    departament = repositoryDepartament.Find(new Entity.Specifications.POCO.Departament.ById((int)model.id), new List<Expression<Func<Departament, object>>>
                    {
                        t => t.groups
                    }).First();
                    departament.name = model.name;
                    departament.groups = new List<Group>();
                    
                }else
                {
                    departament = new Departament
                    {
                        name = model.name,
                        groups = new List<Group>()
                    };
                    repositoryDepartament.Add(departament);
                }
                departament.smallImage = model.smallImage;
                departament.bigImage = model.bigImage;
                departament.isMale = model.isMale;
                departament.isFemale = model.isFemale;
                departament.bigImageWoman = model.bigImageWoman;
                //
                var newGroups = model.groups;
                if(newGroups != null)
                {
                    newGroups.ForEach(t =>
                    {
                        var group = repositoryGroups.Find(new Entity.Specifications.POCO.Group.ById((int)t.id), new List<Expression<Func<Group, object>>>
                    {
                        q => q.symptoms
                    }).First();
                        departament.groups.Add(group);
                    });
                }
                
                context.SaveChanges();
                return departament;
            }
        }

        public Group manageGroup(GroupModel model)
        {
            using (var context = IoCContainer.Get<IEntity>())
            {
                Group group;
                var repositoryGroup = context.GetRepository<IRepository<Group>>();
                var repositorySymptoms = context.GetRepository<IRepository<Symptom>>();
                if (model.id.HasValue)
                {
                    group = repositoryGroup.Find(new Entity.Specifications.POCO.Group.ById((int)model.id), new List<Expression<Func<Group, object>>>
                    {
                        t => t.symptoms
                    }).First();
                    group.name = model.name;
                    group.symptoms = new List<Symptom>();
                    
                }
                else
                {
                    group = new Group
                    {
                        name = model.name
                    };
                    group.symptoms = new List<Symptom>();
                    repositoryGroup.Add(group);
                }
                group.image = model.image;
                group.isMale = model.isMale;
                group.isFemale = model.isFemale;
                group.imageWoman = model.imageWoman;
                //
                var newSymptoms = model.symptoms;
                newSymptoms.ForEach(t =>
                {
                    var symptom = repositorySymptoms.Find(new Entity.Specifications.POCO.Symptom.ById((int)t.id)).First();
                    group.symptoms.Add(symptom);
                });
                context.SaveChanges();
                return group;
            }
        }

        public Diagnos manageDiagnos(DiagnosModel model)
        {
            using (var context = IoCContainer.Get<IEntity>())
            {
                var repositoryDiagnos = context.GetRepository<IRepository<Diagnos>>();

                var repositorySymptom = context.GetRepository<IRepository<Symptom>>();

                var repositoryWeight = context.GetRepository<IRepository<Weight>>();

                var newDiagnos = new Diagnos();
                if (model.id.HasValue)
                {
                    newDiagnos = repositoryDiagnos.Find(new ById((int)model.id)).First();
                    newDiagnos.name = model.name;
                    
                }
                else
                {
                    newDiagnos = new Diagnos
                    {
                        name = model.name
                    };

                    newDiagnos.weights = new List<Weight>();

                    repositorySymptom.GetAll().ToList().ForEach(t => {
                        var weight = new Weight(t, new Random().Next(0, 10));
                        repositoryWeight.Add(weight);
                        newDiagnos.weights.Add(weight);
                    });
                    repositoryDiagnos.Add(newDiagnos);
                }
                newDiagnos.image = model.image;
                newDiagnos.descripton = model.descripton;

                context.SaveChanges();

                return newDiagnos;
            }
        }

        public Symptom manageSymptom(SymptomModel model)
        {
            using (var context = IoCContainer.Get<IEntity>())
            {
                var repositorySymptoms = context.GetRepository<IRepository<Symptom>>();

                var newSymptom = new Symptom();
                if (model.id.HasValue)
                {
                    newSymptom = repositorySymptoms.Find(new Entity.Specifications.POCO.Symptom.ById((int)model.id)).First();
                    newSymptom.name = model.name;
                }
                else
                {
                    newSymptom = new Symptom
                    {
                        name = model.name
                    };

                    repositorySymptoms.Add(newSymptom);

                    context.SaveChanges();

                    var repSymptoms = repositorySymptoms.GetAll().ToList();

                    var repositoryDiagnoses = context.GetRepository<IRepository<Diagnos>>();

                    var repositoryWeights = context.GetRepository<IRepository<Weight>>();

                    var a = repositoryDiagnoses.GetAll(new List<Expression<Func<Diagnos, object>>>
                    {
                        t => t.weights,
                        t => t.weights.Select(q=>q.Key)
                    }).ToList();
                    a.ForEach(t => {
                        var diagnos = t;
                        var weight = new Weight(newSymptom, new Random().Next(0, 10));
                        repositoryWeights.Add(weight);
                        context.SaveChanges();
                        var repWeight = repositoryWeights.GetAll().ToList();
                        diagnos.weights.Add(weight);
                    });
                }

                newSymptom.isMale = model.isMale;
                newSymptom.isFemale = model.isFemale;

                context.SaveChanges();
                
                return newSymptom;
            }
        }

        /// <summary>
        /// Функция распознавания символа, используется для обучения
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public List<KeyValuePair<Diagnos,int>> handleHard(List<KeyValuePair<Symptom, int>> input)
        {
            using (var context = IoCContainer.Get<IEntity>())
            {
                var repository = context.GetRepository<IRepository<Diagnos>>();

                var diagnoses = repository.GetAll(new List<Expression<Func<Diagnos, object>>>
                {
                    t => t.weights,
                    t => t.weights.Select(q=>q.Key)
                });

                var output = new List<KeyValuePair<Diagnos, int>>();

                foreach (var diagnos in diagnoses)
                {
                    output.Add(diagnos.transferHard(input));
                }
                return output;
            }

        }


        /// <summary>
        /// Функция распознавания символа, используется для конечного ответа
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public List<KeyValuePair<Diagnos, int>> handle(List<KeyValuePair<Symptom, int>> input)
        {
            using (var context = IoCContainer.Get<IEntity>())
            {
                var repository = context.GetRepository<IRepository<Diagnos>>();

                var diagnoses = repository.GetAll(new List<Expression<Func<Diagnos, object>>>
                {
                    t => t.weights,
                    t => t.weights.Select(q=>q.Key)
                });

                var output = new List<KeyValuePair<Diagnos, int>>();

                foreach (var diagnos in diagnoses)
                {
                    output.Add(diagnos.transfer(input));
                }
                return output;
            }
        }


        /// <summary>
        /// Ответ сети
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public int getAnswer(List<KeyValuePair<Symptom, int>> input)
        {
            List<KeyValuePair<Diagnos, int>> output = handle(input);
            int idMaxDiagnos = 0;
            int? maxValue = null;
            output.ForEach(t => {
                if(t.Value > maxValue || !maxValue.HasValue)
                {
                    idMaxDiagnos = t.Key.id;
                    maxValue = t.Value;
                }
                
            });

            return idMaxDiagnos;
        }

        /// <summary>
        /// Развернутый ответ сети
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public List<KeyValuePair<Diagnos, int>> fullAnswer(List<KeyValuePair<Symptom, int>> input)
        {
            List<KeyValuePair<Diagnos, int>> output = handle(input);
            
            return output;
        }


        /// <summary>
        /// Функция обучения
        /// </summary>
        /// <param name="input"></param>
        /// <param name="idCorrectDiagnos"></param>
        public void study(List<KeyValuePair<Symptom, int>> input, int idCorrectDiagnos)
        {
            using (var context = IoCContainer.Get<IEntity>())
            {
                var repository = context.GetRepository<IRepository<Diagnos>>();
                var repositoryWeights = context.GetRepository<IRepository<Weight>>();

                List<KeyValuePair<Diagnos, int>> output = handleHard(input);

                List<KeyValuePair<Diagnos, int>> correctOutput = new List<KeyValuePair<Diagnos, int>>();

                foreach (var item in output)
                {
                    var newItem = (item.Key.id == idCorrectDiagnos) ? new KeyValuePair<Diagnos, int>(item.Key, 1) : new KeyValuePair<Diagnos, int>(item.Key, 0);
                    correctOutput.Add(newItem);
                }

                while (!compareOutput(correctOutput, output))
                {

                    foreach (var item in output)
                    {
                        var correctItem = correctOutput.First(t => t.Key.id == item.Key.id);
                        int dif = correctItem.Value - item.Value;
                        var newWeights = item.Key.changeWeights(input, dif);
                        foreach(var itemW in newWeights)
                        {
                            var repWeight = repositoryWeights.Find(new Entity.Specifications.POCO.Weight.ById(itemW.id)).First();
                            repWeight.Value = itemW.Value;
                        }
                        context.SaveChanges();

                    }
                    output = handleHard(input);
                    
                }
                
            }
           
        }

        public bool compareOutput(List<KeyValuePair<Diagnos, int>> output1, List<KeyValuePair<Diagnos, int>> output2)
        {
            var returnVal = true;
            if (output1.Count() != output2.Count())
            {
                return false;
            }
            output1.ForEach(t =>
            {
                if(t.Value != output2.First(q => q.Key.id == t.Key.id).Value)
                {
                    returnVal = false;
                }
            });
            return returnVal;
        }

    }
}