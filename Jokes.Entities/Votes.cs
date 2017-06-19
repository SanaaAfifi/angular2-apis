using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Jokes.Entities
{
    public class Votes {
        public Votes()
        {

        }
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity), Key()]
        public int VoteID { get; set; }
        public PostedJokes Joke { get; set; }
        public string VotedBy { get; set; }
        public DateTime PostedDate { get; set; }
        bool Up { get; set; } }

}
