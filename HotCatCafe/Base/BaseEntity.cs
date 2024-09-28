using HotCatCafe.Model.Enums;
using HotCatCafe.Model.Interfaces;

namespace HotCatCafe.Model.Base
{
    public abstract class BaseEntity : IEntity<Guid>
    {
        public BaseEntity()
        {
            CreatedDate = DateTime.Now; 
            CreatedComputerName=System.Environment.MachineName;
            CreatedIpAdress = "192.168.1.1";
            IsActive = true;
            MasterId = Guid.NewGuid();
            Status = DataStatus.INSERTED;
        }
        public int ID { get ; set ; }
        public Guid MasterId { get ; set ; }
        public DateTime CreatedDate { get ; set ; }
        public string CreatedComputerName { get ; set ; }
        public string CreatedIpAdress { get ; set ; }
        public DateTime UpdatedDate { get ; set ; }
        public string? UpdatedComputerName { get ; set ; }
        public string? UpdatedIpAdress { get ; set ; }
        public bool IsActive { get ; set ; }
        public DataStatus Status { get ; set ; }
    }
}
