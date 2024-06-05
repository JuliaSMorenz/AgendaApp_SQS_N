using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaApp.Domain.Exceptions
{
    /// <summary>
    /// Classe de captura de exceções para os serviços de domínio
    /// </summary>
    public class DomainException : Exception
    {
        //método construtor
        public DomainException(string errorMessage)
            : base(errorMessage)
        {
            
        }

        public static void When(bool hasError, string errorMessage)
        {
            if (hasError)
                throw new DomainException(errorMessage);
        }
    }
}
