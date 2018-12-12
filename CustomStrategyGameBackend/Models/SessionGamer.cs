using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CustomStrategyGameBackend.Models
{
    [Table("SessionGamers")]
    public partial class SessionGamer
    {
        [Key]
        public long Id { get; set; }
        [Required, MaxLength(128)]
        public string Session_Id { get; set; }
        [Required]
        public long Gamer_Id { get; set; }

        public Gamer Gamer { get; set; }
        public GameSession GameSession { get; set; }
    }
}