// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;

namespace XamIOSSensorBiometrico
{
    [Register ("ViewController")]
    partial class ViewController
    {
        [Outlet]
        UIKit.UILabel LblX { get; set; }


        [Outlet]
        UIKit.UILabel LblY { get; set; }


        [Outlet]
        UIKit.UILabel LblZ { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (LblX != null) {
                LblX.Dispose ();
                LblX = null;
            }

            if (LblY != null) {
                LblY.Dispose ();
                LblY = null;
            }

            if (LblZ != null) {
                LblZ.Dispose ();
                LblZ = null;
            }
        }
    }
}