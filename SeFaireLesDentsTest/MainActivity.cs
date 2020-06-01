using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using Android.Views;
using System;
using Android.Media;
using Android;
using System.Threading.Tasks;
using Android.Content;
using Xamarin.Essentials;
using SeFaireLesDentsTest.Models;

namespace SeFaireLesDentsTest
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        #region Propriété layout
        private Button bouton1;
        private Button bouton2;
        private Button bouton3;
        private Button bouton4;
        private Button bouton5;
        private Button bouton6;
        private Button bouton7;
        private Button bouton8;
        private Button bouton9;
        private Object o;
        private EventArgs e;
        private TextView tvAccX;
        private TextView tvAccY;
        private TextView tvAccZ;
        #endregion

        #region Propriété fonctionnelle
        private int encouragement;
        private int tangage;
        private int nbChoc;
        private bool demarrage;
        private bool bravo;
        private bool super;
        #endregion

        #region Propriété audio
        private AudioManager am = (AudioManager)Android.App.Application.Context.GetSystemService(Context.AudioService);
        private static MediaPlayer mp = new MediaPlayer();
        #endregion

        #region Propriété capteurs
        private AcceloremeterReader accelerometerReader = new AcceloremeterReader();
        private GyroscopeReader gyroscopeReader = new GyroscopeReader();
        private OrientationReader orientationReader = new OrientationReader();
        #endregion


        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
           //Initialise le layout
           SetContentView(Resource.Layout.activity_main);

            #region initialisation des variables.
            nbChoc = 0;
            o = new Object();
            e = new EventArgs();
            demarrage = true;
            encouragement = 0;
            tangage = 0;
            bravo = false;
            super = false;
            bouton1 = FindViewById<Button>(Resource.Id.bouton1);
            bouton2 = FindViewById<Button>(Resource.Id.bouton2);
            bouton3 = FindViewById<Button>(Resource.Id.bouton3);
            bouton4 = FindViewById<Button>(Resource.Id.bouton4);
            bouton5 = FindViewById<Button>(Resource.Id.bouton5);
            bouton6 = FindViewById<Button>(Resource.Id.bouton6);
            bouton7 = FindViewById<Button>(Resource.Id.bouton7);
            bouton8 = FindViewById<Button>(Resource.Id.bouton8);
            bouton9 = FindViewById<Button>(Resource.Id.bouton9);


            // a corriger
            bouton1.Click += Son1;
            bouton2.Click += Son2;
            bouton3.Click += Son3;
            bouton4.Click += Son4;
            bouton5.Click += Son5;
            bouton6.Click += Son6;
            bouton7.Click += Son7;
            bouton8.Click += Son8;
            bouton9.Click += Son9;


            tvAccX = FindViewById<TextView>(Resource.Id.tvAccX);
            tvAccY = FindViewById<TextView>(Resource.Id.tvAccY);
            tvAccZ = FindViewById<TextView>(Resource.Id.tvAccZ);
            #endregion


            // demarre l'initialisation des capteurs.
            Lancement();

            //lancement de l'application.
            startTimer();

        }
        
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        #region Sons
        public void Son1(Object o, EventArgs e)
        {
            mp = MediaPlayer.Create(this, Resource.Drawable.Voice01_01);
            if (!am.IsMusicActive)
            {
                mp.Start();
            }
        }

        public void Son2(Object o, EventArgs e)
        {
            mp = MediaPlayer.Create(this, Resource.Drawable.Voice01_02);
            if (!am.IsMusicActive)
            {
                mp.Start();
            }
        }
        public void Son3(Object o, EventArgs e)
        {
            mp = MediaPlayer.Create(this, Resource.Drawable.Voice01_03);
            if (!am.IsMusicActive)
            {
                mp.Start();
            }
        }
        public void Son4(Object o, EventArgs e)
        {
            mp = MediaPlayer.Create(this, Resource.Drawable.Voice01_04);
            if (!am.IsMusicActive)
            {
                mp.Start();
            }
        }
        public void Son5(Object o, EventArgs e)
        {
            mp = MediaPlayer.Create(this, Resource.Drawable.Voice01_05);
            if (!am.IsMusicActive)
            {
                mp.Start();
            }
        }
        public void Son6(Object o, EventArgs e)
        {
            mp = MediaPlayer.Create(this, Resource.Drawable.Voice01_06);
            if (!am.IsMusicActive)
            {
                mp.Start();
            }
        }
        public void Son7(Object o, EventArgs e)
        {
            mp = MediaPlayer.Create(this, Resource.Drawable.Voice01_07);
            if (!am.IsMusicActive)
            {
                mp.Start();
            }
        }
        public void Son8(Object o, EventArgs e)
        {

            mp = MediaPlayer.Create(this, Resource.Drawable.Voice01_08);
            if (!am.IsMusicActive)
            {
                mp.Start();
            }
        }
        public void Son9(Object o, EventArgs e)
        {
            mp = MediaPlayer.Create(this, Resource.Drawable.Voice01_09);
            if (!am.IsMusicActive)
            {
                mp.Start();
            }
        }
        public void Son10(Object o, EventArgs e)
        {
            mp = MediaPlayer.Create(this, Resource.Drawable.Voice01_10);
            if (!am.IsMusicActive)
            {
                mp.Start();
            }
        }
        #endregion

        #region initialisation Acceleromettre Orientation Gyroscope
        private void Lancement()
        {
            MainThread.BeginInvokeOnMainThread(() =>
            {
                if(accelerometerReader.isStarted == false)
                {
                    accelerometerReader.ToggleAccelerometer();
                }

                if(orientationReader.isStarted == false)
                {
                    orientationReader.ToggleOrientationSensor();
                }
                
                if(gyroscopeReader.isStarted == false)
                {
                    gyroscopeReader.ToggleGyroscope();
                }
            });
        }
        #endregion

        #region encouragement methodes
        public void reset()
        {
            encouragement = 0;
            bravo = false;
            super = false;
        }


        public void Bravo()
        {
            Son8(o, e);
        }  

        public void Super()
        {
            Son9(o, e);
        }
        #endregion


        public void startTimer()
        {
            Console.WriteLine("startTimer()");

            System.Timers.Timer Timer1 = new System.Timers.Timer();
            Timer1.Start();
            Timer1.Interval = 300;
            Timer1.Enabled = true;
            Timer1.Elapsed += (object sender, System.Timers.ElapsedEventArgs e) =>
            {
                RunOnUiThread(() =>
                {
                    Console.WriteLine("RunOnUiThread()");
                    
                    tvAccX.Text = accelerometerReader.accX.ToString();
                    tvAccY.Text = accelerometerReader.accY.ToString();
                    tvAccZ.Text = accelerometerReader.accZ.ToString();

                    if(demarrage)
                    {
                        this.Son1(o, e);
                        demarrage = false;
                    }
                    #region chute
                    //Detecte si il y a une chute du telephone.
                    if ( accelerometerReader.accZ > 1.5 || accelerometerReader.accZ < -1.5)
                    {
                        if (nbChoc == 0)
                        {
                            this.Son5(o, e);
                            
                        }else if( nbChoc == 1)
                        {
                            this.Son6(o, e);
                        }else if(nbChoc >= 2)
                        {
                            this.Son7(o, e);
                        }
                        nbChoc++;
                        reset();
                    }
                    #endregion

                    #region tangage
                    // Detecte le tangage
                    if (accelerometerReader.accX > 0.5 || accelerometerReader.accX < -0.5)
                    {
                        if(tangage == 0)
                        {
                            this.Son2(o, e);
                        }
                        else if(tangage > 300)
                        {
                            this.Son3(o, e);
                        }
                        tangage += tangage + 300;
                        reset();
                    }
                    #endregion

                    #region encouragement
                    //Detecte si les mouvements ne sont pas trop brusques
                    if ( accelerometerReader.accX < 0.2 && accelerometerReader.accX > -0.2 && accelerometerReader.accY< 0.2 && accelerometerReader.accY> -0.2 && accelerometerReader.accZ < 1.2 && accelerometerReader.accZ > -0.8 )
                    {
                        encouragement += encouragement + 300;
                    }


                    if (encouragement >= 100000 && !super)
                    {
                        Super();
                        super = true;
                    }
                    else if( encouragement >= 50000 && !bravo)
                    {
                        Bravo();
                        bravo = true;
                    }
                    #endregion
                });
            };
        }
    }
}