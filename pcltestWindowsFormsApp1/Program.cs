using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

// 原始代码
namespace pcltestWindowsFormsApp1
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}

// opentk示例
//namespace OpentkTutorials
//{
//    class Program
//    {
//        static void Main()
//        {
//            using (var game=new Game())
//            {
//                game.Run(30.0);
//            }
//        }
//    }
//}