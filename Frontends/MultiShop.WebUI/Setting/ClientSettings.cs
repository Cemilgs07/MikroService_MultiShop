namespace MultiShop.WebUI.Setting
{
	public class ClientSettings
	{
        public Client MultiShopVisitorClient { get; set; }
        public Client MultiShopManagerClient { get; set; }
        public Client MultiShopManagerAdminClient { get; set; }
    }
	public class Client
	{
        public string ClientId { get; set; }
        public string ClientScret { get; set; }
    }
}
