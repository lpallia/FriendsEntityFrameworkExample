using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class User
    {

        public User()
        {
            this.Agendas = new List<Agenda>(); 
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }

        public virtual ICollection<Agenda> Agendas { get; set; }
        //public Guid IdAgenda;

        //public Guid IdOwnedAgenda;
    }
}
