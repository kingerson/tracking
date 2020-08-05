using Dapper;
using Mapster;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Trackings.Application.Queries.Mappers;

namespace Trackings.Application.Queries.Implementations
{
    public class ReceiverQuery : IReceiverQuery
    {
        private string _connectionString = string.Empty;
        public ReceiverQuery(string constr) => _connectionString = !string.IsNullOrWhiteSpace(constr) ? constr : throw new ArgumentException(nameof(constr));

        public async Task<IEnumerable<ReceiverViewModel>> findAll()
        {
            IEnumerable<ReceiverViewModel> result;
            using (var cn = new MySqlConnection(_connectionString))
            {
                await cn.OpenAsync();
                result = (await cn.QueryAsync<ReceiverMapper>("receiver__find_all", commandType: CommandType.StoredProcedure)).Adapt<IEnumerable<ReceiverViewModel>>();
            }
            return result;
        }

        public async Task<ReceiverViewModel> findById(int receiverId)
        {
            ReceiverViewModel result;
            using (var cn = new MySqlConnection(_connectionString))
            {
                await cn.OpenAsync();
                var parameters = new DynamicParameters();
                parameters.Add("@p_receiver_id", receiverId);
                result = (await cn.QueryFirstOrDefaultAsync<ReceiverMapper>("receiver__find_by_id", parameters, commandType: CommandType.StoredProcedure)).Adapt<ReceiverViewModel>();
            }
            return result;
        }
    }
}
