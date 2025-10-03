using Microsoft.AspNetCore.Mvc;
using Visit.BLL;
using Visit.Shared;

namespace Visit.API.Controllers
{
    public class DoctorController : BaseController
    {
        DoctorService doctorService;
        public DoctorController()
        {
            doctorService = new DoctorService();
        }
        [HttpPost()]
        public async Task<OprationResult> InsertAsync(DoctorInfo info)
        {
            var result = await doctorService.InsertAsync(info);
            return result;
        }
        [HttpGet()]
        public async Task<OprationResult> DeleteAsync(int id)
        {
            var result = await doctorService.DeleteAsync(id);
            return result;
        }
        [HttpPost()]
        public async Task<OprationResult> UpdateAsync(DoctorInfo info)
        {
            var result = await doctorService.UpdateAsync(info);
            return result;
        }
        [HttpGet()]
        public async Task<OprationResult<List<DoctorDto>>> SelectAsync(string search)
        {
            var result = await doctorService.SelectAsync(search);
            return result;
        }
        [HttpGet()]
        public async Task<bool> ExistDoctorAsync(string nezam,string mobile)
        {
            var result = await doctorService.ExistAsync(nezam,mobile);
            return result;
        }
    }
}
