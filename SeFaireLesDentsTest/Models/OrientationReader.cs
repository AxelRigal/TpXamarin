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
    public class OrientationReader
    {

        public SensorSpeed speed = SensorSpeed.UI;
        public float OrrX, OrrY, OrrZ, OrrW;
        public bool isStarted;

        public OrientationReader()
        {
            OrientationSensor.ReadingChanged += OrientationSensor_ReadingChanged;
        }

        void OrientationSensor_ReadingChanged(object sender, OrientationSensorChangedEventArgs e)
        {
            var data = e.Reading;
            Console.WriteLine($"Orientation: X: {data.Orientation.X}, Y: {data.Orientation.Y}, Z: {data.Orientation.Z}, W: {data.Orientation.W}");
            OrrX = data.Orientation.X;
            OrrY = data.Orientation.Y;
            OrrZ = data.Orientation.Z;
            OrrW = data.Orientation.W;
        }

        public void ToggleOrientationSensor()
        {
            try
            {
                if (OrientationSensor.IsMonitoring)
                {
                    OrientationSensor.Stop();
                    isStarted = false;
                }

                else
                {
                    OrientationSensor.Start(speed);
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