using System;
using System.Collections.Generic;
using System.Text;

namespace UrlShortner.Contracts.V1
{
    /// <summary>
    /// Api routes
    /// </summary>
    public static class ApiRoutes
    {
        // Set Root of api
        private const string Root = "api";
        // Set version of api routes
        private const string Version = "v1";
        // Make the base of routes
        private const string Base = Root + "/" + Version;

        /// <summary>
        /// Routes for Url Shortening
        /// </summary>
        public static class UrlShortening
        {
            /// <summary>
            /// Route for making
            /// </summary>
            public const string Make = Base + "/urlshort/make";
        }
    }
}
