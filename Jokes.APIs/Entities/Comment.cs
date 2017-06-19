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
    public class Comment
    {
        public Comment()
        {

        }
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity), Key()]
        public int CommentId { get; set; }
        public PostedJoke Joke { get; set; }
        public string PostedBy { get; set; }
        [StringLength(200)]
        public string Content { get; set; }
        public DateTime PostedDate { get; set; }
        public bool IsHideen { get; set; }

    }
}
