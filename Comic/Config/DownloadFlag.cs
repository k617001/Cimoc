using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comic.Config
{
    public class DownloadFlag
    {
        public static DownloadEnum DOWNLOAD_FLAG = DownloadEnum.NONE;
    }

    public enum DownloadEnum
    {
        NONE,
        ING
    }
}
