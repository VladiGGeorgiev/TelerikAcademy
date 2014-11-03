using GalaSoft.MvvmLight.Ioc;
using Giftable.Library.Services;
using Giftable.Library.Helpers;

namespace Giftable.Win8.Helpers
{
    public class IocSetup
    {
        static IocSetup()
        {
            SimpleIoc.Default.Register<INavigationService>(() => new NavigationService());
        }
    }
}
