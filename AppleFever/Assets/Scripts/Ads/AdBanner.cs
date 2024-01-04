using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds;
using GoogleMobileAds.Api;

public class AdBanner : MonoBehaviour
{
        // These ad units are configured to always serve test ads.
    #if UNITY_ANDROID
        //private string _adUnitId = "ca-app-pub-3836086117526701/3150522929";
        //El de prueba
        private string _adUnitId = "ca-app-pub-3940256099942544/6300978111";
#elif UNITY_IPHONE
      private string _adUnitId = "ca-app-pub-3940256099942544/2934735716";
#else
      private string _adUnitId = "unused";
#endif

    BannerView _bannerView;


    void Start()
    {
        MobileAds.Initialize((InitializationStatus initStatus) =>
        {
            // This callback is called once the MobileAds SDK is initialized.
            CreateBannerView();
        });
        
    }
    
    /// <summary>
    /// Creates a 320x50 banner view at top of the screen.
    /// </summary>
    public void CreateBannerView()
    {
        Debug.Log("Creating banner view");

        // If we already have a banner, destroy the old one.
        if (_bannerView != null)
        {
            _bannerView.Destroy();
        }

        AdSize adaptiveSize =
                AdSize.GetCurrentOrientationAnchoredAdaptiveBannerAdSizeWithWidth(AdSize.FullWidth);

        // Create a banner at bottom of the screen
        _bannerView = new BannerView(_adUnitId, adaptiveSize, AdPosition.Bottom);

        // Request and display an ad
        var adRequest = new AdRequest();
        _bannerView.LoadAd(adRequest);
    }
}
