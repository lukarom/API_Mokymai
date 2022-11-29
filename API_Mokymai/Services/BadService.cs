namespace API_Mokymai.Services
{
    public class BadService : IBadService
    {
        private readonly ILogger<BadService> _logger;

        public BadService(ILogger<BadService> logger)
        {
            _logger = logger;
        }

        public string DoSomeWork()
        {
            _logger.LogInformation("Darbas prasideda");
            var a = "a";
            var b = int.Parse(a);
            _logger.LogInformation("BadService Darbas baigtas, grazinamas rezultatas b={b}", b);
            return "Darbas baigtas b=" + b;
        }

    }
}
