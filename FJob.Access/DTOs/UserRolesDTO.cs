using NullGuard;

namespace FJob.Access.DTOs;

public class UserRolesDTO
{
    public string UserId { get; set; }
    [AllowNull]
    public IEnumerable<RoleDTO>? Roles { get; set; }

}
