﻿// ----------------------------------------------------------------------------------
// Copyright(c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using System;

namespace STX.EFxceptions.MySql.Base.Models.Exceptions
{
    public class ForeignKeyConstraintConflictMySqlException : Exception
    {
        public ForeignKeyConstraintConflictMySqlException(string message) : base(message) { }
    }
}
