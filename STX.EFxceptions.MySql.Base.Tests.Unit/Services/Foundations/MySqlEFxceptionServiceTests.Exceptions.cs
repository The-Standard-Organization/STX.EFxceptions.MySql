// ----------------------------------------------------------------------------------
// Copyright(c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;
using STX.EFxceptions.MySql.Base.Models.Exceptions;
using Xunit;

namespace STX.EFxceptions.MySql.Base.Tests.Unit.Services.Foundations
{
    public partial class MySqlEFxceptionServiceTests
    {
        [Fact]
        public void ShouldThrowDbUpdateExceptionIfErrorCodeIsNotRecognized()
        {
            // given
            int sqlForeignKeyConstraintConflictErrorCode = 0000;
            string randomErrorMessage = CreateRandomErrorMessage();
            MySqlException foreignKeyConstraintConflictException = CreateMySqlException();

            var dbUpdateException = new DbUpdateException(
                message: randomErrorMessage,
                innerException: foreignKeyConstraintConflictException);

            this.mySqlErrorBrokerMock.Setup(broker =>
                broker.GetErrorCode(foreignKeyConstraintConflictException))
                    .Returns(sqlForeignKeyConstraintConflictErrorCode);

            // when . then
            Assert.Throws<DbUpdateException>(() =>
                this.mySqlEFxceptionService.ThrowMeaningfulException(dbUpdateException));
        }

        [Fact]
        public void ShouldThrowInvalidColumnNameException()
        {
            // given
            int sqlInvalidColumnNameErrorCode = 207;
            string randomErrorMessage = CreateRandomErrorMessage();
            MySqlException invalidColumnNameException = CreateMySqlException();

            var dbUpdateException = new DbUpdateException(
                message: randomErrorMessage,
                innerException: invalidColumnNameException);

            this.mySqlErrorBrokerMock.Setup(broker =>
                broker.GetErrorCode(invalidColumnNameException))
                    .Returns(sqlInvalidColumnNameErrorCode);

            // when . then
            Assert.Throws<InvalidColumnNameMySqlException>(() =>
                this.mySqlEFxceptionService.ThrowMeaningfulException(dbUpdateException));
        }

        [Fact]
        public void ShouldThrowInvalidObjectNameException()
        {
            // given
            int sqlInvalidObjectNameErrorCode = 208;
            string randomErrorMessage = CreateRandomErrorMessage();
            MySqlException invalidObjectNameException = CreateMySqlException();

            var dbUpdateException = new DbUpdateException(
                message: randomErrorMessage,
                innerException: invalidObjectNameException);

            this.mySqlErrorBrokerMock.Setup(broker =>
                broker.GetErrorCode(invalidObjectNameException))
                    .Returns(sqlInvalidObjectNameErrorCode);

            // when . then
            Assert.Throws<InvalidObjectNameMySqlException>(() =>
                this.mySqlEFxceptionService.ThrowMeaningfulException(dbUpdateException));
        }
        
        [Fact]
        public void ShouldThrowForeignKeyConstraintConflictMySqlException()
        {
            // given
            int sqlForeignKeyConstraintConflictErrorCode = 547;
            string randomErrorMessage = CreateRandomErrorMessage();
            MySqlException foreignKeyConstraintConflictMySqlException = CreateMySqlException();

            var dbUpdateException = new DbUpdateException(
                message: randomErrorMessage,
                innerException: foreignKeyConstraintConflictMySqlException);

            this.mySqlErrorBrokerMock.Setup(broker =>
                broker.GetErrorCode(foreignKeyConstraintConflictMySqlException))
                    .Returns(sqlForeignKeyConstraintConflictErrorCode);

            // when . then
            Assert.Throws<ForeignKeyConstraintConflictMySqlException>(() =>
                this.mySqlEFxceptionService.ThrowMeaningfulException(dbUpdateException));
        }
        
        [Fact]
        public void ShouldThrowDuplicateKeyWithUniqueIndexMySqlException()
        {
            // given
            int sqlDuplicateKeyErrorCode = 2601;
            string randomErrorMessage = CreateRandomErrorMessage();
            MySqlException duplicateKeyWithUniqueIndexMySqlException = CreateMySqlException();

            var dbUpdateException = new DbUpdateException(
                message: randomErrorMessage,
                innerException: duplicateKeyWithUniqueIndexMySqlException);

            this.mySqlErrorBrokerMock.Setup(broker =>
                broker.GetErrorCode(duplicateKeyWithUniqueIndexMySqlException))
                    .Returns(sqlDuplicateKeyErrorCode);

            // when . then
            Assert.Throws<DuplicateKeyWithUniqueIndexMySqlException>(() =>
                this.mySqlEFxceptionService.ThrowMeaningfulException(dbUpdateException));
        }
        
        [Fact]
        public void ShouldThrowDuplicateKeyMySqlException()
        {
            // given
            int sqlDuplicateKeyErrorCode = 2627;
            string randomErrorMessage = CreateRandomErrorMessage();
            MySqlException duplicateKeyMySqlException = CreateMySqlException();

            var dbUpdateException = new DbUpdateException(
                message: randomErrorMessage,
                innerException: duplicateKeyMySqlException);

            this.mySqlErrorBrokerMock.Setup(broker =>
                broker.GetErrorCode(duplicateKeyMySqlException))
                    .Returns(sqlDuplicateKeyErrorCode);

            // when . then
            Assert.Throws<DuplicateKeyMySqlException>(() =>
                this.mySqlEFxceptionService.ThrowMeaningfulException(dbUpdateException));
        }
    }
}
