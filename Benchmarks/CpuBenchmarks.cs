namespace Benchmarks;

[SimpleJob(RuntimeMoniker.Net70)]
[RPlotExporter, RankColumn]
public class CpuBenchmarks
{
    [Benchmark]
    public int CalculateSumOfSquares()
    {
        int sum = 0;
        for (int i = 0; i < 1000000; i++)
        {
            sum += i * i;
        }

        return sum;
    }

    [Benchmark]
    public int CalculateSumOfCubes()
    {
        int sum = 0;
        for (int i = 0; i < 1000000; i++)
        {
            sum += i * i * i;
        }

        return sum;
    }
}