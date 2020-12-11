using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ApiBase.AcceptanceTests.Brokers
{
    [CollectionDefinition(nameof(ApiTestCollection))]
    public class ApiTestCollection : ICollectionFixture<ApiBaseBroker>
    {
    }
}
