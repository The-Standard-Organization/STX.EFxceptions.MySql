// ----------------------------------------------------------------------------------
// Copyright(c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using System.Runtime.Serialization;
using Moq;
using MySql.Data.MySqlClient;
using STX.EFxceptions.MySql.Base.Brokers.DbErrorBroker;
using STX.EFxceptions.MySql.Base.Services.Foundations;
using Tynamix.ObjectFiller;

namespace STX.EFxceptions.MySql.Base.Tests.Unit.Services.Foundations
{
    public partial class MySqlEFxceptionServiceTests
    {
        private readonly Mock<IMySqlErrorBroker> mySqlErrorBrokerMock;
        private readonly IMySqlEFxceptionService mySqlEFxceptionService;

        public MySqlEFxceptionServiceTests()
        {
            this.mySqlErrorBrokerMock = new Mock<IMySqlErrorBroker>();

            this.mySqlEFxceptionService = new MySqlEFxceptionService(
                 mySqlErrorBroker: this.mySqlErrorBrokerMock.Object);
        }

        private string CreateRandomErrorMessage() => new MnemonicString().GetValue();

        private MySqlException CreateMySqlException() =>
            FormatterServices.GetUninitializedObject(typeof(MySqlException)) as MySqlException;
    }
}
