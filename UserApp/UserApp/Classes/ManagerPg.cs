using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
namespace UserApp.Classes
{
    public class ManagerPg
    {
        ManagerPg() 
        {
            RecFrame.Navigate(new PgRec());
        }
        public static Frame RecFrame { get; set; }

    }
}
