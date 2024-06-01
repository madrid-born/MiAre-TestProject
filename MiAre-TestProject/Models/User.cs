using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;


namespace MiAre_TestProject.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool IsAdmin { get; set; }
        public string Address { get; set; }
        public string PreviousAddressesJson { get; set; } = JsonSerializer.Serialize(new List<string>());

        [NotMapped]
        public List<string> PreviousAddresses { get; set; }
        
        public void SerializePreviousAddresses()
        {
            PreviousAddressesJson = JsonSerializer.Serialize(PreviousAddresses);
        }
        
        public void DeserializePreviousAddresses()
        {
            PreviousAddresses = JsonSerializer.Deserialize<List<string>>(PreviousAddressesJson);
        }
    }
}