using System;

namespace Absa.Assessment.Api.Client
{
    public class ClientModel
    {
        public Guid Id { get; set; }
        public string Surname { get; set; }
        public string FirstNames { get; set; }
        public ClientIdentityType IdentityType { get; set; }
        public string IdentityNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
