using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeNguyenDuyNghia_20IT323
{
    internal class Xe
    {
        protected string tenxe;
        protected string mauxe;
        protected int giaxe;

        public Xe(string t="LNDN", string m = "LNDN", int g = 0)        {
            tenxe = t;
            this.mauxe = m;
            this.giaxe = g;
        }

        public virtual void Nhap()
        {
            Console.WriteLine("Nhap ten xe: ");
            tenxe = Console.ReadLine();
            Console.WriteLine("Nhap mau xe: ");
            mauxe = Console.ReadLine();
            Console.WriteLine("Nhap gia xe: ");
            while (!int.TryParse(Console.ReadLine(),out giaxe) || giaxe < 0)
                Console.WriteLine("Nhap lai gia xe: ");
        }

        public virtual float TinhLePhi()
        {
            return 0;
        }

        public void Xuat()
        {
            Console.WriteLine($"Ten xe: {tenxe}, Mau xe: {mauxe}, Gia xe: {giaxe}, Le Phi Truoc Ba: {TinhLePhi()}");
        }
    }

    class XeMay : Xe
    {
        bool dkld;
        public XeMay(string t = "LNDN", string m = "LNDN", int g = 0, bool dk = false):base(t, m, g) 
        {
            dkld = dk;
        }
        public override void Nhap()
        {
            base.Nhap();
            Console.WriteLine("Dang ky lan dau (true/false): ");
            while(!bool.TryParse(Console.ReadLine(), out dkld))
                Console.WriteLine("Dang ky lan dau (true / false): ");
        }

        public override float TinhLePhi()
        {
            if (dkld)
            {
                return 0.5f * giaxe;
            }
            else
            {
                return 0.01f * giaxe;
            }
        }
    }

    class XeHoi : Xe
    {
        int loaixe;
        public XeHoi(string t = "LNDN", string m = "LNDN", int g = 0,int loai = 0):base(t, m, g)
        {
            loaixe = loai;
        }
        public override void Nhap()
        {
            base.Nhap();
            Console.WriteLine("Nhap loai xe: ");
            while(!int.TryParse(Console.ReadLine(), out loaixe)) 
                Console.WriteLine("Nhap loai xe: ");
        }
        public override float TinhLePhi()
        {
            if (loaixe == 1)
            {
                return 0.1f * giaxe;
            }else if (loaixe == 1)
            {
                return 0 * giaxe;
            }
            else
            {
                return 0.02f * giaxe;
            }
        }
    }

    class DS_Xe
    {
        int n;
        List<Xe> ds;
        public void NhapDS()
        {
            Console.WriteLine("Nhap n: ");
            while (!int.TryParse(Console.ReadLine(), out n) || n < 2 || n > 20)
                Console.WriteLine("Nhap lai n: ");
            ds = new List<Xe>();
            for(int i=0; i < n; i++)
            {
                int chon;
                Console.WriteLine("(1) Xe May\n(2) Xe Hoi: ");
                while (!int.TryParse(Console.ReadLine(), out chon)||chon!=1&&chon!=2)
                    Console.WriteLine("(1) Xe May\n(2) Xe Hoi: ");
                Xe x;
                if (chon == 1)
                {
                    x = new XeMay();
                }
                else
                {
                    x = new XeHoi();
                }
                x.Nhap();
                ds.Add(x);
            }
        }
        public void XuatDS()
        {
            for(int i = 0;i < n;i++)
            {
                ds[i].Xuat();
            }
        }
        public void DemXeMay()
        {
            int dem = 0;
            for(int i = 0;i < n;i++) 
            {
                if (ds[i].GetType() == typeof(XeMay))
                {
                    ++dem;
                }
            }
            Console.WriteLine($"So luong xe may trong danh sach xe la {dem}");
        }

        public void DemXeHoi()
        {
            float dem = 0;
            float sum = 0;
            for( int i = 0;i < n; i++)
            {
                if (ds[i].GetType() == typeof(XeHoi))
                {
                    dem++;
                    sum += ds[i].TinhLePhi();
                }
            }
            Console.WriteLine($"Trung binh le phi truoc ba xe hoi: {sum / dem}");
        }
    }
}
