using GoogleMobileAds.Api;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdsManager : MonoBehaviour
{
	public bool CanWatchInterstitialAd;
	public bool CanWatchRewardedAd;

	private InterstitialAd interstitialAd;
	private RewardedAd rewardedAd;
	private RingsManager ringsManager;
	private bool canContinueGame;
	private bool canNewGame;

	private void Awake()
	{
		InitializeInterstitialAd();
		InitializeRewardAd();
		ringsManager = FindObjectOfType<RingsManager>();

		InvokeRepeating("CanWatchRewardAdsTime", 0.5f, 30f);
		InvokeRepeating("CanWatchInterstitialAdTime", 0.5f, 15f);
	}

	private void CanWatchRewardAdsTime()
	{
		CanWatchRewardedAd = true;
	}

	private void CanWatchInterstitialAdTime()
	{
		CanWatchInterstitialAd = true;
	}

	public void ShowInterstitialAd()
	{
		if (CanWatchInterstitialAd && interstitialAd.IsLoaded())
		{
			interstitialAd.Show();
			CanWatchInterstitialAd = false;
		}
		else
		{
			ringsManager.NewGame();
		}
	}

	public void ShowRewardedAd()
	{
		if (CanWatchRewardedAd && rewardedAd.IsLoaded())
		{
			rewardedAd.Show();
			CanWatchRewardedAd = false;
			CanWatchInterstitialAd = false;
		}
		else
		{
			ringsManager.NewGame();
		}
	}

	private void InitializeInterstitialAd()
	{
#if UNITY_ANDROID
		string adUnitId = "ca-app-pub-3940256099942544/1033173712";
#elif UNITY_IPHONE
        string adUnitId = "ca-app-pub-3940256099942544/4411468910";
#else
        string adUnitId = "unexpected_platform";
#endif

		interstitialAd = new InterstitialAd(adUnitId);
		interstitialAd.OnAdLoaded += HandleOnInterstitialAdLoaded;
		interstitialAd.OnAdFailedToLoad += HandleOnInterstitialAdFailedToLoad;
		interstitialAd.OnAdOpening += HandleOnInterstitialAdOpened;
		interstitialAd.OnAdClosed += HandleOnInterstitialAdClosed;

		var request = new AdRequest.Builder().Build();
		interstitialAd.LoadAd(request);
	}

	private void InitializeRewardAd()
	{
		var adUnitId = "";
#if UNITY_ANDROID
		adUnitId = "ca-app-pub-3940256099942544/5224354917";
#elif UNITY_IPHONE
            adUnitId = "ca-app-pub-3940256099942544/1712485313";
#else
            adUnitId = "unexpected_platform";
#endif

		rewardedAd = new RewardedAd(adUnitId);
		rewardedAd.OnAdFailedToLoad += HandleRewardedAdFailedToLoad;
		rewardedAd.OnAdFailedToShow += HandleRewardedAdFailedToShow;
		rewardedAd.OnUserEarnedReward += HandleUserEarnedReward;

		var request = new AdRequest.Builder().Build();
		rewardedAd.LoadAd(request);
	}

	private void RequestRewardAd()
	{
		var request = new AdRequest.Builder().Build();
		rewardedAd.LoadAd(request);
	}

	private void RequestInterstitialAd()
	{
		var request = new AdRequest.Builder().Build();
		interstitialAd.LoadAd(request);
	}

	public void HandleRewardedAdFailedToLoad(object sender, AdFailedToLoadEventArgs args)
	{
		RequestRewardAd();
	}

	public void HandleRewardedAdFailedToShow(object sender, AdErrorEventArgs args)
	{
		canNewGame = true;
		RequestRewardAd();
	}

	public void HandleUserEarnedReward(object sender, Reward args)
	{
		canContinueGame = true;
		RequestRewardAd();
	}

	public void HandleOnInterstitialAdLoaded(object sender, EventArgs args)
	{

	}

	public void HandleOnInterstitialAdFailedToLoad(object sender, AdFailedToLoadEventArgs args)
	{
		RequestInterstitialAd();
	}

	public void HandleOnInterstitialAdOpened(object sender, EventArgs args)
	{

	}

	public void HandleOnInterstitialAdClosed(object sender, EventArgs args)
	{
		RequestInterstitialAd();
		canNewGame = true;
	}

	private void Update()
	{
		if (canContinueGame)
		{
			ringsManager.ContinueGame();
			canContinueGame = false;
		}

		if (canNewGame)
		{
			ringsManager.NewGame();
			canNewGame = false;
		}
	}
}
