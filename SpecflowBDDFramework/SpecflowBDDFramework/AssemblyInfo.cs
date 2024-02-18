using System.Runtime.InteropServices;
using NUnit.Framework;

[assembly: ComVisible(false)]
[assembly: Guid("148386b9-d58b-46fc-a955-a6e7781ac9e6")]

// Parallel Testing...
[assembly: Parallelizable(ParallelScope.Fixtures)]
[assembly: LevelOfParallelism(3)]