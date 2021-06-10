using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MyDogs.Models
{
    [Table("MYDOGS")]
    public class Dog
    {
        [Key]
        public int DogId { get; set; }
        public string Race { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public double Poids { get; set; }
    }
}
