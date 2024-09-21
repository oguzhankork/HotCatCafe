using Microsoft.AspNetCore.Identity;

namespace HotCatCafe.Model.Entities
{
    public class AppUserRole:IdentityRole<Guid>
    {
        public string Description { get; set; }
    }
}
