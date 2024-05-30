using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAI_THI_NAM_NGOAI
{
    internal class MatHang
    {
        protected string maso;
        protected string tenhang;
        protected int dongia;
        public MatHang(string m = "123AB", string t = "NVA", int d = 100)
        {
            maso = m;
            tenhang = t;
            dongia = d;
        }
        public virtual void Nhap()
        {
            Console.WriteLine("Nhap ma so : ");
            maso = Console.ReadLine();
            Console.WriteLine("Nhap ten hang : ");
            tenhang = Console.ReadLine();
            Console.WriteLine("Nhap don gia nhap : ");
            while (!int.TryParse(Console.ReadLine(), out dongia) || dongia < 0)
            {
                Console.WriteLine("Nhap lai don gia nhap : ");
            }
        }
        public virtual void Xuat()
        {
            Console.WriteLine($"Ma so : {maso}, Ten hang : {tenhang}, Don gia nhap : {dongia}");
        }
        public virtual float TinhGiaBan()
        {
            return dongia * 1.2f;
        }
    }
    interface IThue
    {
        float thuenk { get; set; }
        float TinhThue();
    }
    class MatHangNK : MatHang, IThue
    {
        DateTime ngaynhap = new DateTime(2023, 05, 02);
        float thue;
        public float thuenk { get => thue; set => thue = value; }
        public DateTime Ngaynhap { get => ngaynhap; set => ngaynhap = value; }

        public MatHangNK(string m = "123AB", string t = "NVA", int d = 100, float th = 0.08f) : base(m, t, d)
        {
            thue = th;
        }
        public override void Nhap()
        {
            base.Nhap();
            Console.WriteLine("Nhap thue : ");
            while (!float.TryParse(Console.ReadLine(), out thue) || thue < 0)
            {
                Console.WriteLine("Nhap lai thue : ");
            }
        }
        public float TinhThue()
        {
            return thuenk * dongia;
        }
        public override float TinhGiaBan()
        {
            return base.TinhGiaBan() + TinhThue();
        }
        public override void Xuat()
        {
            base.Xuat();
            Console.WriteLine($"Tien thue nhap khau : {TinhThue()}, Gia ban mat hang nhap khau : {TinhGiaBan()}");
        }
    }
    class DS_MHNK
    {
        int n;
        List<MatHangNK> ds;
        public void NhapDS()
        {
            Console.WriteLine("Nhap n : ");
            while (!int.TryParse(Console.ReadLine(), out n) || n < 0 || n > 30)
            {
                Console.WriteLine("Nhap lai n : ");
            }
            ds = new List<MatHangNK>(n);
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"Nhap mat hang thu {i + 1} : ");
                MatHangNK mh = new MatHangNK();
                mh.Nhap();
                ds.Add(mh);
            }
        }
        public void XuatDS()
        {
            for (int i = 0; i < n; i++)
            {
                ds[i].Xuat();
            }
        }
        public void TinhSoTien()
        {
            float sum = 0;
            for (int i = 0; i < n; i++)
            {
                if (ds[i].Ngaynhap.Year == 2022)
                {
                    sum += ds[i].TinhGiaBan();
                }
            }
            Console.WriteLine($"Tong so tien ban cac Mat hang nhap khau trong nam 2022 : {sum}");
        }
        public void TinhTienThue()
        {
            float sum = 0;
            for (int i = 0; i < n; i++)
            {
                sum += ds[i].TinhThue();
            }
            Console.WriteLine($"Tien thue trung binh cua cac Mat hang nhap khau : {sum / n}");
        }
    }

}