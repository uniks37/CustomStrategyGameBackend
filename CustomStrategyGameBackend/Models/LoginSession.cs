using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CustomStrategyGameBackend.Models
{
    [Table("LoginSessions")]
    public class LoginSession
    {
        [Key]
        public long Id { get; set; }
        [Required, StringLength(128), DatabaseGenerated(DatabaseGeneratedOption.None), Index(IsUnique = true)]
        public string Login_Session_Id { get; set; }
        public long Gamer_Id { get; set; }
        [Required, Timestamp, DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public Byte[] Timestamp { get; set; }

        public Gamer Gamer { get; set; }
    }
}