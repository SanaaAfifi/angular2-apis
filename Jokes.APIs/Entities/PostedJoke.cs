using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Jokes.Entities
{
    public class PostedJoke
    {
        public PostedJoke()
        {
            Comments = new List<Comment>();
        }
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity), Key()]
        public int JokeId { get; set; }
        public string PostedBy { get; set; }
        [StringLength(200)]
        public string Content { get; set; }
        public DateTime PostedDate { get; set; }
        public int UpVotes { get; set; }
        public float DownVotes { get; set; }

        public bool IsHideen { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }

        public virtual ICollection<Vote> Votes { get; set; }

    }
}
