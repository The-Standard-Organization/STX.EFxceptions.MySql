// ----------------------------------------------------------------------------------
// Copyright (c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using Microsoft.EntityFrameworkCore;

namespace STX.EFxceptions.MySql.Tests.Acceptance
{
    public partial class EFxceptionsContextTests
    {
        private readonly DbContextOptions<EFxceptionsContext> options;
        private readonly MyEFxceptionsContext context;

        public EFxceptionsContextTests()
        {
            options = new DbContextOptionsBuilder<EFxceptionsContext>()
                .UseInMemoryDatabase(databaseName: "InMemoryDatabase")
                .Options;

            this.context = new MyEFxceptionsContext(options);
        }
    }
}
