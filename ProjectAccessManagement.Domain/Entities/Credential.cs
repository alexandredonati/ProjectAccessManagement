using ProjectAccessManagement.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectAccessManagement.Domain.Entities
{
    public class Credential
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public Application Application { get; set; }
        public CredentialType CredentialType { get; set; }
        public DateTime ExpireDate { get; set; }

        public bool AllowsMultiAccess { get; set; }
    }
}
