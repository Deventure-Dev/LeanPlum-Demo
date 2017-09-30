using System;
using Android.App;
using Android.Runtime;
using LeanplumBindings;
using LeanplumBindings.Annotations;
using LeanplumBindings.Callbacks;
using LeanplumDemo.Common;

namespace LeanplumDemo.Droid
{
	#if DEBUG
		[Application(Debuggable = true)]
	#else
	    [Application(Debuggable = false)]
	#endif
	public class ApplicationClass : Application
    {
        protected ApplicationClass()
        {
        }

        protected ApplicationClass(IntPtr javaReference, JniHandleOwnership transfer)
            : base(javaReference, transfer)
        {
        }

        public override void OnCreate()
        {
            base.OnCreate();

            InitLeanplum();
        }

        #region private methods

        private void InitLeanplum()
        {
            Leanplum.SetApplicationContext(this);
            LeanplumActivityHelper.EnableLifecycleCallbacks(this);

            Parser.ParseVariables(this);
            Leanplum.EnableVerboseLoggingInDevelopmentMode();
            Leanplum.SetAppIdForDevelopmentMode(Constants.LEANPLUM_APP_ID, Constants.LEANPLUM_DEV_APP_KEY);

            //Enable this for Production
            //Leanplum.SetAppIdForProductionMode(Constants.LEANPLUM_APP_ID, Constants.LEANPLUM_PROD_APP_KEY);
        }

        #endregion
    }
}
