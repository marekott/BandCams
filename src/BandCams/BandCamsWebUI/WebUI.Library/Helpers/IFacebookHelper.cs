namespace WebUI.Library.Helpers
{
    public interface IFacebookHelper
    {
        /// <summary>
        /// Returns link ready to put in src attribute of iframe element
        /// </summary>
        /// <param name="link">Link copied from Facebook video</param>
        /// <returns></returns>
        string GetEmbedVideoLink(string link);
    }
}