// Copied from https://raw.githubusercontent.com/aspnet/benchmarks/dev/src/Benchmarks/Data/IDb.cs

// Copyright (c) .NET Foundation. All rights reserved. 
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information. 

using System.Collections.Generic;
using System.Threading.Tasks;

namespace Benchmarks.Data
{
    public interface IDb
    {
        Task<IEnumerable<Fortune>> LoadFortunesRows();
    }
}