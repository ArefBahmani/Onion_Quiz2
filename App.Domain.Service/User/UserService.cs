using App.Domain.Core.CardToCard.Card.Data.Repository;
using App.Domain.Core.CardToCard.User.Data.Repository;
using App.Infra.Data.Repos.Ef.CardToCard.Card;
using App.Infra.Data.Repos.Ef.CardToCard.Transaction;
using App.Infra.Data.Repos.Ef.CardToCard;

using App.Infra.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Infra.Data.Repos.Ef.CardToCard;
using App.Domain.Core.CardToCard.User;

namespace App.Domain.Service.User
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
       
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
            
        }



        public string GenerateVerificationCode(int userId, string fullName)
        {
            var existingVerification = _userRepository.GetVerificationDataById(userId);

            if (existingVerification != null && existingVerification.DateVerificationCode > DateTime.Now)
            {
                return "Code Already Sent";
            }

            var random = new Random();
            int verificationCode = random.Next(10000, 99999);
            DateTime expirationTime = DateTime.Now.AddMinutes(5);
            _userRepository.GenerateAndSaveVerificationCode(userId, fullName, verificationCode, expirationTime);
            return $"Code Send";
        }
        public string CodeRandom()
        {
            var random = new Random();
            int verificationCode = random.Next(10000, 99999);
            _userRepository.InsertCode(verificationCode);
            return verificationCode.ToString();
        }

        public bool ValidateVerificationCode(int userId, string fullName, int verificationCode)
        {
            var verificationDto = _userRepository.GetVerificationDataById(userId);
            if (verificationDto != null &&
                verificationDto.FullName == fullName &&
                verificationDto.VerificationCode == verificationCode)
            {
                if (verificationDto.DateVerificationCode > DateTime.Now)
                {
                    verificationDto.DateVerificationCode = DateTime.Now.AddMinutes(-1);
                    _userRepository.SaveVerificationData(verificationDto);
                    return true;
                }
            }
            return false;
        }
    }
}
