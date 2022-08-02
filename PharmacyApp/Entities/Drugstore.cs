using Core.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Drugstore : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Adress { get; set; }
        public string ContactNumber { get; set; }
        public List<Drug> Drugs { get; set; }
        public List<Druggist> Druggists { get; set; }
        public Owner Owner { get; set; }
    }
}
