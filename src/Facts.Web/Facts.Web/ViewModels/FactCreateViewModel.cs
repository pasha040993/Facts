using System.Collections.Generic;

namespace Facts.Web.ViewModels
{
    internal class FactCreateViewModel
    {
        public string Content { get; set; }

        public IEnumerable<string> Tags { get; set; }
    }
}