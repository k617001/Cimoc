using Comic.Data.baseData;
using Comic.Data.DAO;
using Comic.Data.Entity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinFormTest.Config;

namespace Comic.Data.Impl
{
    public class SettingDaoImpl : BaseDAO<SettingEntity>, SettingDAO
    {
        string filePath = null;
        public SettingDaoImpl()
        {
            this.filePath = SysConfig.ROOT_DATA_PATH + "Setting.json";
            if (!File.Exists(this.filePath))
            {
                using (FileStream fs = File.Create(filePath))
                {
                }
            }
        }

        /// <summary>
        /// 記錄漫畫路徑
        /// </summary>
        /// <param name="comicUrl"></param>
        public void SaveComicUrl(string comicUrl)
        {
            SettingEntity entity = this.Find();
            entity.ComicUrl = comicUrl;

            File.WriteAllText(filePath, JsonConvert.SerializeObject(entity));
        }

        /// <summary>
        /// 查詢設定
        /// </summary>
        /// <param name="comicUrl"></param>
        public SettingEntity Find()
        {
            SettingEntity entity = null;
            using (StreamReader sr = new StreamReader(this.filePath))
            {
                JsonSerializer se = new JsonSerializer();
                entity = (SettingEntity)se.Deserialize(new JsonTextReader(sr), typeof(SettingEntity));
            }
            if (entity == null)
            {
                entity = new SettingEntity();
            }

            return entity;
        }
    }
}
