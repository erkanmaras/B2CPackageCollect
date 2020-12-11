using System;

namespace B2CPackageCollect
{
    public class InvoiceLine
    {
        public string AlisverisID { get; set; }
       
        public string StokID { get; set; }
        public string StokKodu { get; set; }
        public string StokAdi { get; set; }
        public string RenkKodu { get; set; }
        public string Beden { get; set; }
        public decimal Miktar { get; set; }
        public decimal ToplananMiktar { get; set; }
        public decimal IslemID { get; set; }
         public bool AllCollected()
        {
            return ToplananMiktar >= Miktar ;
        }

        public bool SemiCollected()
        {
            return ToplananMiktar > 0 && Miktar > ToplananMiktar;
        }
    }

    public class InvoiceHeader
    {
        public string AlisverisID { get; set; }
        public DateTime FaturaTarihi { get; set; }
        public string FaturaNumarasi { get; set; }
        public string MusteriKodu { get; set; }
        public string AdiSoyadi { get; set; }
        public decimal FaturaTutari { get; set; }
        public bool Yazdirildi { get; set; }

       
    }
}
