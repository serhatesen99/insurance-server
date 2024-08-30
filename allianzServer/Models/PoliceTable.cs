namespace allianzServer.Models
{
    public class PoliceTable
    {
        public int Id { get; set; }
        public DateTime? BasTarih { get; set; }
        public DateTime? BitTarih { get; set; }
        public string? Yer { get; set; }
        public string? Sebeb { get; set; }

        public int? MusteriId { get; set; }

        public int? OdemeId { get; set; }




    }
}
