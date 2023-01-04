using CoreGraphics;
using Microsoft.Maui.Controls.Handlers.Compatibility;
using Microsoft.Maui.Controls.Platform.Compatibility;

namespace TitleViewBindingExampleMauiApp;

public class CustomShellRenderer : ShellRenderer
{
    protected override IShellPageRendererTracker CreatePageRendererTracker()
    {
        return new CustomShellPageRendererTracker(this);
    }
}

public class CustomShellPageRendererTracker : ShellPageRendererTracker
{
    public CustomShellPageRendererTracker(IShellContext context)
        : base(context)
    {

    }

    protected override void UpdateTitleView()
    {
        if (ViewController == null || ViewController.NavigationItem == null)
            return;

        var titleView = Shell.GetTitleView(Page);
        var baseTitleView = Shell.GetTitleView(Page.Parent.Parent.Parent.Parent);
        var subPageTitleView = Shell.GetTitleView(Page.Parent.Parent.Parent);
        View applicableView = titleView ?? subPageTitleView ?? baseTitleView;
        if (applicableView == null)
        {
            var view = ViewController.NavigationItem.TitleView;
            ViewController.NavigationItem.TitleView = null;
            view?.Dispose();
        }
        else
        {
            var view = new CustomTitleViewContainer(applicableView);
            ViewController.NavigationItem.TitleView = view;
        }
    }
}

public class CustomTitleViewContainer : UIContainerView
{
    public CustomTitleViewContainer(View view) : base(view)
    {
        TranslatesAutoresizingMaskIntoConstraints = false;
    }

    public override CGSize IntrinsicContentSize => UILayoutFittingExpandedSize;
}