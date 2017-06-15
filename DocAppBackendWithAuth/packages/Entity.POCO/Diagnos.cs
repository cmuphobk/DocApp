using DocAppBackendWithAuth.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DocAppBackendWithAuth.Entity.POCO
{
    public class Diagnos
    {   
        public Diagnos()
        {
            weights = new List<Weight>();
        }
        /// <summary>
        /// Идентификатор
        /// </summary>
        public int id { get; set; }


        /// <summary>
        /// Имя
        /// </summary>
        public string name { get; set; }

        /// <summary>
        /// descripton
        /// </summary>
        public string descripton { get; set; }

        

        /// <summary>
        /// Изображение
        /// </summary>
        public byte[] image { get; set; }

        public List<Disease> diseases { get; set; }


        /// <summary>
        /// Пороговая переменная
        /// </summary>
        public static int minimum = 50;


        /// <summary>
        /// Веса
        /// </summary>
        public virtual List<Weight> weights { get; set; }

        /// <summary>
        /// Удален ли
        /// </summary>
        public bool isDelete { get; set; }


        /*public Diagnos addSympthom(Symptom symptom)
        {
            if (weights == null)
            {
                weights = new List<Weight>();
            }
            weights.Add(new Weight(symptom, new Random().Next(0, 10)));
            return this;
        }*/


        /// <summary>
        /// Жесткий результат
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public KeyValuePair<Diagnos, int> transferHard(List<KeyValuePair<Symptom, int>> input)
        {
            int power = 0;

            foreach(var weight in weights)
            {
                var a = input.Where(t => t.Key.id == weight.Key.id).ToList();
                if (a.Count() != 0)
                {
                    power += weight.Value * a.First().Value;
                }
                
            }

            var returnValue =  power >= minimum ? 1 : 0;

            return new KeyValuePair<Diagnos, int>(this, returnValue);
        }

        /// <summary>
        /// Результат
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public KeyValuePair<Diagnos, int> transfer(List<KeyValuePair<Symptom, int>> input)
        {
            int power = 0;

            foreach (var weight in weights)
            {
                var a = input.Where(t => t.Key.id == weight.Key.id).ToList();
                if (a.Count() != 0)
                {
                    power += weight.Value * a.First().Value;
                }
            }

            return new KeyValuePair<Diagnos, int>(this, power);
        }


        /// <summary>
        /// Устанавливает начальные произвольные значения весам 
        /// </summary>
        public Diagnos randomizeWeights() 
        {          
            if(weights == null)
            {
                weights = new List<Weight>();
            }
            weights.ForEach(t => t = new Weight(t.Key, new Random().Next(0, 10)));

            return this;   
        }

        /// <summary>
        /// изменяет веса нейронов
        /// </summary>
        /// <param name="input"></param>
        /// <param name="d"></param>
        public List<Weight> changeWeights(List<KeyValuePair<Symptom, int>> input, int d)
        {
            if (weights == null)
            {
                weights = new List<Weight>();
            }

            weights.ForEach(t => {
                var a = input.Where(i => i.Key.id == t.Key.id).ToList();
                if(a.Count() != 0)
                {
                    t.Value += a.First().Value * d;
                }
                
            });

            return weights;
        }

        public DiagnosModel toModel()
        {
            return new DiagnosModel
            {
                id = this.id,
                name = this.name,
                image = this.image,
                descripton = this.descripton
            };

        }

    }
}
