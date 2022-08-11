using Calabonga.EntityFrameworkCore.Entities.Base;
using System.Collections.Generic;

namespace Facts.Web.Data
{
    public class Fact : Auditable
    {
        public string Content { get; set; }

        public ICollection<Tag> Tags { get; set; }
    }
}
