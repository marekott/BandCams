using System;
using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace Shared.CustomAttributes
{
    public class MaximumSize : ValidationAttribute
    {
        private readonly long _maxSize;

        public MaximumSize(long maxSize, [CallerMemberName] string propertyName = null)
        {
            if (maxSize <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(maxSize), "Maximum size must be greater than zero.");
            }

            _maxSize = maxSize;
            ErrorMessage = $"{propertyName} can contain max {maxSize} elements.";
        }

        public override bool IsValid(object value)
        {
            var collection = value as IList;

            return collection?.Count <= _maxSize;
        }
    }
}
