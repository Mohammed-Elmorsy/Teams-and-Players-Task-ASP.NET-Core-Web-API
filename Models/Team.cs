using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;


namespace TeamsPlayersTaskWebAPI_MohammedElmorsy.Models
{
    public class Team
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string Name { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string Country { get; set; }

        public DateTime FoundationDate { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string CoachName { get; set; }

        [Required]
        public string LogoImageName { get; set; }

        public virtual List<Player> Players { get; set; }

        [NotMapped]
        public IFormFile LogoImage { get; set; }
    }
}
