﻿using System;
using System.Collections.Generic;
using System.Text;

namespace PeachPied.WordPress.Sdk
{
    /// <summary>
    /// Provider of <see cref="IWpPlugin"/> instances to be loaded into the WordPress.
    /// Used for MEF export.
    /// </summary>
    public interface IWpPluginProvider
    {
        /// <summary>
        /// Gets enumeration of plugins to be loaded into the WordPress.
        /// </summary>
        /// <param name="provider">Service provider for dependency injection.</param>
        /// <returns>Enumeration of plugin instances.</returns>
        IEnumerable<IWpPlugin>/*!!*/GetPlugins(IServiceProvider provider);
    }
}
