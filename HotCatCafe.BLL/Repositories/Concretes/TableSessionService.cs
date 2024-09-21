using HotCatCafe.BLL.Repositories.Abstracts;
using HotCatCafe.BLL.Repositories.Abstracts.BaseAbstracts;
using HotCatCafe.Model.Entities;

namespace HotCatCafe.BLL.Repositories.Concretes
{
    public class TableSessionService : ITableSessionService
    {
        private readonly IRepository<TableSession> _tableSessionRepository;

        public TableSessionService(IRepository<TableSession> tableSessionRepository)
        {
            _tableSessionRepository = tableSessionRepository;
        }
        public async Task<string> CreateTableSessionAsync(TableSession tableSession)
        {
            return await _tableSessionRepository.Create(tableSession);
        }

        public async Task<string> DeleteTableSessionAsync(TableSession tableSession)
        {
            return await _tableSessionRepository.Delete(tableSession);
        }

        public async Task<string> DestroyTableSessionAsync(TableSession tableSession)
        {
            return await _tableSessionRepository.DestroyData(tableSession);
        }

        public TableSession GetActiveTableSessionByTableId(int tableId)
        {
            return _tableSessionRepository.GetActives().FirstOrDefault(x => x.TableId == tableId&&x.IsActive==true);
        }

        public Task<string> UpdateTableSessionAsync(TableSession tableSession)
        {
            return _tableSessionRepository.Update(tableSession);
        }
    }
}
