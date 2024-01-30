// ----------------------------------------------------------------------------------
// Copyright(c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using System;

namespace STX.EFxceptions.MySql.Base.Models.Exceptions
{
    public class DuplicateKeyWithUniqueIndexMySqlException : Exception
    {
        public DuplicateKeyWithUniqueIndexMySqlException(string message) : base(message) { }
    }
}
