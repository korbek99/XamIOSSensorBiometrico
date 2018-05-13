// WARNING
//
// This file has been generated automatically by Visual Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
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
