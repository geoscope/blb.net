using System.Collections.Generic;

namespace BLB.Api.Net.Interfaces
{
    public interface IGenericHydrator<TIn, TOut>
    {
        TOut Hydrate(TIn obj);

        ICollection<TOut> HydrateList(ICollection<TIn> obj);
    }
}
