using Plugin.Messaging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CheckMeFinal
{
    public class EmailHandler
    {
        public async Task<bool> SendEmail(Page mainPage)
        {
            var emailSender = CrossMessaging.Current.EmailMessenger;

            if (!emailSender.CanSendEmail || !emailSender.CanSendEmailAttachments)
            {
                await mainPage.DisplayAlert("Error Encounterer", "There was an errer sending the email, make sure email permissions are set and you are connected to the internet", "Ok");
                return false;
            }
            else
            {
                await mainPage.DisplayAlert("Hmm?", emailSender.CanSendEmail.ToString(), "ok");
            }

            try
            {
                var email = new EmailMessageBuilder()
                .WithAttachment(App.Image_Path, ".jpg")
                .WithAttachment(App.Application_Path, ".pdf")
                .To("elmorya.camexp@gmail.com")
                .Subject("Test Email")
                .Body("this email was sent: " + DateTime.Today.ToLongDateString())
                .Build();

                emailSender.SendEmail(email);

                await mainPage.DisplayAlert("ok", App.Application_Path, "ok");

                return true;
            }
            catch (Exception exception)
            {
                await mainPage.DisplayAlert("Error", exception.Message, "Ok");
                return false;
            }
        }
    }
}
