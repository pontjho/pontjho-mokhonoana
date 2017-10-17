using System;
using System.ComponentModel.DataAnnotations;

namespace Absa.Assessment.Api.Client
{
    public class ClientModel
    {
        public Guid Id { get; set; }

        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string Surname { get; set; }

        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string FirstNames { get; set; }

        [Required]
        public ClientIdentityType IdentityType { get; set; }

        [StringLength(13)]
        [Required]
        public string IdentityNumber { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }
    }
}
