using App.Domain.Core.CardToCard.DTOs;
using App.Domain.Core.CardToCard.User;
using App.Domain.Core.CardToCard.User.Data.Repository;
using App.Domain.Core.CardToCard.User.Entity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infra.Data.Repos.Ef.CardToCard
{
    public class UserRepository : IUserRepository
    {
        public List<User> users = new List<User>();
        private readonly string _path = @"C:\Users\rayank\source\repos\User.txt";


        public UserRepository()
        {
            var directory = Path.GetDirectoryName(_path);
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            if (!File.Exists(_path))
            {
                File.WriteAllText(_path, "[]");
            }
        }
        public  void InsertCode(int temp)
        {


            string text = JsonConvert.SerializeObject(temp);
            File.WriteAllText(_path, temp.ToString());
        }

        
        public void GenerateAndSaveVerificationCode(int userId, string fullName, int verificationCode, DateTime expirationTime)
        {
            var data = File.ReadAllText(_path);
            var verificationDataList = JsonConvert.DeserializeObject<List<VerificationDto>>(data);
            if (verificationDataList == null)
            {
                verificationDataList = new List<VerificationDto>();
            }
            var verification = verificationDataList.FirstOrDefault(v => v.Id == userId);
            if (verification != null)
            {
                verification.FullName = fullName;
                verification.VerificationCode = verificationCode;
                verification.DateVerificationCode = expirationTime;
            }
            else
            {
                var verificationDto = new VerificationDto
                {
                    Id = userId,
                    FullName = fullName,
                    VerificationCode = verificationCode,
                    DateVerificationCode = expirationTime
                };
                verificationDataList.Add(verificationDto);
            }
            string json = JsonConvert.SerializeObject(verificationDataList);
            File.WriteAllText(_path, json);
        }


        public VerificationDto GetVerificationDataById(int userId)
        {
            var data = File.ReadAllText(_path);
            var verificationCode = JsonConvert.DeserializeObject<List<VerificationDto>>(data);
            return verificationCode.FirstOrDefault(x => x.Id == userId);
        }

        public void SaveVerificationData(VerificationDto verificationDto)
        {
            var data = File.ReadAllText(_path);
            var verificationDataList = JsonConvert.DeserializeObject<List<VerificationDto>>(data);
            if (verificationDataList == null)
            {
                verificationDataList = new List<VerificationDto>();
            }
            var verification = verificationDataList.FirstOrDefault(v => v.Id == verificationDto.Id);
            if (verification != null)
            {
                verification.FullName = verificationDto.FullName;
                verification.VerificationCode = verificationDto.VerificationCode;
                verification.DateVerificationCode = verificationDto.DateVerificationCode;
            }

            else
            {
                verificationDataList.Add(verificationDto);
            }
            var jsonData = JsonConvert.SerializeObject(verificationDataList);
            File.WriteAllText(_path, jsonData);
        }
    }
}

