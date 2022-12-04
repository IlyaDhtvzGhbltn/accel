using System.Threading.Tasks;

namespace ShortLinkService.Dto.Interfaces
{
    public interface IShortLinkService
    {
        /// <summary>
        /// Saves original link and token
        /// </summary>
        /// <param name="original">Original link</param>
        /// <param name="token">Short token</param>
        /// <returns></returns>
        Task AddCutLinkAsync(string original, string token, string bitmap);

        /// <summary>
        /// Checks that target token exist and return bool value.
        /// </summary>
        /// <param name="token"></param>
        /// <returns>true if token exist, otherwise false</returns>
        Task<bool> IsTokenExistAsync(string token);

        /// <summary>
        /// Returns original link by token
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        Task<string> GetOriginalLinkByTokenAsync(string token);

        /// <summary>
        /// Validates original link and returns bool value
        /// </summary>
        /// <param name="link"></param>
        /// <returns>true if link valid, otherwise false</returns>
        bool ValidateLink(string link);
    }
}
