using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Jokes.Entities
{
    public class Comments
    {
        public Comments()
        {

        }
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity), Key()]
        public int CommentId { get; set; }
        public PostedJokes Joke { get; set; }
        public string PostedBy { get; set; }
        [StringLength(200)]
        public string Content { get; set; }
        public DateTime PostedDate { get; set; }
        public bool IsHideen { get; set; }

    }
}
