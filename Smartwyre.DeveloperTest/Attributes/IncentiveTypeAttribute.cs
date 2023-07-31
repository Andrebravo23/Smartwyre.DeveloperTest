using Smartwyre.DeveloperTest.Types;
using System;

namespace Smartwyre.DeveloperTest.Attributes
{
    /// <summary>
    /// Use this attribute on the Calculator classes so the Mediator can identify the correct calculator based on the Incentive type
    /// </summary>
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
