using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds;
using GoogleMobileAds.Api;
using System;

public class AdmobManager : MonoBehaviour
{
    RewardBasedVideoAd rewardBasedVideoAd;

    public void Start()
    {
        rewardBasedVideoAd = RewardBasedVideoAd.Instance;

        rewardBasedVideoAd.OnAdClosed += HandleOnAdClosed;
        rewardBasedVideoAd.OnAdFailedToLoad += HandleOnAdFailedToLoad;
        rewardBasedVideoAd.OnAdLeavingApplication += HandleOnAdLeavingApplication;
        rewardBasedVideoAd.OnAdLoaded += HandleOnAdLoaded;
        rewardBasedVideoAd.OnAdOpening += HandleOnAdOpening;
        rewardBasedVideoAd.OnAdRewarded += HandleOnAdRewarded;
        rewardBasedVideoAd.OnAdStarted += HandleOnAdStarted;
    }

    void RequestRewardedAd()
    {
#if UNITY_EDITOR
        string adUnitId = "unused";
        Debug.Log("adUnitId unused");
#elif UNITY_ANDROID
        string adUnitId = "ca-app-pub-3940256099942544/5224354917";
#endif
        rewardBasedVideoAd.LoadAd(new AdRequest.Builder().Build(), adUnitId);
    }

    public void ShowRewardBasedAd()
    {
        if (rewardBasedVideoAd.IsLoaded())
        {
            rewardBasedVideoAd.Show();
        }
        else
        {
            print("Ad's not loaded yet.");
        }
    }

    public event EventHandler<EventArgs> OnAdLoaded;
    public event EventHandler<AdFailedToLoadEventArgs> OnAdFailedToLoad;
    public event EventHandler<EventArgs> OnAdOpening;
    public event EventHandler<EventArgs> OnAdStarted;
    public event EventHandler<EventArgs> OnAdClosed;
    public event EventHandler<Reward> OnAdRewarded;
    public event EventHandler<EventArgs> OnAdLeavingApplication;

    public void HandleOnAdLoaded(object sender, EventArgs args)
    {
        Debug.Log("HandleOnAdLoaded");
    }

    public void HandleOnAdFailedToLoad(object sender, AdFailedToLoadEventArgs args)
    {
        // Try a reload
        Debug.Log("HandleOnAdFailedToLoad");
    }
    public void HandleOnAdOpening(object sender, EventArgs args)
    {
        // Pause the action
        Debug.Log("HandleOnAdOpening");
    }
    public void HandleOnAdStarted(object sender, EventArgs args)
    {
        // Mute audio
        Debug.Log("HandleOnAdStarted");
    }
    public void HandleOnAdClosed(object sender, EventArgs args)
    {
        // Return the action and the audio
        Debug.Log("HandleOnAdClosed");
    }
    public void HandleOnAdRewarded(object sender, Reward args)
    {
        // Reward the user
        MonoBehaviour.print(String.Format("You just got {0} {1}!", args.Amount, args.Type));
        Debug.Log("HandleOnAdRewarded");
    }
    public void HandleOnAdLeavingApplication(object sender, EventArgs args)
    {

    }
}

