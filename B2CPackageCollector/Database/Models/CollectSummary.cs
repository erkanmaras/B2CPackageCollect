using System;

namespace B2CPackageCollect
{
    public class CollectReportLine
    {
        public string AlisverisID { get; set; }
        public DateTime FaturaTarihi { get; set; }
        public string FaturaNumarasi { get; set; }
        public string MusteriKodu { get; set; }
        public string AdiSoyadi { get; set; }
        public decimal FaturaTutari { get; set; }

        public string StokID { get; set; }
        public string StokKodu { get; set; }
        public string Barkod { get; set; }
        public string StokSinifi { get; set; }
        public string RenkKodu { get; set; }
        public string Beden { get; set; }
        public decimal Miktar { get; set; }
        public decimal IslemID { get; set; }
        public decimal Gun { get; set; }

        public decimal ToplananMiktar { get; set; }
        public bool Yazdirildi { get; set; }
        public bool Tamamlandi { get; set; }
       

        public bool Collected()
        {
            return ToplananMiktar >= Miktar || (Tamamlandi && Yazdirildi);
        }

        public void MarkCollected()
        {
            Tamamlandi = true;
            Yazdirildi = true;
        }

        public bool Completed()
        {
            return Tamamlandi;
        }
        public bool Printed()
        {
            return Yazdirildi;
        }
    }


}
