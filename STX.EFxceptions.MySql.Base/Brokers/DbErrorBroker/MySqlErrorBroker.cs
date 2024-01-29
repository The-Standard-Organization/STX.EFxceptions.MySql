// ----------------------------------------------------------------------------------
// Copyright(c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using MySql.Data.MySqlClient;

namespace STX.EFxceptions.MySql.Base.Brokers.DbErrorBroker
{
    public class MySqlErrorBroker : IMySqlErrorBroker
    {
        public int GetErrorCode(MySqlException mySqlException) =>
            mySqlException.ErrorCode;
    }
}
