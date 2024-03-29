﻿// ----------------------------------------------------------------------------------
// Copyright(c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using STX.EFxceptions.MySql.Base.Models.Exceptions;

namespace STX.EFxceptions.MySql.Base.Services.Foundations
{
    public partial class MySqlEFxceptionService
    {
        private void ConvertAndThrowMeaningfulException(int sqlErrorCode, string message)
        {
            switch (sqlErrorCode)
            {
                case 207:
                    throw new InvalidColumnNameMySqlException(message);
                case 208:
                    throw new InvalidObjectNameMySqlException(message);
                case 547:
                    throw new ForeignKeyConstraintConflictMySqlException(message);
                case 2601:
                    throw new DuplicateKeyWithUniqueIndexMySqlException(message);
                case 2627:
                    throw new DuplicateKeyMySqlException(message);
            }
        }
    }
}
