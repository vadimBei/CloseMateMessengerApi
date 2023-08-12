using Microsoft.AspNetCore.Http;
using WebClient.Interfaces.Enums;
using WebClient.Interfaces.Options;

namespace WebClient.Interfaces.Interfaces
{
    public interface IWebClientConfiguration
    {
        public WebResource WebResource { get; set; }

        public Segment Segment { get; set; }

        public string WebResourcePath { get; set; }

        public AuthenticationType AuthenticationType { get; set; }

        string RequestUri { get; set; }

        public string QueryString { get; set; }

        public HttpContent HttpContent { get; set; }

        public HttpContext HttpContext { get; set; }
    }
}
