// This file is used by Code Analysis to maintain SuppressMessage
// attributes that are applied to this project.
// Project-level suppressions either have no target or are given
// a specific target and scoped to a namespace, type, member, etc.

using System.Diagnostics.CodeAnalysis;

[assembly: SuppressMessage("Performance", "CA1822:Mark members as static", Justification = "BenchmarkDotNet will not run with static", Scope = "member", Target = "~M:Benchmarks.HeapVsStackBenchmarks.InstantiateHeapOfStructs~Samples.HeapVsStack.HeapOfStructs")]
[assembly: SuppressMessage("Performance", "CA1822:Mark members as static", Justification = "<Pending>", Scope = "member", Target = "~M:Benchmarks.GcOnTheHeapBenchmarks.Create10MillionHeapObjects")]
[assembly: SuppressMessage("Performance", "CA1822:Mark members as static", Justification = "<Pending>", Scope = "member", Target = "~M:Benchmarks.GcOnTheHeapBenchmarks.Create10MillionHeapObjectsWithGcInBatchMode")]
[assembly: SuppressMessage("Performance", "CA1822:Mark members as static", Justification = "<Pending>", Scope = "member", Target = "~M:Benchmarks.GcOnTheHeapBenchmarks.Create10MillionHeapPoolObjects")]
[assembly: SuppressMessage("Performance", "CA1822:Mark members as static", Justification = "<Pending>", Scope = "member", Target = "~M:Benchmarks.GcOnTheHeapBenchmarks.Create10MillionHeapPoolObjectsWithGcInBatchMode")]
[assembly: SuppressMessage("Performance", "CA1822:Mark members as static", Justification = "<Pending>", Scope = "member", Target = "~M:Benchmarks.CpuBenchmarks.CalculateSumOfSquares~System.Int32")]
[assembly: SuppressMessage("Performance", "CA1822:Mark members as static", Justification = "<Pending>", Scope = "member", Target = "~M:Benchmarks.CpuBenchmarks.CalculateSumOfCubes~System.Int32")]
[assembly: SuppressMessage("Performance", "CA1822:Mark members as static", Justification = "<Pending>", Scope = "member", Target = "~M:Benchmarks.HeapVsStackBenchmarks.InstantiateStackOfStructs~Samples.HeapVsStack.StackOfStructs")]
