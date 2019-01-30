using System;
using System.Collections.Generic;
using System.Text;
using Plugin.Messaging;
using Plugin.Media.Abstractions;
using Plugin.Media;
using Xamarin.Forms;

namespace CheckMeFinal
{
    public class CameraHandler
    {
        public async void TakePicture(Page mainPage, Image image)
        {
            if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
            {
                await mainPage.DisplayAlert("No Camera", ":( No camera available.", "OK");
                return;
            }

            var file = await CrossMedia.Current.TakePhotoAsync(
                new StoreCameraMediaOptions
                {
                    PhotoSize = PhotoSize.Medium,
                    SaveToAlbum = true,
                    Name = "photo"
                });

            if (file == null)
                return;

            await mainPage.DisplayAlert("Saved Image", "Image Saved Successfully", "OK");

            image.Source = ImageSource.FromStream(() =>
            {
                var stream = file.GetStream();
                App.Image_Path = file.Path;
                file.Dispose();
                return stream;
            });
        }

        public async void SelectPicture(Page mainPage, Image image)
        {
            if (!CrossMedia.Current.IsPickPhotoSupported)
            {
                await mainPage.DisplayAlert("Error opening gallery", "Image Gallery is not Accessable", "Ok");
                return;
            }

            var file = await CrossMedia.Current.PickPhotoAsync(
                new PickMediaOptions
                {
                    PhotoSize = PhotoSize.Medium
                });

            if (file == null)
                return;

            image.Source = ImageSource.FromStream(() =>
            {
                var stream = file.GetStream();
                App.Image_Path = file.Path;
                file.Dispose();
                return stream;
            });
        }
    }
}
