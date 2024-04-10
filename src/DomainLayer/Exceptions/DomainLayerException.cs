using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Exceptions
{
    public  class DomainLayerException : Exception
    {
        public DomainLayerException() { }
        public DomainLayerException(string message):base(message) { }
        public DomainLayerException(string message, Exception innerException):base(message, innerException) { }
    }
}
