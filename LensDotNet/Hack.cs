//
// This is here to avoid a BUG on the C# language parser/
// SEE: https://stackoverflow.com/a/64749403/1561618
// 
namespace System.Runtime.CompilerServices
{
    internal static class IsExternalInit { }
}