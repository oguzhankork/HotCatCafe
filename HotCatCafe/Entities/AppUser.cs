using HotCatCafe.Model.Enums;
using Microsoft.AspNetCore.Identity;



namespace HotCatCafe.Model.Entities
{
    public class AppUser : IdentityUser<Guid>
    {
        public DateTime? BirtDate { get; set; }
        public string? Address { get; set; }
        public Gender Gender { get; set; }
        public virtual List<Order> Orders { get; set; }
    }
}
