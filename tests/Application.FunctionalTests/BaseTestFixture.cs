﻿namespace CleanArchitecture.Application.FunctionalTests;

public class BaseTestFixture : TestingFixture, IDisposable
{
    public BaseTestFixture()
    {
        ResetState().Wait();
    }

    public void Dispose()
    {
    }
}
