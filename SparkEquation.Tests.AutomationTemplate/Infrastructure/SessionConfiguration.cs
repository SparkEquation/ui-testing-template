namespace SparkEquation.Tests.AutomationTemplate.Infrastructure
{
    public class SessionConfiguration
    {
        public SessionConfiguration(LoginProvider loginProvider)
        {
            AdminLoginData = loginProvider.GetAdmin();
            ProducerLoginData = loginProvider.GetProducer();
            ClientLoginData = loginProvider.GetClient();
            DistributorLoginData = loginProvider.GetDistributor();
            TalentLoginData = loginProvider.GetTalent();
        }
        public LoginData AdminLoginData { get; set; }
        public LoginData ProducerLoginData { get; set; }
        public LoginData ClientLoginData { get; set; }
        public LoginData DistributorLoginData { get; set; }
        public LoginData TalentLoginData { get; set; }

        public string BaseUrl { get; set; }
        public string Tenant { get; set; }

        public int TestPhotoId { get; set; }

        public string TestCampaignJsonFile { get; set; }

        public string BaseFilePath { get; set; }
    }
}
