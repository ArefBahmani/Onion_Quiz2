using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.CardToCard.User
{
    public interface IUserService
    {
        public bool ValidateVerificationCode(int userId, string fullName, int verificationCode);
        public string GenerateVerificationCode(int userId, string fullName);
        public string CodeRandom();
    }
}
