﻿namespace LightBDD.MsTest
{
    //TODO: update namespace
    /// <summary>
    /// Base class for feature tests with MSTest framework.
    /// It offers <see cref="Runner"/> property allowing to execute scenarios belonging to the feature class.
    /// </summary>
    [FeatureFixture]
    public class FeatureFixture
    {
        /// <summary>
        /// Returns <see cref="IBddRunner"/> allowing to execute scenarios belonging to the feature class.
        /// </summary>
        protected IBddRunner Runner { get; }
        /// <summary>
        /// Default constructor initializing <see cref="Runner"/> for feature class instance.
        /// </summary>
        protected FeatureFixture()
        {
            Runner = MsTestFeatureRunnerFactory.GetRunnerFor(GetType()).GetRunner(this);
        }
    }
}