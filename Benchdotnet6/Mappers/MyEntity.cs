using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Mapster;

namespace Benchdotnet6.Mappers
{
    [AdaptTo(name: "[name]Dto"), GenerateMapper]

    public class MyEntity
    {
        public string CurrencyCode { get; set; }
        public string CustomerLanguage { get; set; }
        public string Id { get; set; }
        public string InterfaceVersion { get; set; }
        public string KeyVersion { get; set; }
        public string OrderChannel { get; set; }
        public string[] PaymentMeanBrandList { get; set; }
        public string PaymentProviderUrl { get; set; }
        public string ProviderName { get; set; }
        public string SealAlgorithm { get; set; }
        public string Secret { get; set; }
    }
}
