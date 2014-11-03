using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;

namespace Giftable.Library.Helpers
{
    public class ErrorDisplayer
    {
        private async static void ShowErrorMessage(string message)
        {
            await new MessageDialog(message).ShowAsync();
        }

        public static void ShowError(string message)
        {
            ShowErrorMessage(message);
        }
    }
}
