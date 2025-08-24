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
        public OprationResult CheckData(DoctorInfo info)
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
                if (repository.DuplicateNezam(info.CodeNezamPezeshki, info.DoctorID))
                {
                    return OprationResult.Duplicate(Messages.Nezam);
                }
                else if (repository.DuplicateMobile(info.MobileNumber, info.DoctorID))
                {
                    return OprationResult.Duplicate(Messages.Mobile);
                }
                else if (string.IsNullOrEmpty(info.Email) == false && repository.DuplicateEmail(info.Email, info.DoctorID))
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
                if (repository.DuplicateNezam(info.CodeNezamPezeshki))
                {
                    return OprationResult.Duplicate(Messages.Nezam);
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
        public OprationResult Insert(DoctorInfo info)
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
        public OprationResult Update(DoctorInfo info)
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
        public OprationResult<List<DoctorDto>> Select(string search = "")
        {
            var doctors = repository.Select(search);
            if (doctors != null)
            {
                return OprationResult<List<DoctorDto>>.Succes(doctors);
            }
            else
            {
                return OprationResult<List<DoctorDto>>.RunTimeError();
            }
        }
    }
}
