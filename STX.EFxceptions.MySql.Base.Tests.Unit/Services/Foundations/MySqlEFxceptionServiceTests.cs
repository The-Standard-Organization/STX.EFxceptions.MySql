// ----------------------------------------------------------------------------------
// Copyright(c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using System.Reflection;
using Moq;
using Tynamix.ObjectFiller;
using MySql.Data.MySqlClient;
using STX.EFxceptions.MySql.Base.Brokers.DbErrorBroker;
using STX.EFxceptions.MySql.Base.Services.Foundations;

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

        private MySqlException CreateMySqlException(string message, int errorCode)
        {
            ConstructorInfo ctor = typeof(MySqlException)
                .GetConstructor(BindingFlags.NonPublic | BindingFlags.Instance, null,
                    new[] { typeof(string), typeof(int) }, null);

            var exception = (MySqlException)ctor.Invoke(new object[] { message, errorCode });

            return exception;
        }
    }
}
