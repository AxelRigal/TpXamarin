using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Essentials;

namespace SeFaireLesDentsTest.Models
{
    public class GyroscopeReader
    {
        public SensorSpeed speed = SensorSpeed.UI;
        public float GyrX, GyrY, GyrZ;
        public bool isStarted;

        public GyroscopeReader()
        {
            GyrX = 0;
            GyrY = 0;
            GyrZ = 0;
            Gyroscope.ReadingChanged += Gyroscope_ReadingChanged;
        }

        void Gyroscope_ReadingChanged(object sender, GyroscopeChangedEventArgs e)
        {
            var data = e.Reading;
            Console.WriteLine($"Gyroscope Reading: X: {data.AngularVelocity.X}, Y: {data.AngularVelocity.Y}, Z: {data.AngularVelocity.Z}");
            GyrX = data.AngularVelocity.X;
            GyrY = data.AngularVelocity.Y;
            GyrZ = data.AngularVelocity.Z;
        }

        public void ToggleGyroscope()
        {
            try
            {
                if(Gyroscope.IsMonitoring)
                {
                    Gyroscope.Stop();
                    isStarted = false;
                }
                else
                {
                    Gyroscope.Start(speed);
                    isStarted = true;
                }
            }
            catch (FeatureNotSupportedException fnsEx)
            {
                // Feature not supported on device
            }
            catch (Exception ex)
            {
                // Other error has occurred.
            }
        }
    }
}