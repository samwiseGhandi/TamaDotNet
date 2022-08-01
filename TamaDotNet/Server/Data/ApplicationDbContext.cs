﻿using Duende.IdentityServer.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using TamaDotNet.Server.Models;

namespace TamaDotNet.Server.Data {
    public class ApplicationDbContext:ApiAuthorizationDbContext<ApplicationUser> {
        public ApplicationDbContext(
            DbContextOptions options,
            IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions) {
        }
    }
}