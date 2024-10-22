using System.Collections;
using System.Collections.Generic;
using Unity.Services.Core;
using Unity.Services.Analytics;
using UnityEngine;

public class AnalyticsScript : MonoBehaviour
{
   async void Start()
   {
		await UnityServices.InitializeAsync();


		AskForConsent(); // Acá 
   }
	void AskForConsent()
	{
		// ... show the player a UI element that asks for consent.
	}
	void ConsentGiven()
	{
		AnalyticsService.Instance.StartDataCollection();
	}
}
