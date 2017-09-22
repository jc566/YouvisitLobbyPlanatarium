using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System;
using AUP;

public class BatteryLife : MonoBehaviour {

    public static BatteryStatus batteryStatus;

    public float batteryLevel;
 

    private InternetPlugin internetPlugin;

    public Text mobileConnectionText;
    public Text wifiConnectionText;
    public Text wifiSignalStrengthText;
    public Text wifiIPText;
    public Text wifiSSIDText;
    public Text wifiBSSIDText;
    public Text wifiRssiText;

    public Text wifiSpeedText;

    private Dispatcher dispatcher;

    // Use this for initialization
    void Start () {
        //Debug.Log(batteryLevel);
        //Debug.Log(batteryStatus);

        batteryLevel = SystemInfo.batteryLevel;

        dispatcher = Dispatcher.GetInstance();

        internetPlugin = InternetPlugin.GetInstance();
        internetPlugin.SetDebug(0);
        internetPlugin.Init();
        internetPlugin.setInternetCallbackListener(OnWifiConnect, OnWifiDisconnect, OnWifiSignalStrengthChange);

        

        Debug.Log(NetworkReachability.NotReachable);
	}
	
	// Update is called once per frame
	void Update () {
        this.gameObject.GetComponent<PopWindowOver>().text_content = batteryLevel.ToString();
        //this.gameObject.GetComponent<PopWindowOver>().text_content = "Hello world";
       

    }
    //Function that returns the float value of battery life multiplied by 100.
    public float getBatteryLevel()
    {
        //get the battery life of the device
        batteryLevel = SystemInfo.batteryLevel * 100;

        return batteryLevel;
    }
 
    public void ScanWifi()
    {
        internetPlugin.ScanWifi();
    }

    public void CheckMobileConnection()
    {
        bool status = internetPlugin.IsMobileConnected();
        if (mobileConnectionText != null)
        {
            mobileConnectionText.text = String.Format("Is Mobile Connected: {0}", status);
        }
    }

    public void CheckWifiConnection()
    {
        bool status = internetPlugin.IsWifiConnected();
        if (wifiConnectionText != null)
        {
            wifiConnectionText.text = String.Format("Is Wifi Connected: {0}", status);
        }
    }

    public void GetWifiIP()
    {
        string wifiIP = internetPlugin.GetWifiIP();
        if (wifiIPText != null)
        {
            wifiIPText.text = String.Format("Wifi IP: {0}", wifiIP);
        }
    }

    public void GetWifiSSID()
    {
        string wifiSSID = internetPlugin.GetWifiSSID();
        if (wifiSSIDText != null)
        {
            wifiSSIDText.text = String.Format("wifi SSID: {0}", wifiSSID);
        }
    }

    public void GetWifiBSSID()
    {
        string wifiBSSID = internetPlugin.GetWifiBSSID();
        if (wifiBSSIDText != null)
        {
            wifiBSSIDText.text = String.Format("wifi BSSID: {0}", wifiBSSID);
        }
    }

    public void GetWifiRssi()
    {
        string wifiRssi = internetPlugin.GetWifiRssi();
        if (wifiRssiText != null)
        {
            wifiRssiText.text = String.Format("wifi Rssi: {0}", wifiRssi);
        }
    }

    public void GetWifiSpeed()
    {
        string wifiSpeed = internetPlugin.GetWifiSpeed();
        if (wifiSpeedText != null)
        {
            wifiSpeedText.text = String.Format("wifi speed: {0}", wifiSpeed);
        }
    }

    void OnWifiConnect()
    {
        dispatcher.InvokeAction(
            () => {
                Debug.Log("[InternetInfoDemo] OnWifiConnect");
            }
        );
    }

    void OnWifiDisconnect()
    {
        dispatcher.InvokeAction(
            () => {
                Debug.Log("[InternetInfoDemo] OnWifiDisconnect");
            }
        );
    }

    void OnWifiSignalStrengthChange(int signalStrength, int signalDifference)
    {
        dispatcher.InvokeAction(
            () => {
                if (wifiSignalStrengthText != null)
                {
                    wifiSignalStrengthText.text = String.Format("wifi Signal Strength: {0}", signalStrength);
                }
                Debug.Log("[InternetInfoDemo] OnWifiSignalStrengthChange signalStrength " + signalStrength + " signalDifference " + signalDifference);
            }
        );
    }
}
