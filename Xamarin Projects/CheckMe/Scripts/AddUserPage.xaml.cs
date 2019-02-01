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
	public partial class AddUserPage : ContentPage
	{
        SQLHandler handler = new SQLHandler();
        //bool userSaved;
        bool userDone;
        string[] entries = new string[5];

        public AddUserPage()
        {
            InitializeComponent();
        }

        async void SaveData(object sender, EventArgs e)
        {
            int index = -1;

            index = householdInformationPicker.SelectedIndex;

            User user = new User()
            {
                CurrentName = currentNameEntry.Text,
                BirthName = birthNameEntry.Text,
                Email = emailEntry.Text,
                BirthPlace = birthPlaceEntry.Text,
                PhoneNumber = phoneNumberEntry.Text,
                HouseholdInformation = (User.houseHoldInformation)index,
                BirthDate = birthDateEntry.Date.ToString()
            };

            entries[0] = user.CurrentName;
            entries[1] = user.BirthName;
            entries[2] = user.Email;
            entries[3] = user.BirthPlace;
            entries[4] = user.PhoneNumber;

            if (CheckIfStringsAreFilled() && !userDone)
            {
                userDone = true;
                //SaveUserLocally(user);
                handler.AddUserToTable(user);
                await DisplayAlert("Success", "User Created Successfully!", "Ok");
                UnsetFields();
                await Navigation.PushAsync(new MainPage());
                return;
            } else if (userDone)
            {
                await DisplayAlert("Failure", "User data has already been saved, please return to the previous page", "Back");
                return;
            }
            await DisplayAlert("Failure", "Failed to Create User, please check that all fields are filled", "Back");
        }

       /* async void SaveUserLocally(User user)
        {
            if (!userSaved)
            {
                userSaved = true;

                using (SQLite.SQLiteConnection connection = new SQLite.SQLiteConnection(App.SQL_PATH))
                {
                    connection.CreateTable<User>();
                    var numberOfRows = connection.Insert(user);

                    if (numberOfRows > 0)
                    {
                        userSaved = true;
                    }
                }

                await DisplayAlert("Success", "User information has been successfully created!", "Back");
                await Navigation.PushAsync(new MainPage());
            }
        }*/

        void UnsetFields()
        {
            currentNameEntry.Text = string.Empty;
            birthNameEntry.Text = string.Empty;
            emailEntry.Text = string.Empty;
            birthPlaceEntry.Text = string.Empty;
            phoneNumberEntry.Text = string.Empty;
        }

        bool CheckIfStringsAreFilled()
        {
            foreach (string str in entries)
            {
                if (string.IsNullOrEmpty(str))
                {
                    return false;
                }
            }
            return true;
        }
    }
}