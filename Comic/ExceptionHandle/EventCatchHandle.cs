using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using WinFormTest.ExceptionHandle.CustomException;

namespace WinFormTest.ExceptionHandle
{
    public class EventCatchHandle
    {
        /// <summary>
        /// Exception處理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public static void ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            if (e.Exception is VaildationException)
            {
                MessageBox.Show(e.Exception.Message);
            }
            else
            {
                MessageBox.Show("系統錯誤！！！");
            }
        }
    }
}
