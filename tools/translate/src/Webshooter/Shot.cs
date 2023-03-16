using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Webshooter
{
    internal class Shot
    {
        /// <summary>
        /// Output filename.
        /// </summary>
        public string? Output;
        /// <summary>
        /// URL for page, possibly relative to base-page
        /// </summary>
        public string? Url;
        /// <summary>
        /// width x height
        /// </summary>
        public string? WindowSize;
        /// <summary>
        /// CSS or XPath locator. NULL is whole page
        /// </summary>
        public string? Element;

        /// <summary>
        /// Steps to execute before taking the shot
        /// </summary>
        public List<ShotStep> Before;

        /// <summary>
        /// Steps to execute after taking the shot
        /// </summary>
        public List<ShotStep> After;
    }

    internal class ShotStep
    {
        public string Click;
        public TextStep Type;
        public string WaitForUrl;
        public string WaitForVisible;
        public string WaitForHidden;
    }

    internal class TextStep
    {
        public string Element;
        public string Text;
    }
}
