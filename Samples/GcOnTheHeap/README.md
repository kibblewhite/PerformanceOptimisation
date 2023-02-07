


|                                           Method |       Mean |    Error |   StdDev | Rank |        Gen0 | Allocated |
|------------------------------------------------- |-----------:|---------:|---------:|-----:|------------:|----------:|
|                      Create100MillionHeapObjects |   263.7 ms |  5.27 ms | 11.56 ms |    1 | 573000.0000 |   2.24 GB |
|     Create100MillionHeapObjectsWithGcInBatchMode |   268.7 ms |  5.35 ms | 13.61 ms |    1 | 573500.0000 |   2.24 GB |
|                  Create100MillionHeapPoolObjects | 1,367.3 ms | 27.27 ms | 53.84 ms |    2 |           - |      2 GB |
| Create100MillionHeapPoolObjectsWithGcInBatchMode | 1,407.0 ms | 27.70 ms | 58.43 ms |    3 |           - |      2 GB |
