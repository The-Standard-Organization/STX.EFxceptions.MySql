// ----------------------------------------------------------------------------------
// Copyright(c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using Microsoft.EntityFrameworkCore;

namespace STX.EFxceptions.MySql.Base.Models.Exceptions
{
    public class ForeignKeyConstraintConflictMySqlException : DbUpdateException
    {
        public ForeignKeyConstraintConflictMySqlException(string message) : base(message) { }
    }
}
