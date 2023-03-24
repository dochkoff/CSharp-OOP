using System;
namespace ValidationAttributes
{
    public class MyRequiredAttribute : MyValidationAttribute
    {
        public MyRequiredAttribute()
        {
        }

        public override bool IsValid(object obj)
        => obj is not null;
    }
}

