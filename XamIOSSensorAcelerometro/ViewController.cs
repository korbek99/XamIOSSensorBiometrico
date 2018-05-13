using System;
using CoreAnimation;
using CoreGraphics;
using CoreMotion;
using Foundation;
using LocalAuthentication;

using UIKit;

namespace XamIOSSensorAcelerometro
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
        CALayer CapaImagen;


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
                    Altura = View.Bounds.Width;
                    Ancho = View.Bounds.Height;
                    AnchoCapa = Altura / 2;
                    AlturaCapa = Ancho / 6;
                    CapaImagen = new CALayer();
                    CapaImagen.Bounds = new CGRect(Altura / 2 - AnchoCapa / 2 ,Ancho / 2 -
                                                   AlturaCapa / 2, AnchoCapa, AlturaCapa);

                    CapaImagen.Position = new CGPoint(100, 100);
                    CapaImagen.Contents = UIImage.FromFile("BolaCristal.jpg").CGImage;

                    View.Layer.AddSublayer(CapaImagen);
                    var actualiza = CapaImagen.Frame;
                    Movimiento = new CMMotionManager();

                    if(Movimiento.AccelerometerAvailable){

                        Movimiento.AccelerometerUpdateInterval = 0.02;
                        Movimiento.StartAccelerometerUpdates(NSOperationQueue.CurrentQueue, (data, error) =>
                         {
                             ActualizaX = CapaImagen.Frame.X;
                             ActualizaY = CapaImagen.Frame.Y;
                             if (ActualizaX + (nfloat)data.Acceleration.X * 10 > 0 &&
                                ActualizaX + (nfloat)data.Acceleration.X * 10 <
                                Altura - AnchoCapa)
                                 actualiza.X = ActualizaX + (nfloat)
                                         data.Acceleration.X * 10;

                             if (ActualizaY + (nfloat)data.Acceleration.Y * 10 > 0 &&
                               ActualizaY + (nfloat)data.Acceleration.Y * 10 <
                               Ancho - AlturaCapa)
                                 actualiza.Y = ActualizaY + (nfloat)
                                         data.Acceleration.X * 10;

                             LblX.Text = data.Acceleration.X.ToString("0.0");
                             LblY.Text = data.Acceleration.Y.ToString("0.0");
                            LblZ.Text = data.Acceleration.Z.ToString("0.0");
                             CapaImagen.Frame = actualiza;
                         });
                    }
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
