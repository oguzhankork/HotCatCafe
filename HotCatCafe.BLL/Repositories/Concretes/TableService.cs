using HotCatCafe.BLL.Repositories.Abstracts;
using HotCatCafe.BLL.Repositories.Abstracts.BaseAbstracts;
using HotCatCafe.Model.Entities;

namespace HotCatCafe.BLL.Repositories.Concretes
{
    public class TableService : ITableService
    {
        private readonly IRepository<Table> _tableRepository;

        public TableService(IRepository<Table> tableRepository)
        {
            _tableRepository = tableRepository;
        }

        public IEnumerable<Table> GetAllTables()
        {
            return _tableRepository.GetAll();
        }

        public Table GetTableById(int id)
        {
            return _tableRepository.GetByID(id);
        }

        public async Task<string> UpdateTableAsync(Table table)
        {
            return await _tableRepository.Update(table);
        }
    }
}
