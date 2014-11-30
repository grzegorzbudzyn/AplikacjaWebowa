using System.ComponentModel.DataAnnotations;
using System.Globalization;
namespace AplikacjaWebowa.Models
{
    public class Kontakty
    {
        public int KontaktyId { get; set; }
        public string Nazwa { get; set; }
        public string Adres { get; set; }
        public string Miasto { get; set; }
        public string Stan_Kontenera { get; set; }
        public string Nr_Kontenera { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
    }
}