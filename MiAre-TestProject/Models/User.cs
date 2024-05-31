using System.Collections.Generic;

namespace MiAre_TestProject.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public bool IsAdmin { get; set; }
        public string Address { get; set; }
        public string PreviousAddressesJson { get; set; }
        public List<string> PreviousAddresses { get; set; }
    }
}