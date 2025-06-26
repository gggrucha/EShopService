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

    [MaxLength(100)]
    public string Username { get; set; } 

    [MaxLength(255)]
    public string Email { get; set; } = string.Empty;

    public string PasswordHash { get; set; }

    // public ICollection<Role> Roles { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow.AddDays(-20);

    public DateTime? LastLoginAt { get; set; } = DateTime.UtcNow.AddMinutes(-10);

    public bool IsActive { get; set; } = true;

}
