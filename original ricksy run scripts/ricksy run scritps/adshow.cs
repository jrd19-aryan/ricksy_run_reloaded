using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class adshow : MonoBehaviour
{
    admob adscript;

    private void Start()
    {
        adscript = GameObject.Find("Admob").GetComponent<admob>();
        adscript.ShowInterstitialAd();
        adscript.requestInterstital();
    }
}
