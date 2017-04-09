using System;
using System.Collections.Generic;
using System.Net.Http;

namespace Gateway.Handlers
{
    static class HttpMessageExtensions
    {
        // NOTE: Adapted from http://stackoverflow.com/questions/21467018/how-to-forward-an-httprequestmessage-to-another-server
        internal static HttpRequestMessage Clone(this HttpRequestMessage req, Uri newUri)
        {
            HttpRequestMessage clone = new HttpRequestMessage(req.Method, newUri);

            if (req.Method != HttpMethod.Get)
            {
                clone.Content = req.Content;
            }
            clone.Version = req.Version;

            foreach (KeyValuePair<string, object> prop in req.Properties)
            {
                clone.Properties.Add(prop);
            }

            foreach (KeyValuePair<string, IEnumerable<string>> header in req.Headers)
            {
                clone.Headers.TryAddWithoutValidation(header.Key, header.Value);
            }

            return clone;
        }
    }
}