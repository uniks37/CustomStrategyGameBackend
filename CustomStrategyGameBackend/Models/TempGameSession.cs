using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CustomStrategyGameBackend.Models
{
    [Table("TempGameSessions")]
    public class TempGameSession
    {
        [Key]
        public long Id { get; set; }
        [Required, StringLength(128), DatabaseGenerated(DatabaseGeneratedOption.None), Index(IsUnique =true)]
        public string temp_Id { get; set; }
        [Required, StringLength(128)]
        public string Temp_Session_Id { get; set; }
        [Required]
        public long Gamer1_Id { get; set; }
        [Required]
        public long Gamer2_Id { get; set; }
    }
}