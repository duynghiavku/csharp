using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAI_THI_NAM_NGOAI
{
    internal class Program
    {
        static void BT1()
        {
            DS_MHNK mn = new DS_MHNK();
            mn.NhapDS();
            mn.XuatDS();
            mn.TinhSoTien();
            mn.TinhTienThue();
        }
        static void Main(string[] args)
        {
            BT1();
            Console.ReadKey();
        }
    }
}