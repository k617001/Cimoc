using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Comic.Common
{
    /// <summary>
    /// 要操作不同Thread上的元件,且可以自行定義行為。
    /// </summary>
    public class ControlThreadActionHelper
    {


        delegate void HandlerAction<T>(T c, Action<T> action);

        /// <summary>
        /// 操作元件
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="c"></param>
        /// <param name="action"></param>
        public void Handler<T>(T c, Action<T> action) where T : Control
        {
            //判斷這個TextBox的物件是否在同一個執行緒上
            if (c.InvokeRequired)
            {
                HandlerAction<T> ph = new HandlerAction<T>(Handler);
                c.Invoke(ph, c, action);
            }
            else
            {
                action(c);
            }
        }
    }
}
