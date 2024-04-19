// ----------------------------------------------------------------------------------
// Copyright(c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using Microsoft.EntityFrameworkCore;
using STX.EFxceptions.Abstractions.Models.Exceptions;
using STX.EFxceptions.MySql.Base.Models.Exceptions;

namespace STX.EFxceptions.MySql.Base.Services.Foundations
{
    public partial class MySqlEFxceptionService
    {

        public delegate void ReturningExceptionFunction();

        public void TryCatch(ReturningExceptionFunction returningExceptionFunction)
        {
            try
            {
                returningExceptionFunction();
            }
            catch (InvalidColumnNameMySqlException ivalidColumnNameMySqlException)
            {
                throw new InvalidColumnNameException(
                    message: ivalidColumnNameMySqlException.Message,
                    innerException: ivalidColumnNameMySqlException);
            }
            catch (InvalidObjectNameMySqlException invalidObjectNameMySqlException)
            {
                throw new InvalidObjectNameException(
                    message: invalidObjectNameMySqlException.Message,
                    innerException: invalidObjectNameMySqlException);
            }
            catch (ForeignKeyConstraintConflictMySqlException foreignKeyConstraintConflictMySqlException)
            {
                throw new ForeignKeyConstraintConflictException(
                    message: foreignKeyConstraintConflictMySqlException.Message,
                    innerException: foreignKeyConstraintConflictMySqlException);
            }
            catch (DuplicateKeyWithUniqueIndexMySqlException duplicateKeyWithUniqueIndexMySqlException)
            {
                throw new DuplicateKeyWithUniqueIndexException(
                    message: duplicateKeyWithUniqueIndexMySqlException.Message,
                    innerException: duplicateKeyWithUniqueIndexMySqlException);
            }
            catch (DuplicateKeyMySqlException duplicateKeyMySqlException)
            {
                throw new DuplicateKeyException(
                    message: duplicateKeyMySqlException.Message,
                    innerException: duplicateKeyMySqlException);
            }
            catch (DbUpdateException)
            {
                throw;
            }
        }

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
