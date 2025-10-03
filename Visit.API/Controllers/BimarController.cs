using Kavenegar;
using Microsoft.AspNetCore.Mvc;
using Visit.BLL;
using Visit.Shared;

namespace Visit.API.Controllers
{
    public class BimarController : BaseController
    {
        BimarService bimarService;
        public BimarController()
        {
            bimarService = new BimarService();
        }
        [HttpPost()]
        public async Task<OprationResult> InsertAsync(BimarInfo info)
        { 
            var result = await bimarService.InsertAsync(info);
            return result;
        }
        [HttpGet()]
        public async Task<OprationResult> DeleteAsync(int id)
        {
            var result = await bimarService.DeleteAsync(id);
            return result;
        }
        [HttpPost()]
        public async Task<OprationResult> UpdateAsync(BimarInfo info)
        {
            var result = await bimarService.UpdateAsync(info);
            return result;
        }
        [HttpGet()]
        public async Task<OprationResult<List<BimarDto>>> SelectAsync(string search)
        {
            var result = await bimarService.SelectAsync(search);
            return result;
        }
        [HttpGet()]
        public async Task<bool> ExistBimarAsync(string nc, string mobile)
        {
            var result = await bimarService.ExistAsync(nc, mobile);
            return result;
        }
        ////        [HttpGet]
        //public string SendSms(string smsText)
        //{
        //    var senderClient = "2000660110";
        //    var receptor = "09361842050";//به دلیل کامل نبودن احراز هویت نمیتوان به شماره های دیگر ارسال شود
        //    var message = smsText;
        //    var api = new KavenegarApi("6A53643770437645526E514F4352377776424B6743354C526C7A6438646F6435534B33366D6E57794847513D");
        //    var result = api.Send(senderClient, receptor, message);
        //    return result.Message;
        //}
    }
}
