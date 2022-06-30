using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AutoFixture;

using AutoMapper;

using Mapster;

namespace Benchdotnet6.Mappers
{
    public class MappingSamples
    {
        private static MyEntity myEntity;
        private static readonly IMapper autoMapper = new Mapper(new MapperConfiguration(ex=>ex.AddProfile(new AutoMapperProfile())));
        private static TypeAdapterConfig typeAdapterConfig = GetTypeAdapterConfig();
        private static readonly MapsterMapper.IMapper masterMapper = new MapsterMapper.Mapper(typeAdapterConfig);

        private static TypeAdapterConfig GetTypeAdapterConfig()
        {
            var s = new MappingRegister();
            var config = new TypeAdapterConfig();
            return config;
        }

        public static MyEntity GenerateMyEntitty()
        {
            if (myEntity == null)
            {
                return new MyEntity
                {
                    CurrencyCode = "currencyCode",
                    Id = "Id",
                    CustomerLanguage = "CustomerLanguage",
                    InterfaceVersion = "currencyCode",
                    KeyVersion = "KeyVersion",
                    OrderChannel = "OrderChannel",
                    PaymentMeanBrandList = new string[] { "toto,tata" },
                    PaymentProviderUrl = "PaymentProviderUrl",
                    ProviderName = "ProviderName",
                    SealAlgorithm = "SealAlgorithm",
                    Secret = "Secret"
                };
            }

            return myEntity;
        }

        public static MyEntityDto MasterCodeGen()
        {
            var entity = GenerateMyEntitty();
            return entity.AdaptToDto();
        }

        public static MyDto ManualMap()
        {
            var myEntity = GenerateMyEntitty();
            return new MyDto
            {
                CurrencyCode = myEntity.CurrencyCode,
                CustomerLanguage = myEntity.CustomerLanguage,
                InterfaceVersion = myEntity.InterfaceVersion,
                KeyVersion = myEntity.KeyVersion,
                OrderChannel = myEntity.OrderChannel,
                PaymentMeanBrandList = myEntity.PaymentMeanBrandList,
                PaymentProviderUrl = myEntity.PaymentProviderUrl,
                ProviderName = myEntity.ProviderName,
                SealAlgorithm = myEntity.SealAlgorithm,
                Secret = myEntity.Secret
            };
        }

        public static MyDto MasterWithoutConfig()
        {
            return GenerateMyEntitty().Adapt<MyDto>();
        }

        public static MyDto MasterAdaptToType()
        {
            return masterMapper.From(GenerateMyEntitty()).Adapt<MyDto>();
        }
        public static MyDto MasterWithConfig()
        {
            return GenerateMyEntitty().Adapt<MyDto>();
        }

        public static MyDto AutoMapper()
        {
            return autoMapper.Map<MyDto>(GenerateMyEntitty());
        }
    }

    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<MyEntity, MyDto>().ReverseMap();
        }
    }


}
