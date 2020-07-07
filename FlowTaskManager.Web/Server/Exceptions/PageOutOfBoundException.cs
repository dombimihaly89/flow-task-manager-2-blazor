using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlowTaskManager.Web.Server.Exceptions
{
    public class PageOutOfBoundException : Exception
    {
        public PageOutOfBoundException(int lastPage) : base($"Page number has to be between 1 and {lastPage}")
        {
            
        }
    }
}
