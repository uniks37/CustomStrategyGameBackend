namespace CustomStrategyGameBackend.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Gamers")]
    public partial class Gamer
    {
        [Key]
        public long Id { get; set; }
        [Required, StringLength(32), Index(IsUnique =true)]
        public string Uname { get; set; }
        [Required, StringLength(50), Index(IsUnique = true)]
        public string Email_Id { get; set; }
        [Required, MaxLength(128)]
        public string Password { get; set; }
        [Required]
        public bool IsOnline { get; set; }
        public long Games_Won { get; set; }
        public long Games_Lost { get; set; }
        public long Games_Total { get; set; }

        public ICollection<SessionGamer> SessionGamers { get; set; }
        public ICollection<LoginSession> LoginSessions { get; set; }
    }
}
