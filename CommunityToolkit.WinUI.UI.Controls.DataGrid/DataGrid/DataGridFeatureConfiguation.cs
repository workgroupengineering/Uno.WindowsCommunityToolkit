// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace CommunityToolkit.WinUI.UI.Controls
{
    /// <summary>
    /// Uno-specific feature configuration
    /// </summary>
    public static class DataGridFeatureConfiguation
    {
        /// <summary>
        /// Gets or sets a value indicating whether if InvalidateMeasure invocations can be done in MeasureOverride locations.
        /// </summary>
        /// <remarks>
        /// This configuration is required until https://github.com/unoplatform/uno/issues/3519 is fixed. Without this
        /// the layout engine turns into a loop and consumes CPU excessively, or freezes the app.
        /// </remarks>
        public static bool EnableInvalidateMeasureInMeasureOverride { get; set; }

#if __IOS__
            // Workaround for invalidation issue (https://github.com/unoplatform/uno/issues/3519)
            = false;
#else
            = true;
#endif
    }
}