using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomikCrawler.src.ComicMessage
{
    public class ConsoleMessage : IMessage
    {
        public void ShowMessage(string message)
        {
            Console.Write("\n\n" + message);
        }
    }
}
