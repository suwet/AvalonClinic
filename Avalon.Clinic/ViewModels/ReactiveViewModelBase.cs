using ReactiveUI;

namespace Avalon.Clinic.ViewModels
{
    public class ReactiveViewModelBase : ReactiveUI.ReactiveObject, IActivatableViewModel {
        public ViewModelActivator Activator => new ViewModelActivator();
    }
}
