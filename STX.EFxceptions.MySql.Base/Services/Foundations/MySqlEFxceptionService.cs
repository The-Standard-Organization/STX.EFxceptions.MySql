// ----------------------------------------------------------------------------------
// Copyright(c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using Microsoft.EntityFrameworkCore;
using STX.EFxceptions.MySql.Base.Brokers.DbErrorBroker;

namespace STX.EFxceptions.MySql.Base.Services.Foundations
{
    public class MySqlEFxceptionService : IMySqlEFxceptionService
    {
        private readonly IMySqlErrorBroker mySqlErrorBroker;

        public MySqlEFxceptionService(IMySqlErrorBroker mySqlErrorBroker) =>
            this.mySqlErrorBroker = mySqlErrorBroker;

        public void ThrowMeaningfulException(DbUpdateException dbUpdateException)
        {
            throw new System.NotImplementedException();
        }
    }
}
