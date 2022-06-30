using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AutoFixture;

using AutoMapper;

using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;

namespace Benchdotnet6.Mappers
{
    [MemoryDiagnoser ,Orderer(summaryOrderPolicy: SummaryOrderPolicy.FastestToSlowest)]
    public class MappingBenchMarks
    {

        [Benchmark] public MyDto ManualMap() => MappingSamples.ManualMap();
        [Benchmark] public MyDto AutoMapper() => MappingSamples.AutoMapper();
        [Benchmark] public MyDto MasterWithoutConfig() => MappingSamples.MasterWithoutConfig();
        [Benchmark] public MyDto MapsterWithConfig() => MappingSamples.MasterWithConfig();
        [Benchmark] public MyDto MapsterAdaptToType() => MappingSamples.MasterAdaptToType();
        [Benchmark] public MyEntityDto MapsterCodeGen() => MappingSamples.MasterCodeGen();
    }

    
}
