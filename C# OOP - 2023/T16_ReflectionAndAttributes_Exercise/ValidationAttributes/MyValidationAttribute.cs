using System;
namespace ValidationAttributes
{
    abstract public class MyValidationAttribute : Attribute
    {
        public abstract bool IsValid(object obj);
    }
}

