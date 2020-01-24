package crc64e9990723d8924521;


public class Music
	extends crc64e9990723d8924521.MainActivity
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("amusic.Music, amusic", Music.class, __md_methods);
	}


	public Music ()
	{
		super ();
		if (getClass () == Music.class)
			mono.android.TypeManager.Activate ("amusic.Music, amusic", "", this, new java.lang.Object[] {  });
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
