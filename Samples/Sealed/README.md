```
BenchmarkDotNet=v0.13.4, OS=Windows 11 (10.0.22621.1194)
Intel Core i7-1065G7 CPU 1.30GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK=7.0.102
  [Host]     : .NET 7.0.2 (7.0.222.60605), X64 RyuJIT AVX2
  DefaultJob : .NET 7.0.2 (7.0.222.60605), X64 RyuJIT AVX2
```

|     Method |      Mean |     Error |    StdDev |    Median | Rank | Allocated |
|----------- |----------:|----------:|----------:|----------:|-----:|----------:|
| SealedVoid | 0.0032 ns | 0.0118 ns | 0.0104 ns | 0.0000 ns |    1 |         - |
|  SealedInt | 0.4947 ns | 0.0321 ns | 0.0300 ns | 0.4902 ns |    2 |         - |
|   OpenVoid | 0.5524 ns | 0.0377 ns | 0.0353 ns | 0.5486 ns |    3 |         - |
|    OpenInt | 1.5017 ns | 0.0516 ns | 0.0457 ns | 1.5038 ns |    4 |         - |


|        Method |      Mean |     Error |    StdDev | Rank | Allocated |
|-------------- |----------:|----------:|----------:|-----:|----------:|
| IsCheckSealed | 0.0000 ns | 0.0000 ns | 0.0000 ns |    1 |         - |
|   IsCheckOpen | 2.3393 ns | 0.0797 ns | 0.0746 ns |    2 |         - |


|      Method |     Mean |     Error |    StdDev | Rank | Allocated |
|------------ |---------:|----------:|----------:|-----:|----------:|
| StoreSealed | 2.790 ns | 0.0844 ns | 0.0828 ns |    1 |         - |
|   StoreOpen | 4.007 ns | 0.1123 ns | 0.1420 ns |    2 |         - |

|     Method |      Mean |     Error |    StdDev | Rank | Allocated |
|----------- |----------:|----------:|----------:|-----:|----------:|
| SpanSelaed | 0.3242 ns | 0.0291 ns | 0.0272 ns |    1 |         - |
|   SpanOpen | 0.4878 ns | 0.0402 ns | 0.0899 ns |    2 |         - |

