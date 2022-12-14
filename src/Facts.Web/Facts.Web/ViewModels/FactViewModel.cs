using Facts.Web.Data;
using System;
using System.Collections.Generic;

namespace Facts.Web.ViewModels
{
    public class FactViewModel
    {
        public Guid Id { get; set; }

        public string Content { get; set; }

        public IEnumerable<TagViewModel> Tags { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
