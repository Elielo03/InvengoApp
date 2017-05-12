using System;
using System.Collections.Generic;
using System.Text;
using Invengo.Devices.ModuleControl;
using System.Runtime.InteropServices;
using System.Threading;

namespace Invengo.Sample
{
   

    public static class GprsTool
    {       
        public static bool IsOnPower = false;
        public static bool IsOnConnect = false;

        static GprsTool()
        {
            
        }

    

        /// <summary>
        /// OnPower
        /// </summary>
        /// <returns></returns>
        public static bool Open()
        {
            if(GprsControl.IsActived())
            {
                GprsControl.Deactive();
                Thread.Sleep(200);
            }            
            
            IsOnPower = GprsControl.Active() > 0;
            Thread.Sleep(5000);          
            return IsOnPower;
        }

        /// <summary>
        /// Call GPRS
        /// </summary>
        /// <returns></returns>
        public static bool Call()
        {
            if (!IsOnPower) return false;
            if (IsOnConnect) return true;
            IsOnConnect=GprsControl.Connect();
            return IsOnConnect;
        }

        /// <summary>
        /// Dispose Call
        /// </summary>
        /// <returns></returns>
        public static bool DisCall()
        {
            //if (!IsOnPower) return true;
            //if (!IsOnConnect) return true;
            bool b=GprsControl.Disconnect();
            if (b) IsOnConnect = false;
            return b;  
        }

        public static bool PowerOff()
        {
             bool b=GprsControl.Deactive();
            if (b)
            {
                IsOnPower = false;
                IsOnConnect = false;
            }
            return b;
        }

        /// <summary>
        /// Close GPRS
        /// </summary>
        public static bool Close()
        {
            DisCall();
           return PowerOff();
        }

    }
}
