// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Options;
using QingCheng.AspNetCore.Authentication.Cookies;

namespace QingCheng.Extensions.DependencyInjection
{
    public static class CookieExtensions
    {
        public static AuthenticationBuilder AddCookieX(this AuthenticationBuilder builder)
            => builder.AddCookieX(CookieAuthenticationDefaults.AuthenticationScheme);

        public static AuthenticationBuilder AddCookieX(this AuthenticationBuilder builder, string authenticationScheme)
            => builder.AddCookieX(authenticationScheme, configureOptions: null);

        public static AuthenticationBuilder AddCookieX(this AuthenticationBuilder builder, Action<CookieAuthenticationOptions> configureOptions) 
            => builder.AddCookieX(CookieAuthenticationDefaults.AuthenticationScheme, configureOptions);

        public static AuthenticationBuilder AddCookieX(this AuthenticationBuilder builder, string authenticationScheme, Action<CookieAuthenticationOptions> configureOptions)
            => builder.AddCookieX(authenticationScheme, displayName: null, configureOptions: configureOptions);

        public static AuthenticationBuilder AddCookieX(this AuthenticationBuilder builder, string authenticationScheme, string displayName, Action<CookieAuthenticationOptions> configureOptions)
        {
            builder.Services.TryAddEnumerable(ServiceDescriptor.Singleton<IPostConfigureOptions<CookieAuthenticationOptions>, PostConfigureCookieAuthenticationOptions>());
            builder.Services.AddOptions<CookieAuthenticationOptions>(authenticationScheme).Validate(o => o.Cookie.Expiration == null, "Cookie.Expiration is ignored, use ExpireTimeSpan instead.");
            return builder.AddScheme<CookieAuthenticationOptions, CookieAuthenticationHandler>(authenticationScheme, displayName, configureOptions);
        }
    }
}
