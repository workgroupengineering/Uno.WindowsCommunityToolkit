// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

#if HAS_UNO_WASM
// #define HAS_MONACO
#endif

using System;
using System.Threading.Tasks;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media;
using Windows.System.Threading;
using Windows.UI;

#if HAS_MONACO
using Monaco;
using Monaco.Editor;
using Monaco.Helpers;
#endif

namespace CommunityToolkit.WinUI.SampleApp.Controls
{
    public sealed partial class XamlCodeEditor : UserControl
    {
        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register(nameof(Text), typeof(string), typeof(XamlCodeEditor), new PropertyMetadata(string.Empty));

#if HAS_MONACO
        private ThemeListener _themeListener = new ThemeListener();
#endif

        public XamlCodeEditor()
        {
            this.InitializeComponent();

#if HAS_MONACO
            _errorIconStyle = new CssGlyphStyle(XamlCodeRenderer)
            {
                GlyphImage = new global::System.Uri("ms-appx-web:///Icons/Error.png")
            };
#endif
        }

        public async Task ResetPosition()
        {
#if HAS_MONACO
            await XamlCodeRenderer.RevealPositionAsync(new Position(1, 1));
#endif
        }

        public async void ReportError(XamlExceptionRange error)
        {
#if HAS_MONACO
            XamlCodeRenderer.Options.GlyphMargin = true;

            var range = new Monaco.Range(error.StartLine, 1, error.EndLine, await XamlCodeRenderer.GetModel().GetLineMaxColumnAsync(error.EndLine));

            // Highlight Error Line
            XamlCodeRenderer.Decorations.Add(new IModelDeltaDecoration(
                range,
                new IModelDecorationOptions() { IsWholeLine = true, ClassName = ErrorStyle, HoverMessage = new string[] { error.Message }.ToMarkdownString() }));

            // Show Glyph Icon
            XamlCodeRenderer.Decorations.Add(new IModelDeltaDecoration(
                range,
                new IModelDecorationOptions() { IsWholeLine = true, GlyphMarginClassName = _errorIconStyle, GlyphMarginHoverMessage = new string[] { error.Message }.ToMarkdownString() }));
#endif
        }

        public void ClearErrors()
        {
#if HAS_MONACO
            XamlCodeRenderer.Decorations.Clear();
            XamlCodeRenderer.Options.GlyphMargin = false;
#endif
        }

        public void ResetTimer()
        {
            TimeSampleEditedFirst = TimeSampleEditedLast = DateTime.MinValue;
        }

        private void XamlCodeRenderer_Loading(object sender, RoutedEventArgs e)
        {
#if HAS_MONACO
        XamlCodeRenderer.Options.Folding = true;
#endif
        }

#if HAS_MONACO
        private void XamlCodeRenderer_InternalException(CodeEditor sender, Exception args)
        {
            TrackingManager.TrackException(args);

            // If you hit an issue here, please report repro steps along with all the info from the Exception object.
#if DEBUG
            // Temporary new version of Monaco UWP throws a few expected exceptions.
            // System.Diagnostics.Debugger.Break();
#endif
        }

        private void XamlCodeRenderer_KeyDown(Monaco.CodeEditor sender, Monaco.Helpers.WebKeyEventArgs args)
        {
            // Handle Shortcuts.
            // Ctrl+Enter or F5 Update // TODO: Do we need this in the app handler too? (Thinking no)
            if ((args.KeyCode == 13 && args.CtrlKey) ||
                 args.KeyCode == 116)
            {
                UpdateRequested?.Invoke(this, EventArgs.Empty);

                // Eat key stroke
                args.Handled = true;
            }

            // Ignore as a change to the document if we handle it as a shortcut above or it's a special char.
            if (!args.Handled && Array.IndexOf(NonCharacterCodes, args.KeyCode) == -1)
            {
                // TODO: Mark Dirty here if we want to prevent overwrites.

                // Setup Time for Auto-Compile
                this._autoCompileTimer?.Cancel(); // Stop Old Timer

                // Create Compile Timer
                this._autoCompileTimer = ThreadPoolTimer.CreateTimer(
                    e =>
                    {
                        UpdateRequested?.Invoke(this, EventArgs.Empty);

                        if (TimeSampleEditedFirst == DateTime.MinValue)
                        {
                            TimeSampleEditedFirst = DateTime.Now;
                        }

                        TimeSampleEditedLast = DateTime.Now;
                    }, TimeSpan.FromSeconds(0.5));
            }
        }
#endif

        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        public DateTime TimeSampleEditedFirst { get; private set; } = DateTime.MinValue;

        public DateTime TimeSampleEditedLast { get; private set; } = DateTime.MinValue;

#if HAS_MONACO
        private CssLineStyle ErrorStyle
        {
            get => _themeListener.CurrentTheme.Equals(ApplicationTheme.Light) ?
                new CssLineStyle(XamlCodeRenderer) { BackgroundColor = new SolidColorBrush(Color.FromArgb(0x00, 0xFF, 0xD6, 0xD6)) } :
                new CssLineStyle(XamlCodeRenderer) { BackgroundColor = new SolidColorBrush(Color.FromArgb(0x00, 0x66, 0x00, 0x00)) };
        }

        private CssGlyphStyle _errorIconStyle;
#endif

        private ThreadPoolTimer _autoCompileTimer;

        public event EventHandler UpdateRequested;

        private static readonly int[] NonCharacterCodes = new int[]
        {
            // Modifier Keys
            16, 17, 18, 20, 91,

            // Esc / Page Keys / Home / End / Insert
            27, 33, 34, 35, 36, 45,

            // Arrow Keys
            37, 38, 39, 40,

            // Function Keys
            112, 113, 114, 115, 116, 117, 118, 119, 120, 121, 122, 123
        };
    }
}