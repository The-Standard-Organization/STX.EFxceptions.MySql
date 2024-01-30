// ----------------------------------------------------------------------------------
// Copyright(c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using System;
using Microsoft.EntityFrameworkCore;
using Moq;
using MySql.Data.MySqlClient;
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

            // when . then
            Assert.Throws<DbUpdateException>(() =>
                this.mySqlEFxceptionService.ThrowMeaningfulException(dbUpdateException));

            this.mySqlErrorBrokerMock.Verify(broker =>
                broker.GetErrorCode(It.IsAny<MySqlException>()),
                    Times.Never);
        }
    }
}
