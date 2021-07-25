using JOIEnergy.Base.Validators.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace JOIEnergy.Base.Validators
{
    public class BaseValidator<TTransientEntity, TValidator>
    {
        private readonly IEnumerable<MethodInfo> _validationMethods;
        private readonly ValidatorAttribute _validatorAttribute;

        public BaseValidator()
        {
            Type validatorType = typeof(TValidator);
            _validatorAttribute = (ValidatorAttribute)validatorType.GetCustomAttributes(typeof(ValidatorAttribute), false).First();
            _validationMethods = validatorType.GetRuntimeMethods().Where(x => x.GetCustomAttributes(typeof(ValidationAttribute), false).Any());
        }

        public void Validate(TTransientEntity transientEntity, string exclusionId)
        {
            foreach (var method in _validationMethods)
            {
                bool isValid = (bool)method.Invoke(this, new object[] { transientEntity, exclusionId });
                ValidationAttribute validationAttribute = (ValidationAttribute)method.GetCustomAttributes(typeof(ValidationAttribute), false).First();
                if(!isValid)
                {
                    throw new DataIntegrityException(_validatorAttribute.Entity, validationAttribute.TargetField, validationAttribute.Message);
                }
            }
        }
    }
}
