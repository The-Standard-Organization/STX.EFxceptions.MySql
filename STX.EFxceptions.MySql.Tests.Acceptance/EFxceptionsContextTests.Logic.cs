// ----------------------------------------------------------------------------------
// Copyright (c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using System;
using STX.EFxceptions.MySql.Tests.Acceptance.Models.Clients;
using Xunit;

namespace STX.EFxceptions.MySql.Tests.Acceptance
{
    public partial class EFxceptionsContextTests
    {
        [Fact]
        public void ShouldSaveChangesSuccessfully()
        {
            // given
            var client = new Client
            {
                Id = Guid.NewGuid()
            };

            // when
            context.Clients.Add(client);
            context.SaveChanges();

            // then
            context.Clients.Remove(client);
            context.SaveChanges();
        }
    }
}
