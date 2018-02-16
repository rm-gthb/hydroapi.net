# HydroApi.Net


C# Wrapper for Hydro Blockchain Authentication API.

Easy to use!
## Features

 - Compitable with **.NET Standard 1.6**

## Getting Started

    HydroService hydroService = new HydroService("API_KEY", "API_USERNAME");

### Step 1: Add address to whitelist

    string hydroAddressId = await hydroService.RegisterAddress("ACCESSOR_ETH_PUBLIC_ADDRESS");

### Step 2: Get Raindrop details

    RaindropDetails raindropDetails = await hydroService.RequestRaindrop("ACCESSOR_HYDRO_ADDRESS_ID");

### Step 3: Check on exist valid Raindrop transaction

    bool hasValidTransaction = await hydroService.CheckValidRaindrop("ACCESSOR_HYDRO_ADDRESS_ID");

    if (hasValidTransaction)
    {
        // Continue next step of authentication
    }
    else
    {

    }
   
 ## Information
  Check API [FAQ](https://github.com/hydrogen-dev/hydro-docs) for more details...
