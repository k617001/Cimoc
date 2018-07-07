using Comic.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comic.Data.DAO
{
    public interface NewComicLogDAO
    {
        /// <summary>
        /// 查詢清單
        /// </summary>
        /// <returns></returns>
        List<NewComicLogEntity> FindList();

        /// <summary>
        /// 取得根目錄
        /// </summary>
        /// <returns></returns>
        string GetRootPath();
    }
}
