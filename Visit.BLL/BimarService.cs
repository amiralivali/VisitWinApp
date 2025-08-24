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

        public OprationResult CheckData(BimarInfo info)
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
                if (repository.DuplicateNationalCode(info.NationalCode, info.BimarID))
                {
                    return OprationResult.Duplicate(Messages.NationalCode);
                }
                else if (repository.DuplicateMobile(info.MobileNumber, info.BimarID))
                {
                    return OprationResult.Duplicate(Messages.Mobile);
                }
                else if (string.IsNullOrEmpty(info.Email) == false && repository.DuplicateEmail(info.Email, info.BimarID))
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
                if (repository.DuplicateNationalCode(info.NationalCode))
                {
                    return OprationResult.Duplicate(Messages.NationalCode);
                }
                else if (repository.DuplicateMobile(info.MobileNumber))
                {
                    return OprationResult.Duplicate(Messages.Mobile);
                }
                else if (string.IsNullOrEmpty(info.Email) == false && repository.DuplicateEmail(info.Email))
                {
                    return OprationResult.Duplicate(Messages.Email);
                }
                else
                {
                    return OprationResult.Success(Messages.Insert);
                }
            }
        }
        public OprationResult Insert(BimarInfo info)
        {
            var checkData = CheckData(info);
            if (checkData.IsSuccess)
            {
                bool check = repository.Insert(info);
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
        public OprationResult Update(BimarInfo info)
        {
            var checkData = CheckData(info);
            if (checkData.IsSuccess)
            {
                bool check = repository.Update(info);
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
        public OprationResult Delete(int id)
        {
            bool check = repository.Delete(id);
            if (check)
            {
                return OprationResult.Success(Messages.Delete);
            }
            else
            {
                return OprationResult.RunTimeError();
            }
        }
        public OprationResult<List<BimarDto>> Select(string search)
        {
            var Bimars = repository.Select(search);
            if (Bimars != null)
            {
                return OprationResult<List<BimarDto>>.Succes(Bimars);
            }
            else
            {
                return OprationResult<List<BimarDto>>.RunTimeError();
            }
        }
    }
}
