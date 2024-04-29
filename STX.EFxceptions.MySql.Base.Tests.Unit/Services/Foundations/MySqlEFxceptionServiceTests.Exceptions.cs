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

            MySqlException foreignKeyConstraintConflictExceptionThrown =
                CreateMySqlException(
                    message: randomErrorMessage,
                    errorCode: sqlForeignKeyConstraintConflictErrorCode);

            var dbUpdateException = new DbUpdateException(
                message: randomErrorMessage,
                innerException: foreignKeyConstraintConflictExceptionThrown);

            DbUpdateException expectedDbUpdateException = dbUpdateException;

            this.mySqlErrorBrokerMock.Setup(broker =>
                broker.GetErrorCode(foreignKeyConstraintConflictExceptionThrown))
                    .Returns(sqlForeignKeyConstraintConflictErrorCode);

            // when
            DbUpdateException actualDbUpdateException =
                Assert.Throws<DbUpdateException>(() => this.mySqlEFxceptionService
                    .ThrowMeaningfulException(dbUpdateException));

            // then
            actualDbUpdateException.Should()
                .BeEquivalentTo(
                expectation: expectedDbUpdateException,
                config: options => options
                    .Excluding(ex => ex.TargetSite)
                    .Excluding(ex => ex.StackTrace)
                    .Excluding(ex => ex.Source)
                    .Excluding(ex => ex.InnerException.TargetSite)
                    .Excluding(ex => ex.InnerException.StackTrace)
                    .Excluding(ex => ex.InnerException.Source));

            this.mySqlErrorBrokerMock.Verify(broker => broker
                .GetErrorCode(foreignKeyConstraintConflictExceptionThrown), Times.Once());

            mySqlErrorBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public void ShouldThrowInvalidColumnNameException()
        {
            // given
            int sqlInvalidColumnNameErrorCode = 207;
            string randomMySqlExceptionMessage = CreateRandomErrorMessage();

            MySqlException invalidColumnNameExceptionThrown =
                CreateMySqlException(
                    message: randomMySqlExceptionMessage,
                    errorCode: sqlInvalidColumnNameErrorCode);

            string randomDbUpdateExceptionMessage = CreateRandomErrorMessage();

            DbUpdateException dbUpdateExceptionThrown = new DbUpdateException(
                message: randomDbUpdateExceptionMessage,
                innerException: invalidColumnNameExceptionThrown);

            var ivalidColumnNameMySqlException =
                new InvalidColumnNameMySqlException(
                    message: invalidColumnNameExceptionThrown.Message);

            var expectedInvalidColumnNameException =
                new InvalidColumnNameException(
                    message: ivalidColumnNameMySqlException.Message,
                    innerException: ivalidColumnNameMySqlException);

            this.mySqlErrorBrokerMock.Setup(broker =>
                broker.GetErrorCode(invalidColumnNameExceptionThrown))
                    .Returns(sqlInvalidColumnNameErrorCode);

            // when
            InvalidColumnNameException actualInvalidColumnNameException =
                Assert.Throws<InvalidColumnNameException>(() =>
                    this.mySqlEFxceptionService.ThrowMeaningfulException(dbUpdateExceptionThrown));
            // then
            actualInvalidColumnNameException.Should()
                .BeEquivalentTo(
                    expectation: expectedInvalidColumnNameException,
                    config: options => options
                        .Excluding(ex => ex.TargetSite)
                        .Excluding(ex => ex.StackTrace)
                        .Excluding(ex => ex.Source)
                        .Excluding(ex => ex.InnerException.TargetSite)
                        .Excluding(ex => ex.InnerException.StackTrace)
                        .Excluding(ex => ex.InnerException.Source));

            this.mySqlErrorBrokerMock.Verify(broker => broker
                .GetErrorCode(invalidColumnNameExceptionThrown), Times.Once());

            mySqlErrorBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public void ShouldThrowInvalidObjectNameException()
        {
            // given
            int sqlInvalidObjectNameErrorCode = 208;
            string randomMySqlExceptionMessage = CreateRandomErrorMessage();

            MySqlException invalidObjectNameExceptionThrown =
                CreateMySqlException(
                    message: randomMySqlExceptionMessage,
                    errorCode: sqlInvalidObjectNameErrorCode);

            string randomDbUpdateExceptionMessage = CreateRandomErrorMessage();

            var dbUpdateException = new DbUpdateException(
                message: randomDbUpdateExceptionMessage,
                innerException: invalidObjectNameExceptionThrown);

            var invalidObjectNameMySqlException =
                new InvalidObjectNameMySqlException(
                    message: invalidObjectNameExceptionThrown.Message);

            var expectedInvalidObjectNameException =
                new InvalidObjectNameException(
                    message: invalidObjectNameMySqlException.Message,
                    innerException: invalidObjectNameMySqlException);

            this.mySqlErrorBrokerMock.Setup(broker =>
                broker.GetErrorCode(invalidObjectNameExceptionThrown))
                    .Returns(sqlInvalidObjectNameErrorCode);

            // when
            InvalidObjectNameException actualInvalidObjectNameException =
                Assert.Throws<InvalidObjectNameException>(() =>
                    this.mySqlEFxceptionService.ThrowMeaningfulException(dbUpdateException));

            // then
            actualInvalidObjectNameException.Should()
                .BeEquivalentTo(
                expectation: expectedInvalidObjectNameException,
                config: options => options
                    .Excluding(ex => ex.TargetSite)
                    .Excluding(ex => ex.StackTrace)
                    .Excluding(ex => ex.Source)
                    .Excluding(ex => ex.InnerException.TargetSite)
                    .Excluding(ex => ex.InnerException.StackTrace)
                    .Excluding(ex => ex.InnerException.Source));

            this.mySqlErrorBrokerMock.Verify(broker => broker
                .GetErrorCode(invalidObjectNameExceptionThrown), Times.Once());

            mySqlErrorBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public void ShouldThrowForeignKeyConstraintConflictMySqlException()
        {
            // given
            int sqlForeignKeyConstraintConflictErrorCode = 547;
            string randomMySqlExceptionMessage = CreateRandomErrorMessage();

            MySqlException foreignKeyConstraintConflictMySqlExceptionThrown =
                CreateMySqlException(
                    message: randomMySqlExceptionMessage,
                    errorCode: sqlForeignKeyConstraintConflictErrorCode);

            string randomDbUpdateExceptionMessage = CreateRandomErrorMessage();

            var dbUpdateException = new DbUpdateException(
                message: randomDbUpdateExceptionMessage,
                innerException: foreignKeyConstraintConflictMySqlExceptionThrown);

            var foreignKeyConstraintConflictMySqlException =
                new ForeignKeyConstraintConflictMySqlException(
                    message: foreignKeyConstraintConflictMySqlExceptionThrown.Message);

            var expectedForeignKeyConstraintConflictException =
                new ForeignKeyConstraintConflictException(
                    message: foreignKeyConstraintConflictMySqlException.Message,
                    innerException: foreignKeyConstraintConflictMySqlException);

            this.mySqlErrorBrokerMock.Setup(broker =>
                broker.GetErrorCode(foreignKeyConstraintConflictMySqlExceptionThrown))
                    .Returns(sqlForeignKeyConstraintConflictErrorCode);

            // when
            var actualForeignKeyConstraintConflictException =
                Assert.Throws<ForeignKeyConstraintConflictException>(() =>
                    this.mySqlEFxceptionService.ThrowMeaningfulException(dbUpdateException));

            // then
            actualForeignKeyConstraintConflictException.Should()
                .BeEquivalentTo(
                expectation: expectedForeignKeyConstraintConflictException,
                config: options => options
                    .Excluding(ex => ex.TargetSite)
                    .Excluding(ex => ex.StackTrace)
                    .Excluding(ex => ex.Source)
                    .Excluding(ex => ex.InnerException.TargetSite)
                    .Excluding(ex => ex.InnerException.StackTrace)
                    .Excluding(ex => ex.InnerException.Source));

            this.mySqlErrorBrokerMock.Verify(broker => broker
                .GetErrorCode(foreignKeyConstraintConflictMySqlExceptionThrown), Times.Once());

            mySqlErrorBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public void ShouldThrowDuplicateKeyWithUniqueIndexMySqlException()
        {
            // given
            int sqlDuplicateKeyErrorCode = 2601;
            string randomMySqlExceptionMessage = CreateRandomErrorMessage();

            MySqlException duplicateKeyWithUniqueIndexMySqlExceptionThrown =
                CreateMySqlException(
                    message: randomMySqlExceptionMessage,
                    errorCode: sqlDuplicateKeyErrorCode);

            string randomDbUpdateExceptionMessage = CreateRandomErrorMessage();

            var dbUpdateException = new DbUpdateException(
                message: randomDbUpdateExceptionMessage,
                innerException: duplicateKeyWithUniqueIndexMySqlExceptionThrown);

            var duplicateKeyWithUniqueIndexMySqlException =
                new DuplicateKeyWithUniqueIndexMySqlException(
                    message: duplicateKeyWithUniqueIndexMySqlExceptionThrown.Message);

            var expectedDuplicateKeyWithUniqueIndexException =
                new DuplicateKeyWithUniqueIndexException(
                    message: duplicateKeyWithUniqueIndexMySqlException.Message,
                    innerException: duplicateKeyWithUniqueIndexMySqlException);

            this.mySqlErrorBrokerMock.Setup(broker =>
                broker.GetErrorCode(duplicateKeyWithUniqueIndexMySqlExceptionThrown))
                    .Returns(sqlDuplicateKeyErrorCode);

            // when 
            var actualDuplicateKeyWithUniqueIndexException =
                Assert.Throws<DuplicateKeyWithUniqueIndexException>(() =>
                    this.mySqlEFxceptionService.ThrowMeaningfulException(dbUpdateException));

            // then
            actualDuplicateKeyWithUniqueIndexException.Should()
                .BeEquivalentTo(
                expectation: expectedDuplicateKeyWithUniqueIndexException,
                config: options => options
                    .Excluding(ex => ex.TargetSite)
                    .Excluding(ex => ex.StackTrace)
                    .Excluding(ex => ex.Source)
                    .Excluding(ex => ex.InnerException.TargetSite)
                    .Excluding(ex => ex.InnerException.StackTrace)
                    .Excluding(ex => ex.InnerException.Source));

            this.mySqlErrorBrokerMock.Verify(broker => broker
                .GetErrorCode(duplicateKeyWithUniqueIndexMySqlExceptionThrown), Times.Once());

            mySqlErrorBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public void ShouldThrowDuplicateKeyMySqlException()
        {
            // given
            int sqlDuplicateKeyErrorCode = 2627;
            string randomMySqlExceptionMessage = CreateRandomErrorMessage();

            MySqlException duplicateKeyMySqlExceptionThrown = CreateMySqlException(
                message: randomMySqlExceptionMessage,
                errorCode: sqlDuplicateKeyErrorCode);

            string randomDbUpdateExceptionMessage = CreateRandomErrorMessage();

            var dbUpdateException = new DbUpdateException(
                message: randomDbUpdateExceptionMessage,
                innerException: duplicateKeyMySqlExceptionThrown);

            var duplicateKeyMySqlException =
                new DuplicateKeyMySqlException(
                    message: duplicateKeyMySqlExceptionThrown.Message);

            var expectedDuplicateKeyException =
                new DuplicateKeyException(
                    message: duplicateKeyMySqlException.Message,
                    innerException: duplicateKeyMySqlException);

            this.mySqlErrorBrokerMock.Setup(broker =>
                broker.GetErrorCode(duplicateKeyMySqlExceptionThrown))
                    .Returns(sqlDuplicateKeyErrorCode);

            // when
            var actualDuplicateKeyException =
                Assert.Throws<DuplicateKeyException>(() =>
                    this.mySqlEFxceptionService.ThrowMeaningfulException(dbUpdateException));

            // then
            actualDuplicateKeyException.Should()
                .BeEquivalentTo(
                expectation: expectedDuplicateKeyException,
                config: options => options
                    .Excluding(ex => ex.TargetSite)
                    .Excluding(ex => ex.StackTrace)
                    .Excluding(ex => ex.Source)
                    .Excluding(ex => ex.InnerException.TargetSite)
                    .Excluding(ex => ex.InnerException.StackTrace)
                    .Excluding(ex => ex.InnerException.Source));

            this.mySqlErrorBrokerMock.Verify(broker => broker
                .GetErrorCode(duplicateKeyMySqlExceptionThrown), Times.Once());

            mySqlErrorBrokerMock.VerifyNoOtherCalls();
        }
    }
}
