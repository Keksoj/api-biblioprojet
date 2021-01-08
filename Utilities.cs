using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BiblioApi.Utilities
{
    /// <summary>
    /// Some usefull methods.
    /// </summary>
    public static class Utils
    {
        /// <summary>
        /// Same as FirstOrDefault() but async ;)
        ///
        /// I don't know if is the best way to do that
        /// but it's work...
        /// 
        /// <code>
        ///     await FirstOrDefaultAsync(model, m => m.name == x.name);
        /// </code>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="model">The database collectiom to operate on</param>
        /// <param name="predicate">The comparaison method ?</param>
        public static Task<T> FirstOrDefaultAsync<T>(DbSet<T> model, Func<T, bool> predicate) where T : class 
            => Task.Run(() => model.FirstOrDefault(predicate));
    }

    public class CustomJsonResponse : JsonResult
    {
        private struct Message
        {
            public string Description { get; set; }
        }

        public CustomJsonResponse(string message, HttpStatusCode status) : base(new Message { Description = message })
        {
            StatusCode = (int)status;
        }
    }
}
