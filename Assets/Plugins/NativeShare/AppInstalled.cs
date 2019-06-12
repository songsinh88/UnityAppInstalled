using UnityEngine;
using System;
using System.IO;
using System.Collections.Generic;
using System.Collections;

// We need this one for importing our IOS functions
using System.Runtime.InteropServices;

#pragma warning disable 0414
public class AppInstalled
{
#if !UNITY_EDITOR && UNITY_ANDROID
	private static AndroidJavaClass m_ajc = null;
	private static AndroidJavaClass AJC
	{
		get
		{
			if( m_ajc == null )
				m_ajc = new AndroidJavaClass( "com.yasirkula.unity.NativeShare" );

			return m_ajc;
		}
	}

	private static AndroidJavaObject m_context = null;
	private static AndroidJavaObject Context
	{
		get
		{
			if( m_context == null )
			{
				using( AndroidJavaObject unityClass = new AndroidJavaClass( "com.unity3d.player.UnityPlayer" ) )
				{
					m_context = unityClass.GetStatic<AndroidJavaObject>( "currentActivity" );
				}
			}

			return m_context;
		}
	}
#elif !UNITY_EDITOR && UNITY_IOS
    [DllImport("__Internal")]
    private static extern bool _Check_App_Installed(string appID);
#endif

    private string subject;

	public AppInstalled()
	{
		subject = string.Empty;

    
  	}

	public static bool install(string appID)
	{
#if UNITY_EDITOR
        return false;
#elif UNITY_ANDROID
        AndroidJavaClass androidJavaClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        AndroidJavaObject @static = androidJavaClass.GetStatic<AndroidJavaObject>("currentActivity");
        AndroidJavaObject androidJavaObject = @static.Call<AndroidJavaObject>("getPackageManager", new object[0]);
        bool result;
        try
        {
            result = (androidJavaObject.Call<AndroidJavaObject>("getLaunchIntentForPackage", new object[]
            {
                appID
            }) != null);
        }
        catch (Exception ex)
        {
            Debug.Log("AppInstalled Exception:" + ex.Message);
            result = false;
        }
        return result;
#elif UNITY_IOS
		return _Check_App_Installed( appID );
#else
        return false;
#endif
    }
}
#pragma warning restore 0414
