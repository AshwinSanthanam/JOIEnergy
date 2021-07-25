using System;

namespace JOIEnergy.Base.Validators.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class ValidatorAttribute : Attribute
    {
        public string Entity { get; }

        public ValidatorAttribute(string entity)
        {
            Entity = entity;
        }
    }
}
