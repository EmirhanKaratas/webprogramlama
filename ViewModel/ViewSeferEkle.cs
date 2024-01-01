using Proje.Models.siniflar;
using System.ComponentModel.DataAnnotations.Schema;

namespace Proje.ViewModel
{
    public class ViewSeferEkle
    {
		public int SeferId { get; set; }
		public string güzergah { get; set; }
		public DateTime Gün { get; set; }
		public string Saat { get; set; }
		public double Fiyat { get; set; }
		public string Image { get; set; }
		public int Kapasite { get; set; }
		public string GüzergahSehir1 { get; set; }
		public string GüzergahSehir2 { get; set; }


	}
}
