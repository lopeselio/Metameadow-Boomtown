using Newtonsoft.Json;
using UnityEngine;
using WalletConnectUnity.Core.Networking;

namespace WalletConnectUnity.Core.Utils
{
    public class WalletUtils
    {
        public static bool IsWalletInstalled(Wallet wallet)
        {
            if (wallet.MobileLink == null || wallet.MobileLink.StartsWith("http"))
                return false;

            var link = wallet.MobileLink;

            if (!link.EndsWith("//"))
                link = $"{link}//";

            link = $"{link}wc";

            return Linker.CanOpenURL(link);
        }

        public static void SetRecentWallet(Wallet wallet)
        {
            if (wallet == null)
                return;

            PlayerPrefs.SetString("WC_RECENT_WALLET", JsonConvert.SerializeObject(wallet));
        }

        public static bool TryGetRecentWallet(out Wallet wallet)
        {
            wallet = null;

            var recentWalletJson = PlayerPrefs.GetString("WC_RECENT_WALLET");

            if (string.IsNullOrWhiteSpace(recentWalletJson))
                return false;

            wallet = JsonConvert.DeserializeObject<Wallet>(recentWalletJson);

            return wallet != null;
        }
    }
}