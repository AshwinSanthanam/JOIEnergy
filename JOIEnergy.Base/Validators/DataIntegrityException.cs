using System;

namespace JOIEnergy.Base.Validators
{
    public class DataIntegrityException : Exception
    {
        public string EntityName { get; }
        public string TargetField { get; }

        public DataIntegrityException(string entityName, string targetField, string message) : base(message)
        {
            EntityName = entityName;
            TargetField = targetField;
        }
    }
}
