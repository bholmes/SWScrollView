using System.Drawing;
using System;

using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace SWScrollView {

	[BaseType (typeof (UIView))]
	public partial interface SWScrollView {

		[Static, Export ("scrollViewWithStartPoint:")]
		SWScrollView ScrollViewWithStartPoint (PointF startPoint);

		[Export ("startAnimationWithDuration:completion:"), Async]
		void StartAnimationWithDuration (double duration,  Action<bool> completion);
	}
}
