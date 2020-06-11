using System.Text.Json;
using System.Threading.Tasks;
using Dapper;
using DatabaseAccess.DataAccess.Interfaces;
using DatabaseAccess.DataAccess.Internal;
using DatabaseAccess.Helpers;
using Shared.Configuration;

namespace DatabaseAccess.DataAccess
{
    public class EmailTemplatesData : IEmailTemplatesData
    {
        private readonly ISqlDataAccess _sqlDataAccess;
        private readonly string _dbConnectionString;

        public EmailTemplatesData(ISqlDataAccess sqlDataAccess, IConfigProvider configProvider)
        {
            _sqlDataAccess = sqlDataAccess;
            _dbConnectionString = configProvider.GetConnectionString(Application.BandCamsDb);
        }

        /// <summary>
        /// Returns column dbo.EmailTemplates.Value serialized to provided type
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="templateName"></param>
        /// <returns></returns>
        public async Task<T> Get<T>(string templateName)
        {
            var parameters = CreateDynamicTemplateNameParameter(templateName);

            var value = await _sqlDataAccess.ExecuteStoredProcedureAsync(StoredProcedures.SpEmailTemplatesGet,
                _dbConnectionString, parameters);

            return JsonSerializer.Deserialize<T>(value.ToString());
        }

        private static DynamicParameters CreateDynamicTemplateNameParameter(string templateName)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@TemplateName", templateName);

            return parameters;
        }
    }
}
