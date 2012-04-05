﻿using System;
using System.Collections.Generic;
using AppHarbor.Model;

namespace AppHarbor
{
	public class AppHarborClient : IAppHarborClient
	{
		private readonly AuthInfo _authInfo;

		public AppHarborClient(string AccessToken)
		{
			_authInfo = new AuthInfo { AccessToken = AccessToken };
		}

		public CreateResult<string> CreateApplication(string name, string regionIdentifier = null)
		{
			var appHarborApi = GetAppHarborApi();
			return appHarborApi.CreateApplication(name, regionIdentifier);
		}

		public IEnumerable<Application> GetApplications()
		{
			var appHarborApi = GetAppHarborApi();
			return appHarborApi.GetApplications();
		}

		private AppHarborApi GetAppHarborApi()
		{
			try
			{
				return new AppHarborApi(_authInfo);
			}
			catch (ArgumentNullException)
			{
				throw new CommandException("You're not logged in. Log in with \"appharbor login\"");
			}
		}

		public User GetUser()
		{
			var appHarborApi = GetAppHarborApi();
			return appHarborApi.GetUser();
		}
	}
}
