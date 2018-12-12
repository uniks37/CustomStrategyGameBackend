using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CustomStrategyGameBackend.Models
{
    [Table ("GameSessions")]
    public class GameSession
    {
        [Key]
        public long Id { get; set; }
        [Required, StringLength(128), DatabaseGenerated(DatabaseGeneratedOption.None), Index(IsUnique = true)]
        public string Session_Id { get; set; }
        [Required, Timestamp, DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public Byte[] Timestamp { get; set; }
        [StringLength(128), Index(IsUnique =true)]
        public string Board_Id { get; set; }
        [Required]
        public bool Status { get; set; }

        public ICollection<SessionGamer> SessionGamers { get; set; }
    }
}