using System.Collections.Generic;

namespace BLB.Api.Net.Interfaces
{
    public interface IValidator<in T>
    {
        IEnumerable<string> Validate(T model);
    }
}
