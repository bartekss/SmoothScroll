using Microsoft.VisualStudio.Text.Editor;
using System.Windows.Input;

namespace SmoothScroll
{
    internal sealed class SmoothScrollMouseProcessor : MouseProcessorBase
    {
        IWpfTextView _wpfTextView;

        internal SmoothScrollMouseProcessor(IWpfTextView wpfTextView)
        {
            _wpfTextView = wpfTextView;
        }

        public override void PreprocessMouseWheel(MouseWheelEventArgs e)
        {
            var direction = e.Delta >= 0 ? ScrollDirection.Up : ScrollDirection.Down;

            _wpfTextView.ViewScroller.ScrollViewportVerticallyByLine(direction);
            e.Handled = true;
        }
    }
}
