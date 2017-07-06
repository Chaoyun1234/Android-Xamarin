package md5f17f99090dac34a6460a89a40de2eaba;


public class Distribute_Listener
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		com.microsoft.azure.mobile.distribute.DistributeListener
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onReleaseAvailable:(Landroid/app/Activity;Lcom/microsoft/azure/mobile/distribute/ReleaseDetails;)Z:GetOnReleaseAvailable_Landroid_app_Activity_Lcom_microsoft_azure_mobile_distribute_ReleaseDetails_Handler:Com.Microsoft.Azure.Mobile.Distribute.IDistributeListenerInvoker, Microsoft.Azure.Mobile.Distribute.Android.Bindings\n" +
			"";
		mono.android.Runtime.register ("Microsoft.Azure.Mobile.Distribute.Distribute+Listener, Microsoft.Azure.Mobile.Distribute, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null", Distribute_Listener.class, __md_methods);
	}


	public Distribute_Listener () throws java.lang.Throwable
	{
		super ();
		if (getClass () == Distribute_Listener.class)
			mono.android.TypeManager.Activate ("Microsoft.Azure.Mobile.Distribute.Distribute+Listener, Microsoft.Azure.Mobile.Distribute, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}


	public boolean onReleaseAvailable (android.app.Activity p0, com.microsoft.azure.mobile.distribute.ReleaseDetails p1)
	{
		return n_onReleaseAvailable (p0, p1);
	}

	private native boolean n_onReleaseAvailable (android.app.Activity p0, com.microsoft.azure.mobile.distribute.ReleaseDetails p1);

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
