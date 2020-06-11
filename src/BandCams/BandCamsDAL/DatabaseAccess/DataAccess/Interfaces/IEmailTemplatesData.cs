using System.Threading.Tasks;

namespace DatabaseAccess.DataAccess.Interfaces
{
    public interface IEmailTemplatesData
    {
        Task<T> Get<T>(string templateName);
    }
}