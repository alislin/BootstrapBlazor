﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

#if NET6_0_OR_GREATER
using System.Diagnostics.CodeAnalysis;

namespace Microsoft.AspNetCore.Internal;

internal static class LinkerFlags
{
    /// <summary>
    /// Flags for a member that is JSON (de)serialized.
    /// </summary>
    public const DynamicallyAccessedMemberTypes JsonSerialized = DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.PublicFields | DynamicallyAccessedMemberTypes.PublicProperties;

    /// <summary>
    /// Flags for a component
    /// </summary>
    public const DynamicallyAccessedMemberTypes Component = DynamicallyAccessedMemberTypes.All;
}
#endif
