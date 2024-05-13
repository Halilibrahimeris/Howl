using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;
using System;
public class Admob : MonoBehaviour
{
    [SerializeField] public const string _bannerId = "ca-app-pub-4301289208872539/4922690042";
    [SerializeField] public const string _interstitialId = "ca-app-pub-4301289208872539/1721811639";
    [SerializeField] private const string _rewardedId = "ca-app-pub-4301289208872539/2804912722";

    private BannerView _bannerView;
    private InterstitialAd _interstitialAd;
    private RewardedAd _rewardedAd;

    public Hint hint;

    private void Start()
    {
        MobileAds.Initialize(initStatus => { });
        RequestBanner();
        RequestInterstitial();
        RequestRewarded();
    }

    private void RequestBanner()
    {
        _bannerView = new BannerView(_bannerId, AdSize.Banner, AdPosition.Bottom);
        AdRequest request = new AdRequest.Builder().Build();
        _bannerView.LoadAd(request);
    }

    private void RequestInterstitial()
    {
        _interstitialAd = new InterstitialAd(_interstitialId);
        _interstitialAd.OnAdClosed += HandleOnAdClosed;
        AdRequest request = new AdRequest.Builder().Build();
        _interstitialAd.LoadAd(request);
    }

    public void DisplayInterstitialAd()
    {
        if (_interstitialAd.IsLoaded())
            _interstitialAd.Show();
    }

    public void HandleOnAdClosed(object sender, EventArgs args)
    {
        _interstitialAd.Destroy();
        RequestInterstitial();
    }

    // REWARDED

    private void RequestRewarded()
    {
        _rewardedAd = new RewardedAd(_rewardedId);
        _rewardedAd.OnUserEarnedReward += HandleUserEarnedReward;
        _rewardedAd.OnAdClosed += HandleRewardedAdClosed;
        AdRequest request = new AdRequest.Builder().Build();
        _rewardedAd.LoadAd(request);
    }

    public void DisplayRewardedAd()
    {
        if (_rewardedAd.IsLoaded() && SaveManager.Instance.saveData.HintCount == 0)
        {
            _rewardedAd.Show();
        }

    }

    public void HandleUserEarnedReward(object sender, EventArgs args)
    {
        hint.AdsHint();
    }

    public void HandleRewardedAdClosed(object sender, EventArgs args)
    {
        RequestRewarded();
    }

    private void OnDestroy()
    {
        _rewardedAd.OnUserEarnedReward -= HandleUserEarnedReward;
        _rewardedAd.OnAdClosed -= HandleRewardedAdClosed;
    }
}
