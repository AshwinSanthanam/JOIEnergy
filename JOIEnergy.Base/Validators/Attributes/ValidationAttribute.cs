using System;

namespace JOIEnergy.Base.Validators.Attributes
{
    [AttributeUsage(AttributeTargets.Method)]
    public class ValidationAttribute : Attribute
    {
        public string TargetField { get; }
        public string Message { get; }

        public ValidationAttribute(string targetField, string message)
        {
            TargetField = targetField;
            Message = message;
        }
    }
}
