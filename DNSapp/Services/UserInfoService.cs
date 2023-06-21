using DNSapp.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DNSapp.Services
{
    public class UserInfoService
    {
        public UserInfoDto Add(UserInfoDto userDto)
        {
            using (DnsMyAssContext db = new DnsMyAssContext())
            {
                UserInfo userInfo = new UserInfo()
                {
                    Id = userDto.Id,
                    FirstName = userDto.FirstName,
                    SecondName = userDto.SecondName,
                    PhoneNumber = userDto.PhoneNumber,
                };

                // добавляем их в бд
                db.UserInfos.Add(userInfo);
                db.SaveChanges();

                UserInfoDto userInfoDTO = new UserInfoDto()
                {
                    Id = userInfo.Id,
                    FirstName = userInfo.FirstName,
                    SecondName = userInfo.SecondName,
                    PhoneNumber = userInfo.PhoneNumber,
                };
                return userInfoDTO;

            }
        }

        private UserInfo? Get(int Id)
        {
            using (DnsMyAssContext db = new DnsMyAssContext())
            {
                UserInfo userInfo = db.UserInfos.Where(u => u.Id == Id).FirstOrDefault();
                return userInfo;
            }
        }

        public UserInfoDto? GetDto(int Id)
        {
            using (DnsMyAssContext db = new DnsMyAssContext())
            {
                UserInfo userInfo = db.UserInfos.Where(u => u.Id == Id).FirstOrDefault();
                if (userInfo == null)
                {
                    return null;
                }
                else
                {
                UserInfoDto dto = new UserInfoDto()
                {
                    Id = userInfo.Id,
                    FirstName = userInfo.FirstName,
                    SecondName = userInfo.SecondName,
                    PhoneNumber = userInfo.PhoneNumber,
                };
                return dto;
                }
            };
        }

        public List<UserInfoDto> GetAllDto()
        {
            using (DnsMyAssContext db = new DnsMyAssContext())
            {
                List<UserInfo> usersInfo = db.UserInfos.ToList();
                List<UserInfoDto> usersInfoDto = new List<UserInfoDto>();
                foreach (UserInfo userInfo in usersInfo)
                {
                    UserInfoDto dto = new UserInfoDto()
                    {
                        Id = userInfo.Id,
                        FirstName = userInfo.FirstName,
                        SecondName = userInfo.SecondName,
                        PhoneNumber = userInfo.PhoneNumber,
                    };
                    usersInfoDto.Add(dto);
                }
                return usersInfoDto;
            };
        }

        public bool Edit(UserInfoDto user)
        {
            using (DnsMyAssContext db = new DnsMyAssContext())
            {
                UserInfo? userInfo = Get(user.Id);
                if (userInfo != null)
                {
                    userInfo.FirstName = user.FirstName;
                    userInfo.SecondName = user.SecondName;
                    userInfo.PhoneNumber = user.PhoneNumber;
                    db.UserInfos.Update(userInfo);
                    db.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }


            // получаем экземпляр класса БД UserInfo вызывая метод Get
            // полученному экземпляру назначаем данные из UserInfoDTO, который получили из параметров
            // производим изменение данных в БД
            // конвертируем в dto
            // возвращаем dto
        }

        public void Remove(int Id)
        {
            using (DnsMyAssContext db = new DnsMyAssContext())
            {
                UserInfo? userInfo = db.UserInfos.Where(u => u.Id == Id).FirstOrDefault();
                if (userInfo != null)
                {
                    db.UserInfos.Remove(userInfo);
                    db.SaveChanges();
                }
            }
        }



    }
}
