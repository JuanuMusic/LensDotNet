# LensDotNet
![LensDotNetLogo](assets/lensdotnetlogo.png?raw=true)

LensDotNet is a .NET library that provides an easy and efficient way to interact with the Lens API. This library enables you to seamlessly utilize Lens API in various platforms, such as desktop applications, mobile apps using ~~Xamarin~~ MAUI, and games using Unity.

## Table of Contents

- [LensDotNet](#lensdotnet)
  - [Table of Contents](#table-of-contents)
  - [Supported Frameworks](#supported-frameworks)
  - [Installation](#installation)
    - [Package Manager Console](#package-manager-console)
    - [NuGet Package Manager in Visual Studio](#nuget-package-manager-in-visual-studio)
  - [Usage](#usage)
    - [Basic Setup](#basic-setup)
    - [Authenticating](#authenticating)
  - [Contributing](#contributing)
  - [Roadmap](#roadmap)
  - [Acknowledgements](#acknowledgements)
  - [License](#license)

## Supported Frameworks
- .net Standard 2.1
- .net 6.0
- .net 7.0

## Installation

To install LensDotNet, you can use NuGet Package Manager. You can either use the Package Manager Console or the NuGet Package Manager in Visual Studio.

### Package Manager Console

Run the following command in the Package Manager Console:

```
Install-Package LensDotNet
```

### NuGet Package Manager in Visual Studio

1. Right-click on your project in the Solution Explorer.
2. Select 'Manage NuGet Packages...'
3. Search for 'LensDotNet' and install the package.

## Usage

### Basic Setup
Here's a very basic example of how to use LensDotNet:

```csharp
using LensDotNet;

// Create a LensClient instance
var config = new LensConfig("https://api-mumbai.lens.dev");
var client = new LensClient(config);

// Call ExploreProfiles and print results.
var profiles = await client.Explore.ExploreProfiles();
Console.WriteLine($"Found {profiles.Items.Length} profiles");
foreach (var profile in profiles.Items)
    Console.WriteLine($"name: {profile.Name} - owner: {profile.OwnedBy} - id: {profile.Id}");

```

### Authenticating
Most mutations (write calls) to the API, require that the user is authenticated.
Authentication is a set of steps that requires the user to sign a message with the wallet that owns the profile.
To do this, LensDotNet decouples the Signing process letting the implementator (you) chose the way to do it.

This is how it works:

```csharp
using LensDotNet;

// Create a LensClient instance
var config = new LensConfig("https://api-mumbai.lens.dev");
var client = new LensClient(config);

// Generate a challenge passing the user address
var challenge = await client.Authentication.GenerateChallenge(account.Address);

// Sign the challenge string with whatever method you want.
var signature = yourSignerImplementation.Sign(challenge.Text, account);

// Authenticate the client with the signed message and the address.
await client.Authentication.Authenticate(account.Address, signature);

// Check if user is authenticated
if(await client.Authentication.IsAuthenticated())
  Console.WriteLine("Authenticated!");
else
  Console.WriteLine("Not authenticated!");

```

For more examples, take a look at the [Examples folder](https://github.com/JuanuMusic/LensDotNet/tree/main/src/Examples) or explore the [Tests](https://github.com/JuanuMusic/LensDotNet/tree/main/src/LensDotNet.Client.Tests).

Also, a guide for using with Unity is in progress. [Look Here](https://github.com/JuanuMusic/LensDotNet/tree/main/src/Examples/LensDotNet.Examples.Unity/README.md).

## Contributing

We welcome contributions to improve and expand the functionality of LensDotNet. Please follow these guidelines to contribute:

1. Fork this repository to your own account.
2. Create a branch with a descriptive name related to the changes you're making.
3. Make your changes and commit them to your branch.
4. Open a pull request from your fork to the main repository, describing the changes made and the issue (if applicable) that your changes resolve.

All contributions should respect the coding style and conventions used throughout the project. Also, make sure to test your changes before submitting a pull request.

## Roadmap

Here's the tentative roadmap for upcoming features. Feel free to suggest new features or improvements!

- [x] Basic API interaction
  - [x] Unit tests
- [x] Unity support
  - [ ] Improved Unity examples
- [ ] Advanced API methods
- [x] ~~Xamarin~~ MAUI support
  - [ ] Improved MAUI examples
- [ ] Clients
  - [x] Lens Client
  - [x] Profile Client
  - [x] Authentication Client
  - [x] Publication Client
    - [x] Create Publication
  - [ ] Transaction Client
  - [ ] ... TODO: add more clients ...
- [ ] Comprehensive documentation
  - [ ] Unity Implementation
- [x] Examples
  - [x] Simple Console App
  - [x] Simple MAUI App
  - [x] Simple Unity
## Acknowledgements

- [Stanislav Silin](https://github.com/byme8) for his amazing work on [ZeroQL](https://github.com/byme8/ZeroQL), the underlying graphQL client used. Also for pushing the .netstandard support so fast as well as figuring out the use in Unity. 
- [Grabriel Weyer](https://github.com/gabrielweyer) from whom I copied and pasted his [JWT decoder implementation](https://github.com/gabrielweyer/dotnet-decode-jwt/blob/f304f17b910e6233d1053a98bda3d8ada5e10d3e/src/dotnet-decode-jwt/JwtClaimsDecoder.cs), which allowed me to reduce the number of dependencies
- [Juan Blanco](https://github.com/juanfranblanco), the genius behind [Nethereum](https://nethereum.com/), which has been the most helpful for building tests.  
- A toda mi familia y a todos los que me estan viendo 👀

## License

This project is licensed under the MIT License. Please see the [LICENSE](LICENSE) file for more details.
