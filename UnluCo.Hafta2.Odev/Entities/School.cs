using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace UnluCo.Hafta2.Odev.Entities
{
    public class School
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
