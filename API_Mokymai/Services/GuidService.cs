namespace API_Mokymai.Services
{
    public class GuidService : IMyOperationTransient, IMyOperationScoped, IMyOperationSingleton
    {
        private readonly string _operationId;

        public GuidService()
        {
            _operationId = Guid.NewGuid().ToString();
        }

        public string GetOperationId()
        {
            return _operationId;
        }
    }
}
