using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashFlow.Domain.Security.Cryptography;
public interface IPasswordEncripter
{
    string Encrypt(string password);
    bool Verify(string password, string passwordHash);
}
