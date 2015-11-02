using Microsoft.VisualStudio.Text.Classification;
using Microsoft.VisualStudio.Text.Editor;
using Microsoft.VisualStudio.Utilities;
using System;
using System.ComponentModel.Composition;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Threading;

namespace Company.VSTheme
{
    [Export(typeof(IWpfTextViewCreationListener))]
    [ContentType("Text")]
    [ContentType("BuildOutput")]
    [TextViewRole(PredefinedTextViewRoles.Document)]
    class Listener : IWpfTextViewCreationListener
    {
        [Import]
        IEditorFormatMapService EditorFormatMapService = null;

        public void TextViewCreated(IWpfTextView rpTextView)
        {
            new EditorBackground(rpTextView);

            //去掉断点边栏的背景
            var rProperties = EditorFormatMapService.GetEditorFormatMap(rpTextView).GetProperties("Indicator Margin");
            rProperties["BackgroundColor"] = Colors.Transparent;
            rProperties["Background"] = Brushes.Transparent;
        }
    }

    class EditorBackground
    {
        IWpfTextView r_TextView;
        ContentControl r_Control;
        Grid r_ParentGrid;
        Canvas r_ViewStack;

        public EditorBackground(IWpfTextView rpTextView)
        {
            r_TextView = rpTextView;
            r_Control = (ContentControl)r_TextView;
            r_TextView.Background = Brushes.Transparent;
            r_TextView.BackgroundBrushChanged += TextView_BackgroundBrushChanged;
            r_TextView.Closed += TextView_Closed;
            r_Control.Loaded += TextView_Loaded;
        }

        void MakeBackgroundTransparent()
        {
            r_TextView.Background = Brushes.Transparent;
            r_ViewStack.Background = Brushes.Transparent;
            r_ParentGrid.ClearValue(Grid.BackgroundProperty);
        }

        void TextView_Loaded(object sender, RoutedEventArgs e)
        {
            if (r_ParentGrid == null)
                r_ParentGrid = (Grid)r_Control.Parent;
            if (r_ViewStack == null)
                r_ViewStack = (Canvas)r_Control.Content;
            MakeBackgroundTransparent();
        }

        void TextView_BackgroundBrushChanged(object sender, BackgroundBrushChangedEventArgs e)
        {
            r_Control.Dispatcher.BeginInvoke(new Action(() =>
            {
                while (r_ParentGrid.Background != null)
                    MakeBackgroundTransparent();
            }), DispatcherPriority.Render);
        }

        void TextView_Closed(object sender, EventArgs e)
        {
            //清除委托，以防内存泄露
            r_TextView.Closed -= TextView_Closed;
            r_TextView.BackgroundBrushChanged -= TextView_BackgroundBrushChanged;
        }
    }
}
