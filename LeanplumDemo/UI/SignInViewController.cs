using System;
using LeanplumBindings;
using UIKit;

namespace LeanplumDemo.UI
{
    public partial class SignInViewController : UIViewController
    {
        private static readonly LPVar buttonTitle = LPVar.Define("ButtonTitle", "Sign In");
        private static readonly LPVar buttonColor = LPVar.Define("ButtonColor", UIColor.Blue);


        public SignInViewController(IntPtr handle) : base(handle)
        {
        }

        public SignInViewController()
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            Leanplum.OnVariablesChanged(() =>
            {
                btnSignIn.SetTitle(buttonTitle.StringValue, UIControlState.Normal);
                btnSignIn.SetTitleColor(buttonColor.ColorValue, UIControlState.Normal);
            });

            btnSignIn.TouchUpInside += SignInHandler;
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }

		#region private fields

		private void SignInHandler(object sender, EventArgs e)
		{
			Leanplum.Track("Sign in button clicked");
		}

        #endregion

    }
}

