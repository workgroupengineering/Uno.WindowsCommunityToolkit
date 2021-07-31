// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.Linq;
using System.Threading.Tasks;
using Microsoft.Toolkit.Uwp;
using Microsoft.Toolkit.Uwp.UI;
using Microsoft.Toolkit.Uwp.UI.Controls;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.UnitTesting.AppContainer;
using Windows.Foundation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Markup;

namespace UnitTests.UWP.UI.Controls
{
    public partial class Test_ConstrainedBox : VisualUITestBase
    {
        [TestCategory("ConstrainedBox")]
        [TestMethod]
        public async Task Test_ConstrainedBox_Normal_MultipleX()
        {
            await App.DispatcherQueue.EnqueueAsync(async () =>
            {
                var treeRoot = XamlReader.Load(@"<Page
    xmlns=""http://schemas.microsoft.com/winfx/2006/xaml/presentation""
    xmlns:x=""http://schemas.microsoft.com/winfx/2006/xaml""
    xmlns:controls=""using:Microsoft.Toolkit.Uwp.UI.Controls"">
    <Grid x:Name=""ParentGrid"" Width=""200"" Height=""200"">
      <controls:ConstrainedBox x:Name=""ConstrainedBox"" MultipleX=""32""
                               HorizontalAlignment=""Stretch"" VerticalAlignment=""Stretch"">
        <Border HorizontalAlignment=""Stretch"" VerticalAlignment=""Stretch"" Background=""Red""/>
      </controls:ConstrainedBox>
    </Grid>
</Page>") as FrameworkElement;

                Assert.IsNotNull(treeRoot, "Could not load XAML tree.");

                // Initialize Visual Tree
                await SetTestContentAsync(treeRoot);

                var grid = treeRoot.FindChild("ParentGrid") as Grid;

                var panel = treeRoot.FindChild("ConstrainedBox") as ConstrainedBox;

                Assert.IsNotNull(panel, "Could not find ConstrainedBox in tree.");

                // Force Layout calculations
                panel.UpdateLayout();

                var child = panel.Content as Border;

                Assert.IsNotNull(child, "Could not find inner Border");

                // Check Size
                Assert.AreEqual(child.ActualWidth, 192);
                Assert.AreEqual(child.ActualHeight, 200);

                // Check inner Positioning, we do this from the Grid as the ConstainedBox also modifies its own size
                // and is hugging the child.
                var position = grid.CoordinatesTo(child);

                Assert.AreEqual(position.X, 4);
                Assert.AreEqual(position.Y, 0);
            });
        }

        [TestCategory("ConstrainedBox")]
        [TestMethod]
        public async Task Test_ConstrainedBox_Normal_MultipleY()
        {
            await App.DispatcherQueue.EnqueueAsync(async () =>
            {
                var treeRoot = XamlReader.Load(@"<Page
    xmlns=""http://schemas.microsoft.com/winfx/2006/xaml/presentation""
    xmlns:x=""http://schemas.microsoft.com/winfx/2006/xaml""
    xmlns:controls=""using:Microsoft.Toolkit.Uwp.UI.Controls"">
    <Grid x:Name=""ParentGrid"" Width=""200"" Height=""200"">
      <controls:ConstrainedBox x:Name=""ConstrainedBox"" MultipleY=""32""
                               HorizontalAlignment=""Stretch"" VerticalAlignment=""Stretch"">
        <Border HorizontalAlignment=""Stretch"" VerticalAlignment=""Stretch"" Background=""Red""/>
      </controls:ConstrainedBox>
    </Grid>
</Page>") as FrameworkElement;

                Assert.IsNotNull(treeRoot, "Could not load XAML tree.");

                // Initialize Visual Tree
                await SetTestContentAsync(treeRoot);

                var grid = treeRoot.FindChild("ParentGrid") as Grid;

                var panel = treeRoot.FindChild("ConstrainedBox") as ConstrainedBox;

                Assert.IsNotNull(panel, "Could not find ConstrainedBox in tree.");

                // Force Layout calculations
                panel.UpdateLayout();

                var child = panel.Content as Border;

                Assert.IsNotNull(child, "Could not find inner Border");

                // Check Size
                Assert.AreEqual(child.ActualWidth, 200);
                Assert.AreEqual(child.ActualHeight, 192);

                // Check inner Positioning, we do this from the Grid as the ConstainedBox also modifies its own size
                // and is hugging the child.
                var position = grid.CoordinatesTo(child);

                Assert.AreEqual(position.X, 0);
                Assert.AreEqual(position.Y, 4);
            });
        }
    }
}