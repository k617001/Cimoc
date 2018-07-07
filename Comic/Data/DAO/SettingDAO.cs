using Comic.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comic.Data.DAO
{
    public interface SettingDAO
    {
        void SaveComicUrl(string comicUrl);

        /// <summary>
        /// 查詢設定
        /// </summary>
        /// <param name="comicUrl"></param>
        SettingEntity Find();
    }
}
