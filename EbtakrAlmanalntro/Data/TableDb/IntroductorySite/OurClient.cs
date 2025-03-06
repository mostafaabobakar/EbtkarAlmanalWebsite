namespace EbtakrAlmanalntro.Data.TableDb.IntroductorySite
{
    public class OurClient
    {
        public int ID { get; set; }
        public string NameAr { get; set; }
        public string NameEn { get; set; }
        public string DescriptionAr { get; set; }
        public string DescriptionEn { get; set; }
        public string ImageUrl { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
    }
}
