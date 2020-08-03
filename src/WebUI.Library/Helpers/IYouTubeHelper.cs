namespace WebUI.Library.Helpers
{
    public interface IYouTubeHelper
    {
        /// <summary>
        /// Returns link ready to put in src attribute of iframe element
        /// </summary>
        /// <param name="link">Link copied from YT</param>
        /// <returns></returns>
        string GetEmbedVideoLink(string link);

        /// <summary>
        /// Return link of thumbnail ready to put in src attribute
        /// </summary>
        /// <param name="link">Embed video link</param>
        /// <returns></returns>
        string GetThumbnailLink(string link);
    }
}