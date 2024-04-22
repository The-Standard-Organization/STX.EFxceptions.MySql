// ----------------------------------------------------------------------------------
// Copyright(c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Moq;
using MySql.Data.MySqlClient;
using STX.EFxceptions.Abstractions.Models.Exceptions;
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

            var expectedDbUpdateException = new DbUpdateException(
                message: randomErrorMessage,
                innerException: foreignKeyConstraintConflictException);

            this.mySqlErrorBrokerMock.Setup(broker =>
                broker.GetErrorCode(foreignKeyConstraintConflictException))
                    .Returns(sqlForeignKeyConstraintConflictErrorCode);

            // when
            var actualDbUpdateException = Assert.Throws<DbUpdateException>(() =>
                this.mySqlEFxceptionService.ThrowMeaningfulException(expectedDbUpdateException));

            // then
            actualDbUpdateException.Should().BeEquivalentTo(expectedDbUpdateException);

            this.mySqlErrorBrokerMock.Verify(broker => broker
                .GetErrorCode(foreignKeyConstraintConflictException), Times.Once());
        }

        [Fact]
        public void ShouldThrowInvalidColumnNameException()
        {
            // given
            int sqlInvalidColumnNameErrorCode = 207;
            string randomErrorMessage = CreateRandomErrorMessage();

            var invalidColumnNameMySqlException =
                new InvalidColumnNameMySqlException(randomErrorMessage);

            var expectedInvalidColumnNameException = new InvalidColumnNameException(
                randomErrorMessage, invalidColumnNameMySqlException);

            MySqlException invalidColumnNameException = CreateMySqlException();

            var dbUpdateException = new DbUpdateException(
                message: randomErrorMessage,
                innerException: invalidColumnNameException);

            this.mySqlErrorBrokerMock.Setup(broker =>
                broker.GetErrorCode(invalidColumnNameException))
                    .Returns(sqlInvalidColumnNameErrorCode);

            // when
            InvalidColumnNameException actualInvalidColumnNameException = 
                Assert.Throws<InvalidColumnNameException>(() => 
                    this.mySqlEFxceptionService.ThrowMeaningfulException(dbUpdateException));

            // then
            actualInvalidColumnNameException.Should()
                .BeEquivalentTo(expectedInvalidColumnNameException);

            this.mySqlErrorBrokerMock.Verify(broker => broker
                .GetErrorCode(invalidColumnNameException), Times.Once());
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
            Assert.Throws<InvalidObjectNameException>(() =>
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
            Assert.Throws<ForeignKeyConstraintConflictException>(() =>
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
            Assert.Throws<DuplicateKeyWithUniqueIndexException>(() =>
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
            Assert.Throws<DuplicateKeyException>(() =>
                this.mySqlEFxceptionService.ThrowMeaningfulException(dbUpdateException));
        }
    }
}
