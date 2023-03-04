using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Utilities
{
    public interface IDataResult<out T>:IResult
    {
        T Data { get; }
    }
}
