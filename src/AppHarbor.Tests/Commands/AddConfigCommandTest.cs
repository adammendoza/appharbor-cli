﻿using AppHarbor.Commands;
using Moq;
using Ploeh.AutoFixture.Xunit;
using Xunit.Extensions;

namespace AppHarbor.Tests.Commands
{
	public class AddConfigCommandTest
	{
		[Theory, AutoCommandData]
		public void ShouldAddConfigurationVariable([Frozen]Mock<IApplicationConfiguration> applicationConfiguration,
			[Frozen]Mock<IAppHarborClient> client,
			AddConfigCommand command, string applicationId, string key, string value)
		{
			applicationConfiguration.Setup(x => x.GetApplicationId()).Returns(applicationId);

			command.Execute(new string[] { string.Join("=", key, value) });

			client.Verify(x => x.CreateConfigurationVariable(applicationId, key, value));
		}
	}
}
