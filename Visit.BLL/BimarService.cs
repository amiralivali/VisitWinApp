using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Visit.DAL;
using Visit.Shared;

namespace Visit.BLL
{
    public class BimarService
    {
        ValidationLogic valid;
        BimarRepository repository;
        public BimarService()
        {
            valid = new ValidationLogic();
            repository = new BimarRepository();
        }

        public async Task<OprationResult> CheckDataAsync(BimarInfo info)
        {
            bool validationNum = valid.ValidationNumber(info.MobileNumber);
            bool validationNC = valid.ValidationNationalCode(info.NationalCode);
            bool checkEmail = string.IsNullOrEmpty(info.Email);
            if (validationNum == false)
            {
                return OprationResult.FalseValidation(Messages.Mobile);
            }
            else if (validationNC == false)
            {
                return OprationResult.FalseValidation(Messages.NationalCode);
            }
            else if (checkEmail == false)
            {
                bool validationEmail = valid.ValidationEmail(info.Email);
                if (validationEmail == false)
                {
                    return OprationResult.FalseValidation(Messages.Email);
                }
            }
            if (info.BimarID > 0)//this if is for that I have to check the privious thing or not
            {
                if (await repository.DuplicateNationalCodeAsync(info.NationalCode, info.BimarID))
                {
                    return OprationResult.Duplicate(Messages.NationalCode);
                }
                else if (await repository.DuplicateMobileAsync(info.MobileNumber, info.BimarID))
                {
                    return OprationResult.Duplicate(Messages.Mobile);
                }
                else if (checkEmail == false && await repository.DuplicateEmailAsync(info.Email, info.BimarID))
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
                if (await repository.DuplicateNationalCodeAsync(info.NationalCode))
                {
                    return OprationResult.Duplicate(Messages.NationalCode);
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
        public async Task<OprationResult> InsertAsync(BimarInfo info)
        {
            var checkData = await CheckDataAsync(info);
            if (checkData.IsSuccess)
            {
                User user = info.MapToUser();
                Bimar bimar=info.MapToBimar();
                bool check = await repository.InsertAsync(user,bimar);
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
        public async Task<OprationResult> UpdateAsync(BimarInfo info)
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
        public async Task<OprationResult<List<BimarDto>>> SelectAsync(string search)
        {
            var Bimars = await repository.SelectAsync(search);
            if (Bimars != null)
            {
                return OprationResult<List<BimarDto>>.Succes(Bimars);
            }
            else
            {
                return OprationResult<List<BimarDto>>.RunTimeError();
            }
        }
        public async Task<bool> ExistAsync(string Nc, string Mobile)
        {
            bool exist = await repository.ExistAsync(Nc,Mobile);
            return exist;
        }
    }
}
