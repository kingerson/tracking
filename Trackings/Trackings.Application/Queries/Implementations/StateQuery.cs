using Dapper;
using Mapster;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Trackings.Application.Queries.Implementations
{
    public class StateQuery: IStateQuery
    {
        private string _connectionString = string.Empty;
        public StateQuery(string constr) => _connectionString = !string.IsNullOrWhiteSpace(constr) ? constr : throw new ArgumentException(nameof(constr));

        public async Task<IEnumerable<StateViewModel>> findAll()
        {
            IEnumerable<StateViewModel> result;
            using (var cn = new MySqlConnection(_connectionString))
            {
                await cn.OpenAsync();
                result = (await cn.QueryAsync<StateViewModel>("state__find_all", commandType: CommandType.StoredProcedure)).Adapt<IEnumerable<StateViewModel>>();
            }
            return result;
        }

        public async Task<StateViewModel> findById(int parentId,int userTypeId)
        {
            StateViewModel result;
            using (var cn = new MySqlConnection(_connectionString))
            {
                await cn.OpenAsync();
                var parameters = new DynamicParameters();
                parameters.Add("@p_parent_id", parentId);
                parameters.Add("@p_user_type_id", userTypeId);
                result = await cn.QueryFirstOrDefaultAsync<StateViewModel>("state__find_by_id", parameters, commandType: CommandType.StoredProcedure);
            }
            return result;
        }
    }
}
