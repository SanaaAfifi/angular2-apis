using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jokes.Entities
{
    public class PhotoLibrary
    {
        public PhotoLibrary()
        {

        }
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity), Key()]
        public int ImageID { get; set; }
        public byte[] ImageContent { get; set; }
    }
}
