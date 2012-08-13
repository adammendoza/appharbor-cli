﻿using System;

namespace AppHarbor.Commands
{
	[CommandHelp("Add a hostname", "[HOSTNAME]")]
	public class AddHostnameCommand : Command
	{
		private readonly IApplicationConfiguration _applicationConfiguration;
		private readonly IAppHarborClient _appharborClient;

		public AddHostnameCommand(IApplicationConfiguration applicationConfiguration, IAppHarborClient appharborClient)
		{
			_applicationConfiguration = applicationConfiguration;
			_appharborClient = appharborClient;
		}

		protected override void InnerExecute(string[] arguments)
		{
			if (arguments.Length == 0)
			{
				throw new CommandException("No hostname was specified");
			}

			var applicationId = _applicationConfiguration.GetApplicationId();
			_appharborClient.CreateHostname(applicationId, arguments[0]);
		}
	}
}
