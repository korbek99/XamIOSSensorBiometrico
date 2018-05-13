using System;
using CoreAnimation;
using CoreGraphics;
using CoreMotion;
using Foundation;
using LocalAuthentication;

using UIKit;

namespace XamIOSSensorBiometrico
{
    public partial class ViewController : UIViewController

    {
        CMMotionManager Movimiento;
        UIAlertController Alerta;
        nfloat Altura;
        nfloat Ancho;
        nfloat AnchoCapa;
        nfloat AlturaCapa;
        nfloat ActualizaX;
        nfloat ActualizaY;
        CALayer CapaImagen3;


        protected ViewController(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.
        }

        public override async void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.

            try
            {
                var verifica = new LAContext();

                var autoriza = await verifica.EvaluatePolicyAsync
                                                      (LAPolicy.
                                                       DeviceOwnerAuthenticationWithBiometrics, 
                                                       "Autotenticacion Biometrica");

                if(autoriza.Item1)
                {



                }else{

                    System.Threading.Thread.CurrentThread.Abort();
                }
                
            }catch(Exception ex){

                Alerta = UIAlertController.Create("Status", ex.Message, UIAlertControllerStyle.Alert);
                Alerta.AddAction(UIAlertAction.Create("Aceptar",UIAlertActionStyle.Default,null));
                PresentViewController(Alerta,true,null);
                
            }
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}
