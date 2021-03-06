using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TesteDiaADia.Interfaces;

namespace TesteDiaADia.Models
{
    [Table("Entities")]
    public class Entity : IIdentifiable
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsGood { get; set; }
        public DateTimeOffset CreationDate { get; set; }
        public DateTimeOffset LastModified { get; set; }
    }
}
