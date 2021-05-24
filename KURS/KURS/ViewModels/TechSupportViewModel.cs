using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Xamarin.Essentials;

namespace KURS.ViewModels
{
    class TechSupportViewModel : BaseViewModel
    {
        private string text;
        public string Text
        {
            get => text;
            set => SetProperty(ref text, value);
        }
        public Command SendEmail { get; }
        private async void SendEmailExecuted()
        {
            var message = new EmailMessage
            {
                Subject = "Koshelek Issue",
                Body = text,
                To = new List<string> { "anton_lityagin@mail.ru" },
                //Cc = ccRecipients,
                //Bcc = bccRecipients
            };
            await Email.ComposeAsync(message);
        }
        public TechSupportViewModel()
        {
            SendEmail = new Command(SendEmailExecuted);
        }
    }
}
