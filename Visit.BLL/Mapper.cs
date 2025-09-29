using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Visit.Shared;

namespace Visit.DAL
{
    public static class Mapper
    {
        public static User MapToUser(this BimarInfo info)
        {
            User user = new User()
            {
                FirstName = info.FirstName,
                LastName = info.LastName,
                MobileNumber = info.MobileNumber,
                Email = info.Email,
                Picture = info.Picture,
            };
            return user;
        }
        public static User MapToUser(this DoctorInfo info)
        {
            User user = new User()
            {
                FirstName = info.FirstName,
                LastName = info.LastName,
                MobileNumber = info.MobileNumber,
                Email = info.Email,
                Picture = info.Picture,
            };
            return user;
        }
        public static Bimar MapToBimar(this BimarInfo info) 
        {
            Bimar bimar = new Bimar()
            {
                NationalCode = info.NationalCode
            };
            return bimar;
        }
        public static Doctor MapToDoctor(this DoctorInfo info)
        {
            Doctor doctor = new Doctor()
            {
                DoctorID = info.DoctorID,
                CodeNezamPezeshki = info.CodeNezamPezeshki,
            };
            return doctor;
        }
    }
}
