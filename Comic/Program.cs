using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormTest;
using WinFormTest.ExceptionHandle;
using WinFormTest.Register.MenuItem;
using WinFormTest.ViewController;

namespace Comic
{
    static class Program
    {
        /// <summary>
        /// 應用程式的主要進入點。
        /// </summary>
        [STAThread]
        static void Main()
        {
            //錯誤訊息，系統錯誤處理
            Application.ThreadException += new ThreadExceptionEventHandler(EventCatchHandle.ThreadException);

            //註冊功能
            MenuItemReg.Register();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new StartView2());
            //Application.Run(new ImageFolder());
        }
    }
}
