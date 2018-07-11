using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    class InvalidNameException:ApplicationException
    {
        public InvalidNameException(string message)
            : base(message)
        {

        }
    }


    class InvalidNrcException : ApplicationException
    {
        public InvalidNrcException(string message)
            : base(message)
        {

        }
    }

    class InvalidPhnoException : ApplicationException
    {
        public InvalidPhnoException(string message)
            : base(message)
        {

        }
    }

    class InvalidAddressException : ApplicationException
    {
        public InvalidAddressException(string message)
            : base(message)
        {

        }
    }

    class InvalidIdException : ApplicationException
    {
        public InvalidIdException(string message)
            : base(message)
        {

        }
    }

    class InvalidTypeException : ApplicationException
    {
        public InvalidTypeException(string message)
            : base(message)
        {

        }
    }
    class InvalidTspException : ApplicationException
    {
        public InvalidTspException(string message)
            : base(message)
        {

        }
    }

    class InvalidUnitException : ApplicationException
    {
        public InvalidUnitException(string message)
            : base(message)
        {

        }
    }
}
