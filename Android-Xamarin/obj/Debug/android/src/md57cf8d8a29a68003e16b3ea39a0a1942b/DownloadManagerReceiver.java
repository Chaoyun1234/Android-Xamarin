package md57cf8d8a29a68003e16b3ea39a0a1942b;


public class DownloadManagerReceiver
	extends com.microsoft.azure.mobile.distribute.DownloadManagerReceiver
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("Microsoft.Azure.Mobile.Distribute.DownloadManagerReceiver, Microsoft.Azure.Mobile.Distribute.Android.Bindings, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null", DownloadManagerReceiver.class, __md_methods);
	}


	public DownloadManagerReceiver () throws java.lang.Throwable
	{
		super ();
		if (getClass () == DownloadManagerReceiver.class)
			mono.android.TypeManager.Activate ("Microsoft.Azure.Mobile.Distribute.DownloadManagerReceiver, Microsoft.Azure.Mobile.Distribute.Android.Bindings, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}

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
