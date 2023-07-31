using Smartwyre.DeveloperTest.Types;
using System;

namespace Smartwyre.DeveloperTest.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class IncentiveTypeAttribute : Attribute
    {
        public IncentiveType IncentiveType { get; }

        public IncentiveTypeAttribute(IncentiveType incentiveType)
        {
            IncentiveType = incentiveType;
        }
    }
}
