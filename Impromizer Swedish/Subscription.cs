using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Windows.Services.Store;


namespace Headline_Randomizer
{
    class Subscription
    {
        public StoreContext context = null;
        private StoreProduct subscriptionStoreProduct;

        // Assign this variable to the Store ID of your subscription add-on.
        public static string subscriptionStoreId = "9N66GC16QH94";
        
        public async Task CheckAndSetVersion()
        {
            if (context == null)
            {
                context = StoreContext.GetDefault();
                // If your app is a desktop app that uses the Desktop Bridge, you
                // may need additional code to configure the StoreContext object.
                // For more info, see https://aka.ms/storecontext-for-desktop.
                Swedish.IInitializeWithWindow initWindow = (Swedish.IInitializeWithWindow)(object)context;
                initWindow.Initialize(System.Diagnostics.Process.GetCurrentProcess().MainWindowHandle);
            }

            bool userOwnsSubscription = await CheckIfUserHasSubscriptionAsync();
            if (userOwnsSubscription)
            {
                Common.fullVersion = true;
            }

            Common.SetVersion();
        }

        public async Task OpenBuyNowDialogue()
        {
            if (context == null)
            {
                context = StoreContext.GetDefault();
                // If your app is a desktop app that uses the Desktop Bridge, you
                // may need additional code to configure the StoreContext object.
                // For more info, see https://aka.ms/storecontext-for-desktop.
                Swedish.IInitializeWithWindow initWindow = (Swedish.IInitializeWithWindow)(object)context;
                initWindow.Initialize(System.Diagnostics.Process.GetCurrentProcess().MainWindowHandle);
            }

            // Get the StoreProduct that represents the subscription add-on.
            subscriptionStoreProduct = await GetSubscriptionProductAsync();
            if (subscriptionStoreProduct == null)
            {
                return;
            }

            // Prompt the customer to purchase the subscription.
            await PromptUserToPurchaseAsync();
        }

        private async Task<bool> CheckIfUserHasSubscriptionAsync()
        {
            StoreAppLicense appLicense = await context.GetAppLicenseAsync();

            // Check if the customer has the rights to the subscription.
            foreach (var addOnLicense in appLicense.AddOnLicenses)
            {
                StoreLicense license = addOnLicense.Value;
                if (license.SkuStoreId.StartsWith(subscriptionStoreId))
                {
                    if (license.IsActive)
                    {
                        // The expiration date is available in the license.ExpirationDate property.
                        return true;
                    }
                }
            }

            // The customer does not have a license to the subscription.
            return false;
        }

        private async Task<StoreProduct> GetSubscriptionProductAsync()
        {
            // Load the sellable add-ons for this app and check if the trial is still 
            // available for this customer. If they previously acquired a trial they won't 
            // be able to get a trial again, and the StoreProduct.Skus property will 
            // only contain one SKU.

            StoreProductQueryResult result =
            await context.GetAssociatedStoreProductsAsync(new string[] { "Durable" });

            if (result.ExtendedError != null)
            {
                System.Diagnostics.Debug.WriteLine("Something went wrong while getting the add-ons. " +
                    "ExtendedError:" + result.ExtendedError);

                return null;
            }

            // Look for the product that represents the subscription.

            foreach (var item in result.Products)
            {
                StoreProduct product = item.Value;
                if (product.StoreId == subscriptionStoreId)
                {
                    return product;
                }
            }

            System.Diagnostics.Debug.WriteLine("The subscription was not found.");
            return null;
        }

        public async Task PromptUserToPurchaseAsync()
        {
            // Request a purchase of the subscription product. If a trial is available it will be offered 
            // to the customer. Otherwise, the non-trial SKU will be offered.
            StorePurchaseResult result = await subscriptionStoreProduct.RequestPurchaseAsync();

            // Capture the error message for the operation, if any.
            string extendedError = string.Empty;
            if (result.ExtendedError != null)
            {
                extendedError = result.ExtendedError.Message;
            }

            switch (result.Status)
            {
                case StorePurchaseStatus.Succeeded:
                    Common.fullVersion = true;
                    Common.SetVersion();
                    break;

                case StorePurchaseStatus.NotPurchased:
                    System.Diagnostics.Debug.WriteLine("The purchase did not complete. " +
                        "The customer may have cancelled the purchase. ExtendedError: " + extendedError);
                    break;

                case StorePurchaseStatus.ServerError:
                case StorePurchaseStatus.NetworkError:
                    System.Diagnostics.Debug.WriteLine("The purchase was unsuccessful due to a server or network error. " +
                        "ExtendedError: " + extendedError);
                    break;

                case StorePurchaseStatus.AlreadyPurchased:
                    System.Diagnostics.Debug.WriteLine("The customer already owns this subscription." +
                            "ExtendedError: " + extendedError);
                    Common.fullVersion = true;
                    Common.SetVersion();
                    break;
            }
        }
    }
}
