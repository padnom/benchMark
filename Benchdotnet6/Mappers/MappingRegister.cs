using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

using Mapster;

namespace Benchdotnet6.Mappers
{
    public class MappingRegister : ICodeGenerationRegister
    {
        public void Register(CodeGenerationConfig config)
        {
            config.AdaptTo("[name]Dto", MapType.Map | MapType.MapToTarget | MapType.Projection)
                .ApplyDefaultRule();


            //config.AdaptFrom("[name]Add", MapType.Map)
            //    .ApplyDefaultRule()
            //    .IgnoreNoModifyProperties();

            //config.AdaptFrom("[name]Update", MapType.MapToTarget)
            //    .ApplyDefaultRule()
            //    .IgnoreAttributes(typeof(KeyAttribute))
            //    .IgnoreNoModifyProperties();

            //config.AdaptFrom("[name]Merge", MapType.MapToTarget)
            //    .ApplyDefaultRule()
            //    .IgnoreAttributes(typeof(KeyAttribute))
            //    .IgnoreNoModifyProperties()
            //    .IgnoreNullValues(true);

            config.GenerateMapper("[name]Mapper")
                .ForType<MyEntity>();
        }

    }

    static class RegisterExtensions
    {
        public static AdaptAttributeBuilder ApplyDefaultRule(this AdaptAttributeBuilder builder)
        {
            return builder
                .ForAllTypesInNamespace(Assembly.GetExecutingAssembly(), "Sample.CodeGen.Domains")
                .ExcludeTypes(type => type.IsEnum)
                .AlterType(type => type.IsEnum || Nullable.GetUnderlyingType(type)?.IsEnum == true, typeof(string))
                .ShallowCopyForSameType(true);

        }

        //public static AdaptAttributeBuilder IgnoreNoModifyProperties(this AdaptAttributeBuilder builder)
        //{
        //    return builder
        //        .ForType<Enrollment>(cfg => cfg.Ignore(it => it.Student));
        //}
    }
}
