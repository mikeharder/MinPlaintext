// Copied from https://raw.githubusercontent.com/aspnet/benchmarks/dev/src/Benchmarks/Data/EfDb.cs

// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace Benchmarks.Data
{
    public class EfDb : IDb
    {
        private readonly ApplicationDbContext _dbContext;

        public EfDb(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

#if NETCOREAPP2_0 || NETCOREAPP2_1
        private static readonly Func<ApplicationDbContext, AsyncEnumerable<Fortune>> _fortunesQuery
            = EF.CompileAsyncQuery((ApplicationDbContext context) => context.Fortune);

        public async Task<IEnumerable<Fortune>> LoadFortunesRows()
        {
            var result = await _fortunesQuery(_dbContext).ToListAsync();

            result.Add(new Fortune { Message = "Additional fortune added at request time." });
            result.Sort();

            return result;
        }
#elif NETCOREAPP1_1
        public Task<IEnumerable<Fortune>> LoadFortunesRows() => throw new NotImplementedException();
#else
#error Unknown target framework
#endif
    }
}