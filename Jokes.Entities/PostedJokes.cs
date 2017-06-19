using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Jokes.Entities
{
    public class PostedJokes
    {
        public PostedJokes()
        {
            Comments = new List<Comments>();
        }
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity), Key()]
        public int JokeId { get; set; }
        public IdentityUser PostedBy { get; set; }
        [StringLength(200)]
        public string Content { get; set; }
        public DateTime PostedDate { get; set; }
        public int UpVotes { get; set; }
        public float DownVotes { get; set; }

        public bool IsHideen { get; set; }
        public virtual ICollection<Comments> Comments { get; set; }

        public virtual ICollection<Votes> Votes { get; set; }

    }
}
