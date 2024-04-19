// ----------------------------------------------------------------------------------
// Copyright(c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;
using STX.EFxceptions.Abstractions.Brokers.DbErrorBroker;
using System;

namespace STX.EFxceptions.MySql.Base.Services.Foundations
{
    public partial class MySqlEFxceptionService : IMySqlEFxceptionService
    {
        private readonly IDbErrorBroker<MySqlException> mySqlErrorBroker;

        public MySqlEFxceptionService(IDbErrorBroker<MySqlException> mySqlErrorBroker) =>
            this.mySqlErrorBroker = mySqlErrorBroker;

        public void ThrowMeaningfulException(DbUpdateException dbUpdateException) =>
        TryCatch(() =>
        {
            ValidateInnerException(dbUpdateException);
            MySqlException mySqlException = GetSqlException(dbUpdateException.InnerException);
            int sqlErrorCode = this.mySqlErrorBroker.GetErrorCode(mySqlException);
            ConvertAndThrowMeaningfulException(sqlErrorCode, mySqlException.Message);
            throw dbUpdateException;
        });

        private MySqlException GetSqlException(Exception exception) => (MySqlException)exception;
    }
}
