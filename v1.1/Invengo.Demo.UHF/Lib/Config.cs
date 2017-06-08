using System;

using System.Collections.Generic;
using System.Text;
using Invengo.Platform;

namespace Invengo.Sample
{

    public class Config
    {
        public static PDAInfo.DevModel _pdamodel;

        public static bool IsXC2903()
        {
            bool IsXC2903 = false;
            _pdamodel = PDAInfo.GetDevModel();
            if (_pdamodel == PDAInfo.DevModel.XC2903)
            {
                IsXC2903 = true;

            }
            return IsXC2903;
        }
    }
}
