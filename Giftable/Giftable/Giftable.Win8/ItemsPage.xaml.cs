using Parse;
using Windows.Media.Capture;
using Windows.Storage;
using Windows.Storage.AccessCache;
using Windows.Storage.Streams;
using System;
using System.Collections.Generic;
using System.IO;
using Giftable.Library.ViewModel;
using Windows.Foundation;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
// The Items Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234233
using Giftable.Win8.Services;

namespace Giftable.Win8
{
    /// <summary>
    /// A page that displays a collection of item previews.  In the Split Application this page
    /// is used to display and select one of the available groups.
    /// </summary>
    public sealed partial class ItemsPage : Giftable.Win8.Common.LayoutAwarePage
    {
        public ItemsPage()
        {
            this.InitializeComponent();
            this.NavigationCacheMode =
                Windows.UI.Xaml.Navigation.NavigationCacheMode.Enabled;
        }

        /// <summary>
        /// Populates the page with content passed during navigation.  Any saved state is also
        /// provided when recreating a page from a prior session.
        /// </summary>
        /// <param name="navigationParameter">The parameter value passed to
        /// <see cref="Frame.Navigate(Type, Object)"/> when this page was initially requested.
        /// </param>
        /// <param name="pageState">A dictionary of state preserved by this page during an earlier
        /// session.  This will be null the first time a page is visited.</param>
        protected override void LoadState(Object navigationParameter, Dictionary<String, Object> pageState)
        {
            // TODO: Create an appropriate data model for your problem domain to replace the sample data
            

        }

        /// <summary>
        /// Invoked when an item is clicked.
        /// </summary>
        /// <param name="sender">The GridView (or ListView when the application is snapped)
        /// displaying the item clicked.</param>
        /// <param name="e">Event data that describes the item clicked.</param>
        void ItemView_ItemClick(object sender, ItemClickEventArgs e)
        {
            var itemsPageViewModel = this.DataContext as ItemsPageViewModel;
            if (itemsPageViewModel != null)
                itemsPageViewModel.SelectedUserCommand.Execute(e.ClickedItem);
        }


        private async void BtnAvatar_OnClick(object sender, RoutedEventArgs e)
        {
            var popupMenu = new PopupMenu();

            popupMenu.Commands.Add(new UICommand("From File", AvatarFromFile));
            popupMenu.Commands.Add(new UICommand("From Camera", AvatarFromCamera));

            var button = (Button)sender;
            var transform = button.TransformToVisual(this);
            var point = transform.TransformPoint(new Point(45, -10));
            
            await popupMenu.ShowAsync(point);
        }

        private async void AvatarFromCamera(IUICommand command)
        {
            var ui = new CameraCaptureUI();
            ui.PhotoSettings.CroppedAspectRatio = new Size(4, 3);

            var file = await ui.CaptureFileAsync(CameraCaptureUIMode.Photo);

            if (file != null)
            {
                IRandomAccessStream fileStream = await file.OpenAsync(Windows.Storage.FileAccessMode.Read);
                var parseObject = new ParseFile(Guid.NewGuid() + ".jpg", fileStream.AsStreamForRead());
                await parseObject.SaveAsync();
                AssigneAvatarToModel(parseObject.Url.AbsoluteUri);
            }
        }
        
        private async void AvatarFromFile(IUICommand command)
        {
            var openPicker = new Windows.Storage.Pickers.FileOpenPicker();

            openPicker.FileTypeFilter.Add(".jpg");
            openPicker.FileTypeFilter.Add(".png");

            var file = await openPicker.PickSingleFileAsync();
            if (file != null)
            {
                var falKey = StorageApplicationPermissions.FutureAccessList.Add(file);

                var fileStream = await file.OpenAsync(FileAccessMode.Read);

                var parseObject = new ParseFile(Guid.NewGuid() + ".jpg", fileStream.AsStreamForRead());
                await parseObject.SaveAsync();
                AssigneAvatarToModel(parseObject.Url.AbsoluteUri);
            }
        }

        private async void AssigneAvatarToModel(string fileUri)
                    {
            DataService service = new DataService();
            var response = await service.UploadAvatar(fileUri);
            if (response.IsSuccessStatusCode)
            {
                var itemsPageViewModel = this.DataContext as ItemsPageViewModel;
                if (itemsPageViewModel != null)
                {
                    itemsPageViewModel.Avatar = fileUri;
                }
            }
        }

        private void Wishlist_OnItemClick(object sender, ItemClickEventArgs e)
        {
            
        }
    }
}
