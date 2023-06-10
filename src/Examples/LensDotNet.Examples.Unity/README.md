# Use LensDotNet in Unity
LensDotNet is built to support the .NET Standard framework, which makes it compatible with Unity.

A couple of extra steps have to be taken in order to use it in your project.
Also, depending on your project setup your requirements might differ.

## Initial Setup:

First, you need to get a compiled version of LensDotNet, and its dependencies. This is easy to do and figure out if you are used to working with .NET projects in general. However, if you want to take the easy route, you can download each required file from the trusted repository (NuGet) (the same where the library is published).
You need to download each of the following libraries by clicking on `Download package` on the right bar.
- (https://www.nuget.org/packages/LensDotNet)
 the `LensDotNet.dll` fetched from compiled for `.netstandard` and copy it into your Unity/Assets/Plugins folder. At this point, if you know how to do 


You can use the library in 2 ways: 
    - Rely on the `LensClient` and its functions to interact with the API. (Recommended for getting started)
    - Build your own queries (using the power of ZeroQL). (Recommended for advanced projects and users).

And your Unity Project can consume the library in 2 ways:
    - Directly on a Unity MonoBehaviour or Component 
    - From your own compiled Library

    