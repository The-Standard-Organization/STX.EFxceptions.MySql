﻿// ----------------------------------------------------------------------------------
// Copyright(c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;
using STX.EFxceptions.Identity.Core;
using STX.EFxceptions.Interfaces.Brokers.DbErrorBroker;
using STX.EFxceptions.Interfaces.Services.EFxceptions;
using STX.EFxceptions.MySql.Base.Brokers.DbErrorBroker;
using STX.EFxceptions.MySql.Base.Services.Foundations;

namespace STX.EFxceptions.Identity.MySql
{
    public class EFxceptionsIdentityContext<TUser, TRole, TKey>
         : IdentityDbContextBase<TUser, TRole, TKey, IdentityUserClaim<TKey>, IdentityUserRole<TKey>,
             IdentityUserLogin<TKey>, IdentityRoleClaim<TKey>, IdentityUserToken<TKey>, MySqlException>
        where TUser : IdentityUser<TKey>
        where TRole : IdentityRole<TKey>
        where TKey : IEquatable<TKey>
    {
        protected EFxceptionsIdentityContext()
        { }

        public EFxceptionsIdentityContext(DbContextOptions options) : base(options)
        { }

        protected override IDbErrorBroker<MySqlException> CreateErrorBroker() =>
            new MySqlErrorBroker();

        protected override IEFxceptionService CreateEFxceptionService(
            IDbErrorBroker<MySqlException> errorBroker)
        {
            return new MySqlEFxceptionService(errorBroker);
        }
    }

    public class EFxceptionsIdentityContext<
        TUser, TRole, TKey, TUserClaim, TUserRole, TUserLogin, TRoleClaim, TUserToken>
        : IdentityDbContextBase<TUser, TRole, TKey,
            TUserClaim, TUserRole, TUserLogin, TRoleClaim, TUserToken, MySqlException>
        where TUser : IdentityUser<TKey>
        where TRole : IdentityRole<TKey>
        where TKey : IEquatable<TKey>
        where TUserClaim : IdentityUserClaim<TKey>
        where TUserRole : IdentityUserRole<TKey>
        where TUserLogin : IdentityUserLogin<TKey>
        where TRoleClaim : IdentityRoleClaim<TKey>
        where TUserToken : IdentityUserToken<TKey>
    {
        protected override IDbErrorBroker<MySqlException> CreateErrorBroker() =>
            new MySqlErrorBroker();

        protected override IEFxceptionService CreateEFxceptionService(
            IDbErrorBroker<MySqlException> errorBroker)
        {
            return new MySqlEFxceptionService(errorBroker);
        }
    }
}