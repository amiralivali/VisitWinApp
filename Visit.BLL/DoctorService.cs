using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Visit.DAL;
using Visit.Shared;

namespace Visit.BLL
{
    public class DoctorService
    {
        ValidationLogic valid;
        DoctorRepository repository;
        public DoctorService()
        {
            valid = new ValidationLogic();
            repository = new DoctorRepository();
        }
        public async Task<OprationResult> CheckDataAsync(DoctorInfo info)
        {
            bool validationNum = valid.ValidationNumber(info.MobileNumber);
            bool validationNezam = valid.ValidationNezam(info.CodeNezamPezeshki);
            bool checkEmail = string.IsNullOrEmpty(info.Email);
            if (!validationNum)
            {
                return OprationResult.FalseValidation(Messages.Mobile);
            }
            else if (!validationNezam)
            {
                return OprationResult.FalseValidation(Messages.Nezam);
            }
            else if (!checkEmail)
            {
                bool validationEmail = valid.ValidationEmail(info.Email);
                if (!validationEmail)
                {
                    return OprationResult.FalseValidation(Messages.Email);
                }
            }
            if (info.DoctorID > 0)
            {
                if (await repository.DuplicateNezamAsync(info.CodeNezamPezeshki, info.DoctorID))
                {
                    return OprationResult.Duplicate(Messages.Nezam);
                }
                else if (await repository.DuplicateMobileAsync(info.MobileNumber, info.DoctorID))
                {
                    return OprationResult.Duplicate(Messages.Mobile);
                }
                else if (checkEmail == false && await repository.DuplicateEmailAsync(info.Email, info.DoctorID))
                {
                    return OprationResult.Duplicate(Messages.Email);
                }
                else
                {
                    return OprationResult.Success(Messages.Update);
                }
            }
            else
            {
                if (await repository.DuplicateNezamAsync(info.CodeNezamPezeshki))
                {
                    return OprationResult.Duplicate(Messages.Nezam);
                }
                else if (await repository.DuplicateMobileAsync(info.MobileNumber))
                {
                    return OprationResult.Duplicate(Messages.Mobile);
                }
                else if (checkEmail == false && await repository.DuplicateEmailAsync(info.Email))
                {
                    return OprationResult.Duplicate(Messages.Email);
                }
                else
                {
                    return OprationResult.Success(Messages.Insert);
                }
            }
        }
        public async Task<OprationResult> InsertAsync(DoctorInfo info)
        {
            var checkData = await CheckDataAsync(info);
            if (checkData.IsSuccess)
            {
                User user = info.MapToUser();
                Doctor doctor=info.MapToDoctor();
                bool check = await repository.InsertAsync(user,doctor);
                if (check)
                {
                    return checkData;
                }
                else
                {
                    return OprationResult.RunTimeError();
                }
            }
            else
            {
                return checkData;
            }
        }
        public async Task<OprationResult> UpdateAsync(DoctorInfo info)
        {
            var checkData = await CheckDataAsync(info);
            if (checkData.IsSuccess)
            {
                bool check = await repository.UpdateAsync(info);
                if (check)
                {
                    return checkData;
                }
                else
                {
                    return OprationResult.RunTimeError();
                }
            }
            else
            {
                return checkData;
            }
        }
        public async Task<OprationResult> DeleteAsync(int id)
        {
            bool check = await repository.DeleteAsync(id);
            if (check)
            {
                return OprationResult.Success(Messages.Delete);
            }
            else
            {
                return OprationResult.RunTimeError();
            }
        }
        public async Task<OprationResult<List<DoctorDto>>> SelectAsync(string search = "")
        {
            var doctors = await repository.SelectAsync(search);
            if (doctors != null)
            {
                return OprationResult<List<DoctorDto>>.Succes(doctors);
            }
            else
            {
                return OprationResult<List<DoctorDto>>.RunTimeError();
            }
        }
        public async Task<bool> ExistAsync(string Nezam, string Mobile)
        {
            bool exist = await repository.ExistAsync(Nezam, Mobile);
            return exist;
        }
    }
}
