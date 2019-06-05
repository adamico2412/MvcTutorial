using System.Net;

namespace MvcTutorial.ViewModels
{
    public class ReturnData
    {
        public HttpStatusCode HttpStatusCode { get; set; }
        public string Content { get; set; }
        public string ReasonPhrase { get; set; }

        public ReturnData(HttpStatusCode httpStatusCode,
                          string content,
                          string reasonPhrase)
        {
            HttpStatusCode = httpStatusCode;
            Content = content;
            ReasonPhrase = reasonPhrase;
        }
    }
}