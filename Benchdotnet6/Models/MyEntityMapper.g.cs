using System;
using Benchdotnet6.Mappers;

namespace Benchdotnet6.Mappers
{
    public static partial class MyEntityMapper
    {
        public static MyEntityDto AdaptToDto(this MyEntity p1)
        {
            return p1 == null ? null : new MyEntityDto()
            {
                CurrencyCode = p1.CurrencyCode,
                CustomerLanguage = p1.CustomerLanguage,
                Id = p1.Id,
                InterfaceVersion = p1.InterfaceVersion,
                KeyVersion = p1.KeyVersion,
                OrderChannel = p1.OrderChannel,
                PaymentMeanBrandList = funcMain1(p1.PaymentMeanBrandList),
                PaymentProviderUrl = p1.PaymentProviderUrl,
                ProviderName = p1.ProviderName,
                SealAlgorithm = p1.SealAlgorithm,
                Secret = p1.Secret
            };
        }
        public static MyEntityDto AdaptTo(this MyEntity p3, MyEntityDto p4)
        {
            if (p3 == null)
            {
                return null;
            }
            MyEntityDto result = p4 ?? new MyEntityDto();
            
            result.CurrencyCode = p3.CurrencyCode;
            result.CustomerLanguage = p3.CustomerLanguage;
            result.Id = p3.Id;
            result.InterfaceVersion = p3.InterfaceVersion;
            result.KeyVersion = p3.KeyVersion;
            result.OrderChannel = p3.OrderChannel;
            result.PaymentMeanBrandList = funcMain2(p3.PaymentMeanBrandList, result.PaymentMeanBrandList);
            result.PaymentProviderUrl = p3.PaymentProviderUrl;
            result.ProviderName = p3.ProviderName;
            result.SealAlgorithm = p3.SealAlgorithm;
            result.Secret = p3.Secret;
            return result;
            
        }
        
        private static string[] funcMain1(string[] p2)
        {
            if (p2 == null)
            {
                return null;
            }
            string[] result = new string[p2.Length];
            Array.Copy(p2, 0, result, 0, p2.Length);
            return result;
            
        }
        
        private static string[] funcMain2(string[] p5, string[] p6)
        {
            if (p5 == null)
            {
                return null;
            }
            string[] result = new string[p5.Length];
            Array.Copy(p5, 0, result, 0, p5.Length);
            return result;
            
        }
    }
}