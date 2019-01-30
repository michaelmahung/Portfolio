using Syncfusion.Pdf.Parsing;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using Xamarin.Forms;

namespace CheckMeFinal
{
    public class PDFHandler
    {
        //add logic for loading and otherwise handling pdf here
        public async void FillPDF(Page mainPage, User user)
        {
            try
            {
                Stream docStream = typeof(App).GetTypeInfo().Assembly.GetManifestResourceStream("CheckMeFinal.client_application_forms.pdf");

                PdfLoadedDocument loadedDocument = new PdfLoadedDocument(docStream);

                PdfLoadedForm form = loadedDocument.Form;

                (form.Fields[0] as PdfLoadedTextBoxField).Text = user.CurrentName;
                (form.Fields[1] as PdfLoadedTextBoxField).Text = user.BirthName;
                (form.Fields[2] as PdfLoadedTextBoxField).Text = user.BirthDate;
                (form.Fields[3] as PdfLoadedTextBoxField).Text = user.BirthPlace;
                (form.Fields[4] as PdfLoadedTextBoxField).Text = user.PhoneNumber;
                (form.Fields[5] as PdfLoadedTextBoxField).Text = user.Email;
                (form.Fields[11] as PdfLoadedTextBoxField).Text = user.CurrentName;
                (form.Fields[12] as PdfLoadedTextBoxField).Text = DateTime.Today.ToShortDateString();

                (form.Fields[CheckIndex(user)] as PdfLoadedCheckBoxField).Checked = true;

                var newName = user.CurrentName.Replace(" ", string.Empty);

                var savePath = Path.Combine(App.Default_Path.ToString(), newName + "application.pdf");

                await mainPage.DisplayAlert("Path", savePath, "Ok");

                FileStream file = File.Create(savePath);

                loadedDocument.Save(file);
                loadedDocument.Close(true);

                App.Application_Path = savePath;

                file.Dispose();
                docStream.Dispose();

                return;
            }
            catch (Exception excep)
            {
                await mainPage.DisplayAlert("Error", excep.Message, "Ok");
                return;
            }
        }

        int CheckIndex(User user)
        {
            switch (user.HouseholdInformation)
            {
                case User.houseHoldInformation.Alone:
                    return 6;
                case User.houseHoldInformation.Spouse_Partner:
                    return 7;
                case User.houseHoldInformation.Kids:
                    return 8;
                case User.houseHoldInformation.Parents:
                    return 9;
                case User.houseHoldInformation.Other:
                    return 10;
                default:
                    return 6;
            }
        }
    }
}
