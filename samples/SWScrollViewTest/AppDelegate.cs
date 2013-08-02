using System;
using System.Collections.Generic;
using System.Linq;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.Drawing;
using System.Threading.Tasks;
using MonoTouch.CoreGraphics;

namespace SWScrollViewTest
{
	// The UIApplicationDelegate for the application. This class is responsible for launching the 
	// User Interface of the application, as well as listening (and optionally responding) to 
	// application events from iOS.
	[Register ("AppDelegate")]
	public partial class AppDelegate : UIApplicationDelegate
	{
		// class-level declarations
		UIWindow window;
		//
		// This method is invoked when the application has loaded and is ready to run. In this 
		// method you should instantiate the window, load the UI into it and then make the window
		// visible.
		//
		// You have 17 seconds to return from this method, or iOS will terminate your application.
		//
		public override bool FinishedLaunching (UIApplication app, NSDictionary options)
		{
			// create a new window instance based on the screen size
			window = new UIWindow (UIScreen.MainScreen.Bounds);

			//window.RootViewController = new MyViewController ();

			window.MakeKeyAndVisible ();
			
			return true;
		}
	}

	public class MyViewController : UIViewController
	{
		UIButton replayButton;

		public override async void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			CreateButton ();

			await LoadSWViewAndRun ();
		}

		async Task LoadSWViewAndRun ()
		{
			replayButton.Hidden = true;

			var scrollView = SWScrollView.SWScrollView.ScrollViewWithStartPoint (new PointF (0, -600));
			View.AddSubview (scrollView);

			await scrollView.StartAnimationWithDurationAsync (6f);

			scrollView.RemoveFromSuperview ();
			replayButton.Hidden = false;
		}

		void CreateButton ()
		{
			replayButton = UIButton.FromType (UIButtonType.Custom);
			replayButton.Frame = new RectangleF (View.Bounds.GetMidX () - 50, View.Bounds.GetMidY () - 22, 100, 44);
			replayButton.SetTitle ("Replay", UIControlState.Normal);

			replayButton.ClipsToBounds = true;
			replayButton.Layer.CornerRadius = 9f;
			replayButton.SetTitleColor (UIColor.LightTextColor, UIControlState.Normal);
			replayButton.Layer.BorderColor = UIColor.LightTextColor.CGColor;
			replayButton.Layer.BorderWidth = 1f;

			UIGraphics.BeginImageContext (replayButton.Bounds.Size);
			var context = UIGraphics.GetCurrentContext ();
			var grey = UIColor.DarkGray;
			context.SetFillColor (grey.CGColor);
			context.FillRect (replayButton.Bounds);

			var image = UIGraphics.GetImageFromCurrentImageContext ();
			UIGraphics.EndImageContext ();
			replayButton.SetBackgroundImage (image, UIControlState.Highlighted);

			replayButton.Hidden = true;

			View.Add (replayButton);

			replayButton.TouchUpInside += async (sender, e) => {
				await LoadSWViewAndRun ();
			};
		}
	}
}

