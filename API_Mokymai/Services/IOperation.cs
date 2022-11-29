namespace API_Mokymai.Services
{
    public interface IOperation
    {
        string GetOperationId();
    }
    public interface IMyOperationTransient : IOperation { }
    public interface IMyOperationScoped : IOperation { }
    public interface IMyOperationSingleton : IOperation { }
}
