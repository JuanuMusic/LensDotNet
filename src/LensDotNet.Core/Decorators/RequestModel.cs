using System;
namespace LensDotNet.Core.Decorators
{
	public class RequestModel<T>
	{
        public RequestModel() { }
        public RequestModel(T request) => Request = request;
		public T Request { get; set; }
	}

	public class RequestModel
	{
        public RequestModel() { }
        public RequestModel(object request) => Request = request;
        public object Request { get; set; }
    }
}

