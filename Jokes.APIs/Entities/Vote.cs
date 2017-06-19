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
    public class Vote {
        public Vote()
        {

        }
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity), Key()]
        public int VoteID { get; set; }
        public PostedJoke Joke { get; set; }
        public string VotedBy { get; set; }
        public DateTime PostedDate { get; set; }
        bool Up { get; set; } }

}
