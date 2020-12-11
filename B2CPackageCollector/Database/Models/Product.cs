using System.Text;

namespace B2CPackageCollect
{
    public class Product
    {
        private string _barcode;
        private string _stokKodu;
        private string _stokAdi;
        private string _renkAdi;
        private string _beden;

        public string Barcode
        {
            get => _barcode ?? string.Empty;
            set => _barcode = value;
        }

        public string StokKodu
        {
            get => _stokKodu ?? string.Empty;
            set => _stokKodu = value;
        }

        public string StokAdi
        {
            get => _stokAdi ?? string.Empty;
            set => _stokAdi = value;
        }

        public string RenkAdi
        {
            get => _renkAdi ?? string.Empty;
            set => _renkAdi = value;
        }

        public string Beden
        {
            get => _beden ?? string.Empty;
            set => _beden = value;
        }

        public override string ToString()
        {
            var builder = new StringBuilder();
            builder.Append(StokAdi);
            if (!string.IsNullOrWhiteSpace(_renkAdi))
            {
                builder.AppendFormat("/{0}", _renkAdi);
            }

            if (!string.IsNullOrWhiteSpace(_beden))
            {
                builder.AppendFormat("/{0}", _beden);
            }

            return builder.ToString();
        }
    }
}
