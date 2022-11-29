namespace API_Mokymai.Services
{
    public class DivideByZero : IDivideByZero
    {
        private readonly ILogger<DivideByZero> _logger;

        public DivideByZero(ILogger<DivideByZero> logger)
        {
            _logger = logger;
        }

        public double DividingByZero(int x, int y)
        {
            _logger.LogInformation("Daliname skaicius is nulio");
            return x/y;
        }
    }
}
