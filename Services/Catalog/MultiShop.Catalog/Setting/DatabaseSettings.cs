namespace MultiShop.Catalog.Setting
{
    public class DatabaseSettings : IDataBaseSettings
    {
        public string CategoryCollectionName { get; set; }
        public string ProductCollectionName { get; set; }
        public string ProductDetailCollectionName { get; set; }
        public string ProductImageCollectionName { get; set; }
        public string FeaturesSliderNameCollectionName { get; set; }
        public string SpecialOftterCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
        public string AboutCollectionName { get; set; }
    }
}
