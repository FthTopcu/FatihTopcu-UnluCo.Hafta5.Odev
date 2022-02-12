using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using UnluCo.Hafta2.Odev.Application.StydentOperations.Queries.GetStudents;

namespace UnluCo.Hafta2.Odev.Cache
{
    public static class MemoryCacheModel
    {
        private static IMemoryCache _memoryCache = new MemoryCache(new MemoryCacheOptions());

        public static void Add(string cacheKey,List<StudentsViewModel> value)
        {
            var cacheExpiryOptions = new MemoryCacheEntryOptions()
            {
                AbsoluteExpiration = DateTime.Now.AddMinutes(60),
                Priority = CacheItemPriority.High,
                SlidingExpiration = TimeSpan.FromSeconds(20),
            };
            _memoryCache.Set(cacheKey, value, cacheExpiryOptions);
        }
        public static List<StudentsViewModel> Get(string cacheKey)
        {
            List<StudentsViewModel> result = (List<StudentsViewModel>)_memoryCache.Get(cacheKey);
            return result;
        }
        public static void Remove(string cacheKey)
        {
            _memoryCache.Remove(cacheKey);
            
        }
    }
}
