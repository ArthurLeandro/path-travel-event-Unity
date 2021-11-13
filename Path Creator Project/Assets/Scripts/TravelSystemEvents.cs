using System;

namespace Travel
{
	public partial class TravelSystemEvents
	{
		public static Action OnCreateLinks;
		public static Action OnFinishingLinks;
	}


	public partial class TravelSystemEvents
	{
		public static void CallOnCreateLinks()
		{

			OnCreateLinks?.Invoke();
		}
		public static void CallOnFinishingLinks()
		{
			OnFinishingLinks?.Invoke();
		}
	}
}