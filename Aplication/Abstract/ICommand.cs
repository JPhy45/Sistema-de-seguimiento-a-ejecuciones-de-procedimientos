using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Aplication.Abstract
{
    public interface ICommand:IRequest
    {

    }
    public interface ICommand<TResponse>:IRequest<TResponse>
    {

    }
}
