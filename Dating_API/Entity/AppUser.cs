using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dating_API.Extensions;

namespace Dating_API.Entity
{
    public class AppUser
    {
        public int id { get; set; }
        public string Username { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string KnownAs { get; set; }
        public DateTime Created { get; set; }=DateTime.UtcNow;
        public DateTime LastActive { get; set; } =DateTime.UtcNow;
        public string Gender { get; set; }
        public string LookingFor { get; set; }
        public string Interests { get; set; }
        public int MyProperty { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public List<Photos> Photos { get; set; }=new ();
    }
}
