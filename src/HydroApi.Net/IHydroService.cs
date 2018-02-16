using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HydroApi.Net
{
    public interface IHydroService
    {
        string ApiKey { get; }

        string ApiUsername { get; }

        Task<string> RegisterAddress(string address);

        Task<RaindropDetails> RequestRaindrop(string hydroAddressId);

        Task<bool> CheckValidRaindrop(string hydroAddressId);
    }
}
