using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Odyssey
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Form1 form1 = new Form1();
            Model model = new Model();
            Controller controller = new Controller();
            model.SetController(controller);
            controller.SetModel(model);
            controller.SetForm1(form1);
            form1.SetController(controller);
            Application.Run(form1);
            
        }
    }
}
