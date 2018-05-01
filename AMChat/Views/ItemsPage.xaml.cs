using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace AMChat
{
    public partial class ItemsPage : ContentPage
    {
        ItemsViewModel viewModel;

        public ItemsPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new ItemsViewModel();

        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            viewModel.LoadItemsCommand.Execute(null);
            ContentListViewScrollToEnd();
        }

        void ContentListViewScrollToEnd()
        {
            if (viewModel.Items.Count > 0)
            {
                Device.BeginInvokeOnMainThread(() => {
                    MsgList.ScrollTo(viewModel.Items[viewModel.Items.Count - 1], ScrollToPosition.End, false);
                });
            }
           
        }

        void ScrollUp(Object sender, EventArgs eventArgs)
        {

            // account for keyboard and input field
            MsgList.HeightRequest = MsgList.Height * .35;

            OnPropertyChanged("MsgList.HeightRequest");

            ContentListViewScrollToEnd();
            ChatMessage.HeightRequest = 65;

        }

        void ScrollDown(Object sender, EventArgs eventArgs)
        {
            MsgList.HeightRequest = -1;
            ChatMessage.HeightRequest = -1;
        }


        void Handle_ItemSelected(Object sender, EventArgs e)
        {
            ((ListView)sender).SelectedItem = null; // deselect the row
        }


        void SendMessage(Object sender, EventArgs e)
        {

            Item newItem = new Item { Id = Guid.NewGuid().ToString(), ChatText = "", ChatUserImage = null, IsChatViewer = "true" };

            if (ChatMessage.Text != null && ChatMessage.Text.Length > 0)
            {

                // Add the new text message
                newItem.ChatText = ChatMessage.Text;
                if (viewModel.Items[viewModel.Items.Count - 1].IsChatViewer.Equals("true"))
                {
                    newItem.ChatUserImage = "kitten_two.png";
                    newItem.IsChatViewer = "false";
                }
                else
                {
                    newItem.ChatUserImage = "kitten_one.png";
                    newItem.IsChatViewer = "true";
                }

                // clear the text input field and reset the form
                ChatMessage.Text = null;
                MsgList.HeightRequest = -1;

                //add the new text, refresh the display, and scroll up to show the new item
                viewModel.Items.Add(newItem);
                Task.Delay(100);
                MsgList.ItemsSource = viewModel.Items;
                OnPropertyChanged("MsgList");

                ContentListViewScrollToEnd();
            }
        }
    }
}
