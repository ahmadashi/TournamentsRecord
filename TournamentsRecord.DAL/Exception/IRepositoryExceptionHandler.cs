namespace TournamentsRecord.DAL.Exception
{
    public interface IRepositoryExceptionHandler
    {
        System.Exception Handle(System.Exception ex);
    }
}
