using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Invengo.Sample
{
    static class Program
    {
        /// <summary>
        /// Application 
        /// </summary>
        [MTAThread]
        static void Main()
        {
            Application.Run(new FrMenu());
        }
    }
}