using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Comic.Data.Entity;
using Comic.Data.baseData;
using Comic.Data.DAO;
using WinFormTest.Common;
using WinFormTest.Config;
using System.IO;

namespace Comic.Data.Impl
{
    public class NewComicLogDaoImpl : BaseDAO<NewComicLogEntity>, NewComicLogDAO
    {
        SettingEntity settingEntity = null;
        string rootUrl = null;
        public NewComicLogDaoImpl()
        {
            SettingDAO setting = new SettingDaoImpl();
            this.settingEntity = setting.Find();
            rootUrl = settingEntity.ComicUrl + @"\_Log";

        }
        public List<NewComicLogEntity> FindList()
        {
            return Directory.EnumerateFiles(rootUrl).Select(s =>
            {
                Uri uri = new Uri(s);
                string fileName = null;
                if (uri.IsFile)
                {
                    fileName = Path.GetFileName(uri.LocalPath);
                }
                return new NewComicLogEntity()
                {
                    LogUrl = s,
                    FileName = fileName,
                };
            })
            .OrderByDescending(o => o.FileName)
            .ToList();

        }


        /// <summary>
        /// 取得根目錄
        /// </summary>
        /// <returns></returns>
        public string GetRootPath()
        {
            return rootUrl;
        }
    }
}
