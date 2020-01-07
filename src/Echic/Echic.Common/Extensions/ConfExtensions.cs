using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Echic.Common
{
    public static class ConfExtensions
    {
        public static TEntity GetEntity<TEntity>(this IConfiguration conf, string key) where TEntity:new()
        {
            TEntity obj = new TEntity();

            var section = conf.GetSection(key);
            section.Bind(obj);

            return obj;
        }
    }
}
