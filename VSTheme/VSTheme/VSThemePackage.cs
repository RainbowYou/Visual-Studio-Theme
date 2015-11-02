//using System;
//using System.Diagnostics;
//using System.Globalization;
//using System.Runtime.InteropServices;
//using System.ComponentModel.Design;
//using Microsoft.Win32;
//using Microsoft.VisualStudio;
//using Microsoft.VisualStudio.Shell.Interop;
//using Microsoft.VisualStudio.OLE.Interop;
//using Microsoft.VisualStudio.Shell;
using Company.VSTheme;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;
using System;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Company.VSTheme
{
    /// <summary>
    /// This is the class that implements the package exposed by this assembly.
    ///
    /// The minimum requirement for a class to be considered a valid package for Visual Studio
    /// is to implement the IVsPackage interface and register itself with the shell.
    /// This package uses the helper classes defined inside the Managed Package Framework (MPF)
    /// to do it: it derives from the Package class that provides the implementation of the 
    /// IVsPackage interface and uses the registration attributes defined in the framework to 
    /// register itself and its components with the shell.
    /// </summary>
    // This attribute tells the PkgDef creation utility (CreatePkgDef.exe) that this class is
    // a package.
    [PackageRegistration(UseManagedResourcesOnly = true)]
    // This attribute is used to register the information needed to show this package
    // in the Help/About dialog of Visual Studio.
    [InstalledProductRegistration("#110", "#112", "1.0", IconResourceID = 400)]
    [Guid(GuidList.guidVSThemePkgString)]
    [ProvideAutoLoad(UIContextGuids.NoSolution)]
    [ProvideAutoLoad(UIContextGuids.SolutionExists)]
    public sealed class VSThemePackage : Package
    {
        protected override void Initialize()
        {
            base.Initialize();

            Application.Current.MainWindow.Loaded += MainWindow_Loaded;
        }

        void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            var rWindow = (Window)sender;

            var rImageSource = BitmapFrame.Create(new Uri(@"C:\Users\煜\SkyDrive\图片\阿狸\阿狸9.jpeg"/*图片路径*/, UriKind.Absolute), 
                                                  BitmapCreateOptions.None , BitmapCacheOption.OnLoad);
            rImageSource.Freeze();

            var rImageControl = new Image()
            {
                Source = rImageSource,
                Stretch = Stretch.UniformToFill,
                HorizontalAlignment = HorizontalAlignment.Center, 
                VerticalAlignment = VerticalAlignment.Center,
            };

            Grid.SetRowSpan(rImageControl, 4);
            var rRootGrid = (Grid)rWindow.Template.FindName("RootGrid", rWindow);
            rRootGrid.Children.Insert(0, rImageControl);
        }
    }
}
