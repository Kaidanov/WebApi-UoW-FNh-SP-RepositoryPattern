using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace UnitOfWork.WebApi.Helpers
{
    public class PlainTextMediaTypeFormatter : MediaTypeFormatter
    {
        public PlainTextMediaTypeFormatter()
        {
            SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/plain"));
        }

        public override bool CanReadType(Type type)
        {
            return type == typeof(string);
        }

        public override bool CanWriteType(Type type)
        {
            return false; // you can return true and override WriteToStreamAsync
        }

        public override Task<object> ReadFromStreamAsync(Type type,
            Stream readStream, HttpContent content, IFormatterLogger formatterLogger,
            CancellationToken cancellationToken)
        {
            var memoryStream = new MemoryStream();
            readStream.CopyTo(memoryStream);
            return Task.FromResult((object)Encoding.UTF8.GetString(memoryStream.ToArray()));
        }
    }
}