using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace UserService.Model
{
    [Table("User")]
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; } // Primary Key
        [Required]
        public string UserName { get; set; }
        [Required]
        public string FullName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        public string? Avatar { get; set; }
        public DateTime? DOB { get; set; }
        public string? BankNumber { get; set; }
        public string? BankName { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public string? DeleteTime { get; set; }
    }
}
