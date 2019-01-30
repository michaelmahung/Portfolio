using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CheckMeFinal
{
    public partial class MainPage : ContentPage
    {
        SQLHandler handler = new SQLHandler();

        public MainPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            handler.GetListViewFromTable(userListView);
        }

        void ToolbarItem_Activated(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AddUserPage());
        }

        async void OnSelected(object sender, ItemTappedEventArgs e)
        {
            App.CurrentUser = null;
            User tempUser = null;

            tempUser = e.Item as User;

            bool selection = await DisplayAlert(tempUser.CurrentName, "What would you like to do with " + tempUser.CurrentName + "?", "Send User Application", "Delete User");

            if (selection)
            {
                App.CurrentUser = tempUser;
                await Navigation.PushAsync(new SendDataPage());
            } else
            {
                bool delete = await DisplayAlert("Verify", "Are you sure you want to delete user " + tempUser.CurrentName + "?", "Yes", "No");

                if (delete)
                {
                    if (App.CurrentUser == tempUser)
                    {
                        App.CurrentUser = null;
                    }

                    handler.DeleteUserFromTable(tempUser);

                    await DisplayAlert("Success", "User successfully deleted", "Ok");

                    handler.GetListViewFromTable(userListView);
                }
            }

            userListView.SelectedItem = null;
        }
    }
}
