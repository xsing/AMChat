using System;
using System.Windows.Input;

using Xamarin.Forms;

namespace AMChat
{
    public class AboutViewModel : BaseViewModel
    {
        public AboutViewModel()
        {
            Title = "About Agendamate";

            OpenWebCommand = new Command(() => Device.OpenUri(new Uri("https://agendamate.org")));
        }

        public ICommand OpenWebCommand { get; }
    }
}
