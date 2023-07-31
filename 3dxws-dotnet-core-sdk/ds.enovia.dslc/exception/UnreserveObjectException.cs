using ds.enovia.common.exception;
using System.Net.Http;

namespace ds.enovia.dslc.exception
{
    public class UnreserveObjectException : ResponseException
    {
        public UnreserveObjectException(HttpResponseMessage _response) : base(_response)
        {
        }
    }
}
