using static System.Net.Mime.MediaTypeNames;
using System.Numerics;
using System.Reflection;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Core.Domain.Model
{
    public class User : IdentityUser
    {
        public string UserType { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Gender Gender { get; set; }

        public byte[]? Image { get; set; }

    }
}