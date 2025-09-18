using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assignments_4._2
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            using var login = new LoginForm();
            if (login.ShowDialog() == DialogResult.OK)
            {
                Application.Run(new TeacherForm());
            }
            // If login cancelled/failed, app exits.
        }
    }
}