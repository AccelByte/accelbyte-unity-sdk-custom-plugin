# AccelByte Unity SDK Customization
AccelByte Customization Unity SDK is a custom extension plugin of AccelByte Unity SDK to bridge between your game and AccelByte Customization services for Unity Engine.

## Dependencies
- [AccelByte Unity SDK](https://github.com/AccelByte/accelbyte-unity-sdk-plugin) ([Minimum version: 15.16.2](https://docs.accelbyte.io/product-updates/3.46.0.html))

## Supported Unity
The current supported Unity versions are Unity 2020 - 2022.

## Getting Started
Here's how to get it up and running quickly.

### Setup

1. Download the whole repository.
2. Go to **Window > Package Manager > + > Add package from disk…** in your project
3. Open the **package.json** inside the custom SDK plugin folder and wait until the adding package process is done.

> ⚠️ Make sure you have setup the dependencies before add AccelByte Custom SDK as a package

### Plugin API Call

1. Add this reference inside your project
```csharp
using AccelByte.Api;
using AccelByte.Models;
using AccelByte.Core;
```

2. Call the API function
```csharp
ApiClient apiClient = MultiRegistry.GetApiClient();
Custom custom = apiClient.GetApi<Custom,CustomApi>();
custom.Function();
```