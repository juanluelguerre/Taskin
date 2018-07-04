// ---------------------------------------------------------------------------------
// <copyright file="BaseTest.cs" Author="Juan Luis Guerrero Minero" www="elGuerre.com">
//     Copyright (c) elGuerre.com. All rights reserved.
// </copyright>
// ---------------------------------------------------------------------------------
using Xunit;

namespace ElGuerre.Taskin.Api.IntegrationTests
{
    public class BaseTest : IClassFixture<CompositionRootFixture>
    //public class BaseTest : IClassFixture<WebAppFactory<Startup>>
    {
        protected readonly CompositionRootFixture Fixture;

        public BaseTest(CompositionRootFixture fixture)
        {
            Fixture = fixture;
        }
    }
}
