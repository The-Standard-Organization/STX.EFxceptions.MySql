// ----------------------------------------------------------------------------------
// Copyright(c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;
using STX.EFxceptions.Core;
using STX.EFxceptions.Interfaces.Brokers.DbErrorBroker;
using STX.EFxceptions.Interfaces.Services.EFxceptions;
using STX.EFxceptions.MySql.Base.Brokers.DbErrorBroker;
using STX.EFxceptions.MySql.Base.Services.Foundations;

namespace STX.EFxceptions.MySql
{
    public class EFxceptionsContext : DbContextBase<MySqlException>
    {
        public EFxceptionsContext(DbContextOptions<EFxceptionsContext> options)
            : base(options)
        { }

        protected EFxceptionsContext()
            : base()
        { }

        protected override IDbErrorBroker<MySqlException> CreateErrorBroker() =>
            new MySqlErrorBroker();

        protected override IEFxceptionService CreateEFxceptionService(
            IDbErrorBroker<MySqlException> errorBroker)
        {
            return new MySqlEFxceptionService(errorBroker);
        }
    }
}
