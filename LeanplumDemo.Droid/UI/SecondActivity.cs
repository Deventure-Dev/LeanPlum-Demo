﻿using Android.Widget;
using System;
using LeanplumBindings;
using Android.Graphics;
using LeanplumDemo.Common;
using Android.Content;
using Android.App;
using Android.OS;

namespace LeanplumDemo.Droid
{
    [Activity(Label = "Deventure Demo 2", Icon = "@mipmap/icon")]
    [IntentFilter(new[] { Intent.ActionView },
              Categories = new[] { Intent.CategoryBrowsable, Intent.CategoryDefault },
              DataScheme = "http",
              DataHost = "deventure.co",
              DataPathPrefix = "/deeplink2",
              AutoVerify = true)]
    public class SecondActivity : Activity
    {
        #region private methods

        private Button mBtnSignIn;
        private EditText mEtEmail;
        private EditText mEtPassword;

        private string mEmail;
        private string mPassword;

        private static readonly Var buttonTitle = Var.Define("ButtonTitle", "Sign In");
        private static readonly Var buttonColor = Var.Define("ButtonColor", Constants.RED_COLOR);

        #endregion

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // Get our button from the layout resource,
            // and attach an event to it
            mBtnSignIn = FindViewById<Button>(Resource.Id.btn_sign_in);
            mEtEmail = FindViewById<EditText>(Resource.Id.et_email);
            mEtPassword = FindViewById<EditText>(Resource.Id.et_password);

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

        protected override void OnResume()
        {
            base.OnResume();

            InitFromDeepLinkingParams();
        }

        #region private fields

        private void VariableChanged()
        {
            mBtnSignIn.Text = buttonTitle.StringValue();

            var buttonColorValue = buttonColor.StringValue();
            switch (buttonColorValue)
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
            var action = Intent.Action;
            if (Intent.Data == null)
            {
                return;
            }

            try
            {
                var parsedOptions = QueryStringHelper.ParseQueryStringForAndroid(Intent.Data.Query);
                if (parsedOptions.ContainsKey(Constants.EMAIL_KEY))
                {
                    mEmail = parsedOptions[Constants.EMAIL_KEY];
                }

                if (parsedOptions.ContainsKey(Constants.PASSWORD_KEY))
                {
                    mPassword = parsedOptions[Constants.PASSWORD_KEY];
                }

                if (!string.IsNullOrWhiteSpace(mEmail))
                {
                    mEtEmail.Text = mEmail;
                }

                if (!string.IsNullOrWhiteSpace(mPassword))
                {
                    mEtPassword.Text = mPassword;
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
                throw ex;
            }
		}

        #endregion

    }
}

