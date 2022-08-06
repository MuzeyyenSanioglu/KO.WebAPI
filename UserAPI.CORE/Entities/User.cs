using Microsoft.AspNetCore.Identity;

namespace UserAPI.CORE.Entities
{
    public class User : IdentityUser
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public int BrandId { get; set; }
    }
}
