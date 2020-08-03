using System;

namespace WebUI.Library.Helpers
{
    public class YouTubeHelper : IYouTubeHelper
    {
        private const string EmbedConstUrl = "https://www.youtube.com/embed/";
        private const string ThumbnailConstUrl = "https://img.youtube.com/vi";
        private const string ThumbnailConstImgVersion = "/0.jpg";

        public string GetEmbedVideoLink(string link)
        {
            var separatorIndex = link.IndexOf('=');
            if (separatorIndex == -1)
            {
                throw new Exception($"Invalid link, expected format https://www.youtube.com/watch?v=Id but was {link}");
            }
            var videoId = link.Substring(separatorIndex + 1);

            return EmbedConstUrl + videoId;
        }

        
        public string GetThumbnailLink(string link)
        {
            var separatorIndex = link.LastIndexOf('/');
            var id = link.Substring(separatorIndex);

            return ThumbnailConstUrl + id + ThumbnailConstImgVersion;
        }
    }
}
