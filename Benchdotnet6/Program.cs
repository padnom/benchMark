// See https://aka.ms/new-console-template for more information

using Benchdotnet6.Exceptions;
using Benchdotnet6.Mappers;

using BenchmarkDotNet.Running;

BenchmarkRunner.Run<BenchException>();
BenchmarkRunner.Run<MappingBenchMarks>();
