using HotCatCafe.Model.Enums;

namespace HotCatCafe.Model.Interfaces
{
    public interface IEntity<T>
    {
        public int ID { get; set; }
        public T MasterId { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedComputerName { get; set; }
        public string CreatedIpAdress { get; set; }
      
        public DateTime UpdatedDate { get; set; }
        public string UpdatedComputerName { get; set; }
        public string UpdatedIpAdress { get; set; }
        public bool IsActive { get; set; }
        public DataStatus Status { get; set; }
    }
}
