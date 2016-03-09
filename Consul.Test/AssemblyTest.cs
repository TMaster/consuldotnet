using System;
using System.Text;
using System.Collections.Generic;
using Xunit;
using System.Reflection;
using System.Diagnostics;

namespace Consul.Test
{
    public class AssemblyTest
    {
#if DNX451
        [Fact]
        public void Assembly_IsStrongNamed()
        {

            Type type = typeof(Consul.ConsulClient);
            string name = type.Assembly.FullName.ToString();
            Trace.WriteLine(name);
            Assert.True(type.Assembly.FullName.Contains("PublicKeyToken"));

        }
#endif
    }
}