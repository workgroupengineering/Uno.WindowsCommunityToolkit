// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using Microsoft.VisualStudio.TestTools.UnitTesting.Logging;
using System;
using UnitTests.Extensions;
using Windows.ApplicationModel;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using Windows.ApplicationModel.Activation;
using Windows.ApplicationModel.Core;
using Windows.System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace UnitTests
{
    /// <summary>
    /// Provides application-specific behavior to supplement the default Application class.
    /// </summary>
    public partial class App : Application
    {
        // Holder for test content to abstract Window.Current.Content
        public static FrameworkElement ContentRoot
        {
            get
            {
                var rootFrame = Window.Current.Content as Frame;
                return rootFrame.Content as FrameworkElement;
            }

            set
            {
                var rootFrame = Window.Current.Content as Frame;
                rootFrame.Content = value;
            }
        }

        // Abstract CoreApplication.MainView.DispatcherQueue
        public static DispatcherQueue DispatcherQueue
        {
            get
            {
                return CoreApplication.MainView.DispatcherQueue;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="App"/> class.
        /// Initializes the singleton application object.  This is the first line of authored code
        /// executed, and as such is the logical equivalent of main() or WinMain().
        /// </summary>
        public App(ITestMethod testMethod, TaskCompletionSource<TestResult> taskCompletionSource)
        {
            InitializeComponent();
            Suspending += OnSuspending;
            _testMethod = testMethod;
            _taskCompletionSource = taskCompletionSource;
        }

        /// <summary>
        /// Invoked when the application is launched normally by the end user.  Other entry points
        /// will be used such as when the application is launched to open a specific file.
        /// </summary>
        /// <param name="e">Details about the launch request and process.</param>
        protected override void OnLaunched(Microsoft.UI.Xaml.LaunchActivatedEventArgs e)
        {
#if DEBUG
            if (System.Diagnostics.Debugger.IsAttached)
            {
                DebugSettings.EnableFrameRateCounter = true;
            }

#endif

            Frame rootFrame = Window.Current.Content as Frame;

            // Do not repeat app initialization when the Window already has content,
            // just ensure that the window is active
            if (rootFrame == null)
            {
                // Create a Frame to act as the navigation context and navigate to the first page
                rootFrame = new Frame()
                {
                    CacheSize = 0 // Prevent any test pages from being cached
                };

                rootFrame.NavigationFailed += OnNavigationFailed;

                if (e.UWPLaunchActivatedEventArgs.PreviousExecutionState == ApplicationExecutionState.Terminated)
                {
                    // TODO: Load state from previously suspended application
                }

                Logger.LogMessage("Looking for DefaultRichEditBoxStyle...");
                if (!Resources.TryGetValue("DefaultRichEditBoxStyle", out var value))
                {
                    Logger.LogMessage("ERROR: Couldn't find DefaultRichEditBoxStyle in WinUI!");
                    throw new ApplicationException("Couldn't find DefaultRichEditBoxStyle resource.");
                }
                else
                {
                    Logger.LogMessage("FOUND!");
                }

                // Place the frame in the current Window
                Window.Current.Content = rootFrame;
            }

            // Microsoft.VisualStudio.TestPlatform.TestExecutor.UnitTestClient.CreateDefaultUI();

            // Ensure the current window is active
            Window.Current.Activate();

            // Microsoft.VisualStudio.TestPlatform.TestExecutor.UnitTestClient.Run(e.Arguments);
            var result = _testMethod.Invoke(new object[] { });

            _taskCompletionSource.SetResult(result);

            Exit();
        }

        /// <summary>
        /// Invoked when Navigation to a certain page fails
        /// </summary>
        /// <param name="sender">The Frame which failed navigation</param>
        /// <param name="e">Details about the navigation failure</param>
        private void OnNavigationFailed(object sender, NavigationFailedEventArgs e)
        {
            throw new Exception("Failed to load Page " + e.SourcePageType.FullName);
        }

        /// <summary>
        /// Invoked when application execution is being suspended.  Application state is saved
        /// without knowing whether the application will be terminated or resumed with the contents
        /// of memory still intact.
        /// </summary>
        /// <param name="sender">The source of the suspend request.</param>
        /// <param name="e">Details about the suspend request.</param>
        private void OnSuspending(object sender, SuspendingEventArgs e)
        {
            var deferral = e.SuspendingOperation.GetDeferral();

            // TODO: Save application state and stop any background activity
            deferral.Complete();
        }
    }
}