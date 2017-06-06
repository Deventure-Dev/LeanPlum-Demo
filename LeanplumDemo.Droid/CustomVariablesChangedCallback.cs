using System;
using LeanplumBindings.Callbacks;

namespace LeanplumDemo.Droid
{
    public class CustomVariablesChangedCallback : VariablesChangedCallback
    {
        #region private fields

        private Action mCallback;

        #endregion

        public CustomVariablesChangedCallback(Action callback)
        {
            mCallback = callback;
        }

        public override void VariablesChanged()
        {
            if(mCallback == null)
            {
                throw new Exception("Callback not set in CustomVariablesChangedCallback");    
            }
            mCallback?.Invoke();
        }
    }
}
