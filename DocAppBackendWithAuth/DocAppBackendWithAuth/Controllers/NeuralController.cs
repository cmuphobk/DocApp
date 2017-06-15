using DocAppBackendWithAuth.Entity.POCO;
using DocAppBackendWithAuth.Logic;
using DocAppBackendWithAuth.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DocAppBackendWithAuth.Controllers
{
    [Authorize]
    [RoutePrefix("api/Neural")]
    public class NeuralController : ApiController
    {
        [HttpGet]
        [Route("Departaments")]
        public IEnumerable<DepartamentModel> GetDepartaments(int? id)
        {
            var list = new List<DepartamentModel>();
            new NeuralLogic().getDepartaments(id).ForEach(t => list.Add(t.toModel()));
            return list;
        }

        [HttpGet]
        [Route("Groups")]
        public IEnumerable<GroupModel> GetGroups(int? id, int? idDepartament)
        {
            var list = new List<GroupModel>();
            if (idDepartament.HasValue)
            {
                var listByIdDep = new List<GroupModel>();
                new NeuralLogic().getGroupsByDepartament((int)idDepartament).ForEach(t => listByIdDep.Add(t.toModel()));
                if (id.HasValue)
                {
                    listByIdDep = listByIdDep.Where(t => t.id == (int)id).ToList();
                }
                list = listByIdDep;
            }
            else
            {
                new NeuralLogic().getGroups(id).ForEach(t => list.Add(t.toModel()));
            }
            
            return list;
        }

        [HttpGet]
        [Route("Diagnoses")]
        public IEnumerable<DiagnosModel> GetDiagnoses(int? id)
        {
            var list = new List<DiagnosModel>();
            new NeuralLogic().getDiagnoses(id).ForEach(t => list.Add(t.toModel()));
            return list;
        }

        [HttpGet]
        [Route("Symptoms")]
        public IEnumerable<SymptomModel> GetSymptoms(int? id, int? idGroups)
        {
            var list = new List<SymptomModel>();
            if (idGroups.HasValue)
            {
                var listByIdGr = new List<SymptomModel>();
                new NeuralLogic().getSymptomsByGroup((int)idGroups).ForEach(t => listByIdGr.Add(t.toModel()));
                if (id.HasValue)
                {
                    listByIdGr = listByIdGr.Where(t => t.id == (int)id).ToList();
                }
                list = listByIdGr;
            }
            else
            {
                new NeuralLogic().getSymptoms(id).ForEach(t => list.Add(t.toModel()));
            }
            return list;
        }

        [HttpPost]
        [Route("Departament")]
        public HttpResponseMessage Departament(DepartamentModel model)
        {
            var departament = new NeuralLogic().manageDepartament(model).toModel();

            return Request.CreateResponse(HttpStatusCode.OK, departament);
        }

        [HttpDelete]
        [Route("Departament")]
        public HttpResponseMessage DepartamentRemove(DepartamentModel model)
        {
            new NeuralLogic().removeDepartament(model);

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpPost]
        [Route("Group")]
        public HttpResponseMessage Group(GroupModel model)
        {
            var group = new NeuralLogic().manageGroup(model).toModel();

            return Request.CreateResponse(HttpStatusCode.OK, group);
        }

        [HttpDelete]
        [Route("Group")]
        public HttpResponseMessage GroupRemove(GroupModel model)
        {
            new NeuralLogic().removeGroup(model);

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpPost]
        [Route("Diagnos")]
        public HttpResponseMessage Diagnos(DiagnosModel model)
        {
            var diagnos = new NeuralLogic().manageDiagnos(model).toModel(); 
            
            return Request.CreateResponse(HttpStatusCode.OK, diagnos);
        }

        [HttpDelete]
        [Route("Diagnos")]
        public HttpResponseMessage DiagnosRemove(DiagnosModel model)
        {
            new NeuralLogic().removeDiagnos(model);

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpPost]
        [Route("Symptom")]
        public HttpResponseMessage Symptom(SymptomModel model)
        {
            var symptom = new NeuralLogic().manageSymptom(model).toModel();
            return Request.CreateResponse(HttpStatusCode.OK, symptom);
        }

        [HttpDelete]
        [Route("Symptom")]
        public HttpResponseMessage SymptomRemove(SymptomModel model)
        {
            new NeuralLogic().removeSymptom(model);

            return Request.CreateResponse(HttpStatusCode.OK);
        }


        [HttpPost]
        [Route("Answer")]
        public HttpResponseMessage GetAnswer(List<SymptomModel> symptoms)
        {
            var symptomsPoco = new List<KeyValuePair<Symptom, int>>();
            var logic = new NeuralLogic();
            symptoms.ForEach(t => symptomsPoco.Add(new KeyValuePair<Symptom, int>(logic.getSymptoms(t.id).First(), 1)));
            var ressult = logic.getAnswer(symptomsPoco);
            return Request.CreateResponse(HttpStatusCode.OK, ressult);
        }

        [HttpPost]
        [Route("FullAnswer")]
        public HttpResponseMessage GetFullAnswer(List<SymptomModel> symptoms)
        {
            var symptomsPoco = new List<KeyValuePair<Symptom, int>>();
            var logic = new NeuralLogic();
            symptoms.ForEach(t => symptomsPoco.Add(new KeyValuePair<Symptom, int>(logic.getSymptoms(t.id).First(), 1)));
            var ressult = logic.fullAnswer(symptomsPoco);
            return Request.CreateResponse(HttpStatusCode.OK, ressult);
        }

        [HttpPost]
        [Route("Study")]
        public HttpResponseMessage Study(int id, List<SymptomModel> symptoms)
        {
            var symptomsPoco = new List<KeyValuePair<Symptom, int>>();
            var logic = new NeuralLogic();
            symptoms.ForEach(t => symptomsPoco.Add(new KeyValuePair<Symptom, int>(logic.getSymptoms(t.id).First(), 1)));
            logic.study(symptomsPoco, id);
            return Request.CreateResponse(HttpStatusCode.OK);
        }
        
    }
}
