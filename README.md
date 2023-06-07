# LensDotNet

LensDotNet is a .NET Standard library that provides an easy and efficient way to interact with the Lens API. This library enables you to seamlessly utilize Lens API in various platforms, such as desktop applications, mobile apps using Xamarin, and games using Unity.

## Table of Contents

- [LensDotNet](#lensdotnet)
  - [Table of Contents](#table-of-contents)
  - [Installation](#installation)
    - [Package Manager Console](#package-manager-console)
    - [NuGet Package Manager in Visual Studio](#nuget-package-manager-in-visual-studio)
  - [Usage](#usage)
  - [Contributing](#contributing)
  - [Roadmap](#roadmap)
  - [Acknowledgements](#acknowledgements)
  - [License](#license)

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

Here's a simple example of how to use LensDotNet:

```csharp
using LensDotNet;

// Create a LensClient instance
var lensClient = new LensClient("your_api_key");

// Call the appropriate API method
var result = await lensClient.SomeApiMethodAsync(someParameters);

// Handle the result
Console.WriteLine("Result: " + result);
```

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
- [ ] Advanced API methods
- [ ] Xamarin support
- [ ] Comprehensive documentation and examples

## Acknowledgements

A special thanks to the following individuals and organizations for their contributions, support, and encouragement in the development of LensDotNet:

- [Stanislav Silin](https://github.com/byme8) for his amazing work on [ZeroQL](https://github.com/byme8/ZeroQL), the underlying graphQL client used. Also for pushing the .netstandard support so fast as well as figuring out the use in Unity. 
- [Grabriel Weyer](https://github.com/gabrielweyer) from whom I copied and pasted his [JWT decoder implementation](https://github.com/gabrielweyer/dotnet-decode-jwt/blob/f304f17b910e6233d1053a98bda3d8ada5e10d3e/src/dotnet-decode-jwt/JwtClaimsDecoder.cs), which allowed me to reduce the number of dependencies
- A todos los que me estan mirando 👀

## License

This project is licensed under the MIT License. Please see the [LICENSE](LICENSE) file for more details.