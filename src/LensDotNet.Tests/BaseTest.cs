using System;
using LensDotNet.Tests.Utils;
using Nethereum.Web3.Accounts;

namespace LensDotNet.Tests
{
	public class BaseTest
	{
        private Account _account;
        public Account Account { get => _account; }

		[SetUp]
        public virtual void SetUp()
		{
			_account = new Account(Web3Helper.TEST_PK);
		}
	}
}

