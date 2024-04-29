// ----------------------------------------------------------------------------------
// Copyright(c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using System;
using FluentAssertions;
using MySql.Data.MySqlClient;
using Microsoft.EntityFrameworkCore;
using Moq;
using Xunit;

namespace STX.EFxceptions.MySql.Base.Tests.Unit.Services.Foundations
{
    public partial class MySqlEFxceptionServiceTests
    {
        [Fact]
        public void ShouldThrowDbUpdateExceptionIfMySqlExceptionWasNull()
        {
            // given
            var dbUpdateException = new DbUpdateException(null, default(Exception));
            DbUpdateException expectedDbUpdateException = dbUpdateException;

            // when 
            DbUpdateException actualDbUpdateException =
                Assert.Throws<DbUpdateException>(() =>
                    this.mySqlEFxceptionService
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

            this.mySqlErrorBrokerMock.Verify(broker =>
                broker.GetErrorCode(It.IsAny<MySqlException>()),
                    Times.Never);

            this.mySqlErrorBrokerMock.VerifyNoOtherCalls();
        }
    }
}
