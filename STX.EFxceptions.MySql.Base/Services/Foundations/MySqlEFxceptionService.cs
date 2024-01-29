// ----------------------------------------------------------------------------------
// Copyright(c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using System;
using System.Data.Common;
using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;
using STX.EFxceptions.MySql.Base.Brokers.DbErrorBroker;

namespace STX.EFxceptions.MySql.Base.Services.Foundations
{
    public partial class MySqlEFxceptionService : IMySqlEFxceptionService
    {
        private readonly IMySqlErrorBroker mySqlErrorBroker;

        public MySqlEFxceptionService(IMySqlErrorBroker mySqlErrorBroker) =>
            this.mySqlErrorBroker = mySqlErrorBroker;

        public void ThrowMeaningfulException(DbUpdateException dbUpdateException)
        {
            MySqlException mySqlException = GetSqlException(dbUpdateException.InnerException);
            int sqlErrorCode = this.mySqlErrorBroker.GetErrorCode(mySqlException);
            ConvertAndThrowMeaningfulException(sqlErrorCode, mySqlException.Message);
            throw dbUpdateException;
        }

        private MySqlException GetSqlException(Exception exception) => (MySqlException)exception;
    }
}
