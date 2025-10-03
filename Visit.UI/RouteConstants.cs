using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visit.UI
{
    internal class RouteConstants
    {
        public const string BaseUrl = "https://localhost:7054";
        public const string InsertBimar = "Bimar/Insert";
        public const string ExistBimar = "Bimar/Exist?nc={0}&mobile={1}";
        public const string ExistDoctor = "Doctor/Exist?nezam={0}&mobile={1}";
        public const string SendSms = "Base/SendSms?smsText={0}";
    }
}
