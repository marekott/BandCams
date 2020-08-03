using System;
using System.Text.RegularExpressions;

namespace WebUI.Library.Helpers
{
    public class FacebookHelper : IFacebookHelper
    {
        private string _constUrl = "https://www.facebook.com/video/embed?video_id=";

        /// <summary>
        /// Returns link ready to put in src attribute of iframe element
        /// </summary>
        /// <param name="link">Link copied from Facebook video</param>
        /// <returns></returns>
        public string GetEmbedVideoLink(string link)
        {
            var pattern = "\\/([0-9]{1,})\\/";
            var match = Regex.Match(link, pattern);
            if (match.Captures.Count == 0)
            {
                throw new Exception($"Invalid link, expected format https://www.facebook.com/XXX/videos/Id/ but was {link}");
            }

            return _constUrl + match.Groups[1].Value;
        }
    }
}
