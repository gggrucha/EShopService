using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientData.Domain.Models;
public class Client
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(100)]
    public string Username { get; set; }

    [Required]
    [MaxLength(255)]
    public string Email { get; set; }

    [Required]
    public string PasswordHash { get; set; }

    // public ICollection<Role> Roles { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public DateTime? LastLoginAt { get; set; }

    public bool IsActive { get; set; } = true;

}
