using System;

namespace Intro.Test.ExceptionFormat
{
    public class ThrowingType
    {
        public ThrowingType()
        {
            throw new Exception("error");
        }
    }
}