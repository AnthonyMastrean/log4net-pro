using System;

namespace Intro.Test.ExceptionFormat
{
    public class WrappingType
    {
        public WrappingType()
        {
            try
            {
                new ThrowingType();
            }
            catch (Exception e)
            {
                throw new FormatException("Failed to format something.", e);
            }
        }
    }
}