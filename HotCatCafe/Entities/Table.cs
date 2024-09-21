using HotCatCafe.Model.Base;
using HotCatCafe.Model.Enums;

namespace HotCatCafe.Model.Entities
{
    public class Table : BaseEntity
    {
        public string TableNumber { get; set; }
        public string TableName { get; set; }
        public TableSituation? TableSituation { get; set; }
        public ICollection<TableSession> TableSessions { get; set; }
        public ICollection<Order> Orders { get; set; }

    }
}
