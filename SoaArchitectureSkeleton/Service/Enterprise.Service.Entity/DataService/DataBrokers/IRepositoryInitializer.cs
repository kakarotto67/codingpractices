namespace Enterprise.Service.Client.DataService.DataBrokers
{
    internal interface IRepositoryInitializer<T>
        where T : class
    {
        T Repository { get; set; }
    }
}
