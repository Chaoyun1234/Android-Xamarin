package md53dd5333e53b412d6778364d3ce024c4c;


public class PushListener
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		com.microsoft.azure.mobile.push.PushListener
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onPushNotificationReceived:(Landroid/app/Activity;Lcom/microsoft/azure/mobile/push/PushNotification;)V:GetOnPushNotificationReceived_Landroid_app_Activity_Lcom_microsoft_azure_mobile_push_PushNotification_Handler:Com.Microsoft.Azure.Mobile.Push.IPushListenerInvoker, Microsoft.Azure.Mobile.Push.Android.Bindings\n" +
			"";
		mono.android.Runtime.register ("Microsoft.Azure.Mobile.Push.Android.PushListener, Microsoft.Azure.Mobile.Push, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null", PushListener.class, __md_methods);
	}


	public PushListener () throws java.lang.Throwable
	{
		super ();
		if (getClass () == PushListener.class)
			mono.android.TypeManager.Activate ("Microsoft.Azure.Mobile.Push.Android.PushListener, Microsoft.Azure.Mobile.Push, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}


	public void onPushNotificationReceived (android.app.Activity p0, com.microsoft.azure.mobile.push.PushNotification p1)
	{
		n_onPushNotificationReceived (p0, p1);
	}

	private native void n_onPushNotificationReceived (android.app.Activity p0, com.microsoft.azure.mobile.push.PushNotification p1);

	private java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}
