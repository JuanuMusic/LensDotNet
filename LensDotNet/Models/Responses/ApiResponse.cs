using LensDotNet.Models.Auth;

namespace LensDotNet.Client.Models.Responses
{
    public class ApiResponse<T>
    {
        public T Result { get; set; }
    }
}
