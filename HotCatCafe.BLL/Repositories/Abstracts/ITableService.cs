using HotCatCafe.Model.Entities;

namespace HotCatCafe.BLL.Repositories.Abstracts
{
    public interface ITableService
    {
        IEnumerable<Table> GetAllTables();
        
        Table GetTableById(int id);

        Task<string> UpdateTableAsync(Table table);
    }
}
