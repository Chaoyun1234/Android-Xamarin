package mono.com.microsoft.azure.mobile.distribute;


public class DistributeListenerImplementor
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
		mono.android.Runtime.register ("Com.Microsoft.Azure.Mobile.Distribute.IDistributeListenerImplementor, Microsoft.Azure.Mobile.Distribute.Android.Bindings, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null", DistributeListenerImplementor.class, __md_methods);
	}


	public DistributeListenerImplementor () throws java.lang.Throwable
	{
		super ();
		if (getClass () == DistributeListenerImplementor.class)
			mono.android.TypeManager.Activate ("Com.Microsoft.Azure.Mobile.Distribute.IDistributeListenerImplementor, Microsoft.Azure.Mobile.Distribute.Android.Bindings, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
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
