using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectAccessManagement.Domain.Enums
{
    public enum CredentialType
    {
        LoginPassword,
        ApiToken,
        OAuth2,
        JWT,
        SSHKey,
        Certificate
    }
}
