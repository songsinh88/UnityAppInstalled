using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestScript : MonoBehaviour {

    public GameObject titleResult;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void _Check_Install()
    {
        string appID;
#if UNITY_EDITOR
        appID = "fb://";
#elif UNITY_IOS
        appID = "fb://";
#elif UNITY_ANDROID
        appID = "com.facebook.android";
#endif

        bool check = AppInstalled.install(appID);
        if (check)
        {
            titleResult.GetComponent<Text>().text = "facebook installed:true";
        }
        else
        {
            titleResult.GetComponent<Text>().text = "facebook installed:false";
        }
    }
}
