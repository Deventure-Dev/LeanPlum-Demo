using System;
using LeanplumBindings;
using LeanplumDemo.Common;
using UIKit;

namespace LeanplumDemo.UI
{
    public partial class SignInViewController : UIViewController
    {
        #region private fields

        private static readonly LPVar buttonTitle = LPVar.Define("ButtonTitle", "Sign In");
        private static readonly LPVar buttonColor = LPVar.Define("ButtonColor", Constants.RED_COLOR);

        #endregion

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

                var buttonColorValue = buttonColor.StringValue;
				switch (buttonColorValue)
				{
					case Constants.RED_COLOR:
                        btnSignIn.BackgroundColor = UIColor.Red;
						break;
					case Constants.GREEN_COLOR:
                        btnSignIn.BackgroundColor = UIColor.Green; 
                        break;
					case Constants.BLUE_COLOR:
                        btnSignIn.BackgroundColor = UIColor.Blue;
                        break;
				}
            });

            btnSignIn.TouchUpInside += SignInHandler;
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }

		#region private methods

		private void SignInHandler(object sender, EventArgs e)
		{
			Leanplum.Track("Sign in button clicked");
		}

        #endregion

    }
}

