using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TeamsPlayersTaskWebAPI_MohammedElmorsy.Models
{
    public enum Role
    {
        User = 1,
        Admin = 2
    }
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [DataType(DataType.Text)]

        [Required(AllowEmptyStrings = false, ErrorMessage = "The User name can not be empty")]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "User Name field must have minimum 3 and maximum 15 character!")]
        public string UserName { get; set; }

        [DataType(DataType.Password)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "UserPassword  cannot be empty!")]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "UserPassword must have minimum 5 and maximum 15 character!")]
        public string Password { get; set; }

        [MaxLength(50)]
        public string FirstName { get; set; }
        public string LastName { get; set; }

        [MaxLength(50)]
        [EmailAddress]
        public string Email { get; set; }

        [MaxLength(50)]
        [Phone]
        public string PhoneNumber { get; set; }

        public Role Role { get; set; }

        public string Token { get; set; }
    }
}
