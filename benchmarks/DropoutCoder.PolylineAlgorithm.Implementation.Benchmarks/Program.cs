namespace DropoutCoder.PolylineAlgorithm.Implementation.Benchmarks
{
    using BenchmarkDotNet.Running;

    internal class Program
    {
        static void Main(string[] args)
        {
            BenchmarkRunner
                .Run<EncodePerformanceBenchmark>();
            BenchmarkRunner
                .Run<DecodePerformanceBenchmark>();
        }
    }
}
