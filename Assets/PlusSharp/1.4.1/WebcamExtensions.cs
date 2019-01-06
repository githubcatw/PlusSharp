using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NUDev.PlusSharp.v141
{
    public static class WebcamExtensions
    {
        public static WebCamDevice[] AllDevices(this WebCamDevice dev)
        {
            WebCamDevice[] devices = WebCamTexture.devices;

            for (int i = 0; i < devices.Length; i++)
            {
                Debug.Log("Number " + i + " - " + devices[i].name);
            }

            return devices;
        }
    }
}