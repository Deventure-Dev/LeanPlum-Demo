using Android.App;
using Android.Widget;
using Android.OS;
using System;
using LeanplumBindings;
using Android.Graphics;
using LeanplumDemo.Common;

namespace LeanplumDemo.Droid
{
    [Activity(Label = "LeanplumDemo.Droid", MainLauncher = true, Icon = "@mipmap/icon")]
    public class SignInActivity : Activity
    {
        #region private methods

        private Button mBtnSignIn;
        private EditText mEtEmail;
        private EditText mEtPassword;

        private string mEmail;
        private string mPassword;

        //private Var welcomeLabel = Var.Define("welcomeLabel", "Welcome!");
        private static readonly Var buttonTitle = Var.Define("ButtonTitle", "Sign In");
        private static readonly Var buttonColor = Var.Define("ButtonColor", Constants.RED_COLOR);

        public static Var ButtonColor => buttonColor;

        #endregion

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // Get our button from the layout resource,
            // and attach an event to it
            mBtnSignIn = FindViewById<Button>(Resource.Id.btn_sign_in);
            mEtEmail = FindViewById<EditText>(Resource.Id.tv_email);
            mEtPassword = FindViewById<EditText>(Resource.Id.tv_password);

            mBtnSignIn.Click += SignInHandler;
           
            try
            {
				Leanplum.AddVariablesChangedHandler(new CustomVariablesChangedCallback(VariableChanged));
				Leanplum.Start(this);
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        #region private fields

        private void VariableChanged()
        {
            mBtnSignIn.Text = buttonTitle.StringValue();

            var buttonColorValue = buttonColor.StringValue();
            switch(buttonColorValue)
            {
                case Constants.RED_COLOR:
                    mBtnSignIn.SetBackgroundColor(Color.Red);
                    break;
				case Constants.GREEN_COLOR:
                    mBtnSignIn.SetBackgroundColor(Color.Green);
					break;
				case Constants.BLUE_COLOR:
                    mBtnSignIn.SetBackgroundColor(Color.Blue);
					break;
            }
        }

        private void SignInHandler(object sender, EventArgs e)
        {
            Leanplum.Track("Sign in button clicked");
        }

		private void InitFromDeepLinkingParams()
		{
			if (!string.IsNullOrWhiteSpace(mEmail))
			{
				mEtEmail.Text = mEmail;
			}

			if (!string.IsNullOrWhiteSpace(mPassword))
			{
				mEtPassword.Text = mPassword;
			}
		}

        #endregion

    }
}

