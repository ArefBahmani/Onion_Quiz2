using App.Domain.Core.CardToCard.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.CardToCard.User.Data.Repository
{
    public interface IUserRepository
    {
        public void GenerateAndSaveVerificationCode(int userId, string fullName, int verificationCode, DateTime expirationTime);
        public VerificationDto GetVerificationDataById(int userId);
        public void SaveVerificationData(VerificationDto verificationDto);
    }
}
