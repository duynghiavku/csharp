using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeNguyenDuyNghia_20IT323
{
    internal class Program
    {
        static void BT4_3()
        {
            DS_Xe x = new DS_Xe();
            x.NhapDS();
            x.XuatDS();
            x.DemXeMay();
            x.DemXeHoi();
        }
        static void Main(string[] args)
        {
            BT4_3();
            Console.ReadKey();
        }
    }
}
