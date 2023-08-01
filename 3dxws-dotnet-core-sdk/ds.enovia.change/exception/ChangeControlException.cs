using ds.enovia.common.exception;
using System.Net.Http;

namespace ds.enovia.change
{
    public class ChangeControlException : ResponseException
    {
        public ChangeControlException(HttpResponseMessage _response) : base(_response)
        {
        }
    }
}
