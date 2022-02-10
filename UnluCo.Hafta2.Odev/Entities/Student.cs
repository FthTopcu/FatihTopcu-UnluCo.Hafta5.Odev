using System;
using System.ComponentModel.DataAnnotations.Schema;


namespace UnluCo.Hafta2.Odev.Entities
{
    public class Student
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public int SchoolId { get; set; }
        public School School { get; set; }
    }
}
