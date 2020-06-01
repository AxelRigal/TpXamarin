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

namespace SeFaireLesDentsTest
{
    public class AcceloremeterReader
    {
        SensorSpeed speed = SensorSpeed.UI;

        public float accX, accY, accZ;

        public bool isStarted;

        public AcceloremeterReader()
        {
            accX = 0;
            accY = 0;
            accZ = 0;

            isStarted = false;

            Accelerometer.ReadingChanged += Accelerometer_ReadingChanged;
            Accelerometer.ShakeDetected += Accelerometer_ShakeDetected;
        }

        private void Accelerometer_ShakeDetected(object sender, EventArgs e)
        {
            Console.WriteLine(" SHAKE ");
        }

        void Accelerometer_ReadingChanged(object sender, AccelerometerChangedEventArgs e)
        {
            var data = e.Reading;
            Console.WriteLine($"Reading: X: {data.Acceleration.X}, Y: {data.Acceleration.Y}, Z: {data.Acceleration.Z}");
            accX = data.Acceleration.X;
            accY = data.Acceleration.Y;
            accZ = data.Acceleration.Z;
            // Process Acceleration X, Y, and Z
        }

        public void ToggleAccelerometer()
        {
            try
            {
                if (Accelerometer.IsMonitoring)
                {
                    Accelerometer.Stop();
                    isStarted = false;
                }
                else
                {
                    Accelerometer.Start(speed);
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