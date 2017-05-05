using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MonoDragons.Core.Tests
{
    public static class ExceptionAssert
    {
        public static void Throws(Action action)
        {
            try
            {
                action();
                Assert.Fail("Expected exception to be thrown, but did not occur.");
            }
            catch (Exception)
            {
                // ignored
            }
        }
    }
}
