using Newtonsoft.Json.Converters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;

namespace myProject.pubClsMod
{
    public static class Serializer
    {
        /// <summary>
        /// object to json string
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static string ToJson(this object entity)
        {
            var converter = new IsoDateTimeConverter();
            converter.DateTimeFormat = "yyyy-MM-dd HH:mm:ss";
            var serializer = new JsonSerializer();
            serializer.Converters.Add(converter);

            var sb = new StringBuilder();
            serializer.Serialize(new JsonTextWriter(new StringWriter(sb)), entity);
            return sb.ToString();
        }
    }
}