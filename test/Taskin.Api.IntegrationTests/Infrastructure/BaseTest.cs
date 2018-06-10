// ---------------------------------------------------------------------------------
// <copyright file="BaseTest.cs" Author="Juan Luis Guerrero Minero" www="elGuerre.com">
//     Copyright (c) elGuerre.com. All rights reserved.
// </copyright>
// ---------------------------------------------------------------------------------
using ElGuerre.Taskin.Api.IntegrationTests;
using Xunit;

namespace ElGuerre.Taskin.Api.IntegrationTests
{
    public class BaseTest : IClassFixture<CompositionRootFixture>
    {
        protected readonly CompositionRootFixture Fixture;

        public BaseTest(CompositionRootFixture fixture)
        {
            Fixture = fixture;
        }
    }
}
