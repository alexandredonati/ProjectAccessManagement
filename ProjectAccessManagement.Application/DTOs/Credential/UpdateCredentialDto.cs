using System;

namespace ProjectAccessManagement.Application.DTOs.Credential
{
    public class UpdateCredentialDto
    {
        public Guid CredentialId { get; set; }
        public DateTime? NewExpiryDate { get; set; }
        public bool? AllowMultiAccess { get; set; }
    }
} 