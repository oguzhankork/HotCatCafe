using HotCatCafe.Model.Entities;

namespace HotCatCafe.BLL.Repositories.Abstracts
{
    public interface ITableSessionService
    {
        Task<string> CreateTableSessionAsync(TableSession tableSession);
        Task<string> DeleteTableSessionAsync(TableSession tableSession);
        Task<string> UpdateTableSessionAsync(TableSession tableSession);       
        TableSession GetActiveTableSessionByTableId(int tableId);
        Task<string> DestroyTableSessionAsync(TableSession tableSession);
    }
}
