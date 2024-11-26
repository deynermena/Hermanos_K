using System.Collections.Generic;

namespace HermanosK.Models
{
    public class Role
    {
        public Role()
        {
            Users = new HashSet<User>();
        }

        public int RoleId { get; set; }
        public string Name { get; set; }
        
        // Navegación
        public virtual ICollection<User> Users { get; set; }
    }
}
