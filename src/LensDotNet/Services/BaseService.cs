using System;
using LensDotNet.Contexts;
using LensDotNet.Services.Auth;

namespace LensDotNet.Services
{
	public abstract class BaseService : IService
	{
		internal LensContext _context;
        internal Credentials? _credentials;

        public BaseService(LensContext context) => _context = context;

		public BaseService(LensContext context, Credentials? credentials)
		{
			_context = context;
			_credentials = credentials;
		}
	}
}

