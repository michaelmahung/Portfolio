using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CheckMeFinal
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SendDataPage : ContentPage
	{
        PDFHandler pdfHandler = new PDFHandler();
        CameraHandler camHandler = new CameraHandler();
        EmailHandler emailHandler = new EmailHandler();

		public SendDataPage ()
		{
			InitializeComponent();
		}

        void TakePhoto(object sender, EventArgs e)
        {
            camHandler.TakePicture(this, MainImage);
        }

        void SelectPhoto(object sender, EventArgs e)
        {
            camHandler.SelectPicture(this, MainImage);
        }

        void LoadPDF(object sender, EventArgs e)
        {
            pdfHandler.FillPDF(this, App.CurrentUser);
        }

        async void SendData(object sender, EventArgs e)
        {
            bool sent = await emailHandler.SendEmail(this);

            if (sent)
            {
                App.Application_Path = string.Empty;
                App.Image_Path = string.Empty;
                App.CurrentUser = null;
                await DisplayAlert("Success", "Email sent successfully!", "Ok");
                await Navigation.PushAsync(new MainPage());
            }
        }
    }
}