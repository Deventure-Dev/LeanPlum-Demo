// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace LeanplumDemo.UI
{
    [Register ("SignInViewController")]
    partial class SignInViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton btnSignIn { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (btnSignIn != null) {
                btnSignIn.Dispose ();
                btnSignIn = null;
            }
        }
    }
}