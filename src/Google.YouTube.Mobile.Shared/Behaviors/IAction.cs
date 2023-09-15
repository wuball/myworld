using Xamarin.Forms.Internals;

namespace Google.YouTube.Behaviors
{
    [Preserve(AllMembers = true)]
    public interface IAction
    {
        bool Execute(object sender, object parameter);
    }
}