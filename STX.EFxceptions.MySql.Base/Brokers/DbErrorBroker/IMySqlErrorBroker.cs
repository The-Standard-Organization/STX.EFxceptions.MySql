// ----------------------------------------------------------------------------------
// Copyright(c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using MySql.Data.MySqlClient;
using STX.EFxceptions.Abstractions.Brokers.DbErrorBroker;

namespace STX.EFxceptions.MySql.Base.Brokers.DbErrorBroker
{
    public interface IMySqlErrorBroker : IDbErrorBroker<MySqlException>
    { }
}
