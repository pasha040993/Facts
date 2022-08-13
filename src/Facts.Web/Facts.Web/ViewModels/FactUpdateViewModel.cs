using System;
using System.Collections.Generic;

namespace Facts.Web.ViewModels
{
    internal class FactUpdateViewModel
    {
        public Guid Id { get; set; }
        public string Content { get; set; }
        public IEnumerable<TagViewModel> Tags { get; set; }
    }
}