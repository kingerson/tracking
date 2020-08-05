using Trackings.Domain.Aggregates;
using Trackings.Domain.Exceptions;
using Dapper;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Trackings.Repository
{
    public class ItemComponentRepository : IItemComponentRepository
    {
        readonly string _connectionString = string.Empty;

        public ItemComponentRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<int> Register(ItemComponent itemComponent)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                try
                {
                    var parameters = new DynamicParameters();

                    parameters.Add("@pot_rubro_c_yid", itemComponent.itemComponentId, DbType.Int32, ParameterDirection.InputOutput);
                    parameters.Add("@piv_rubro_c_vnomb", itemComponent.name, DbType.String, ParameterDirection.Input);
                    parameters.Add("@pit_loc_tipo_c_yid", itemComponent.typeLocalId, DbType.Int32, ParameterDirection.Input);
                    parameters.Add("@pid_wattsXm2", itemComponent.wattsXm2, DbType.Decimal, ParameterDirection.Input);
                    parameters.Add("@pid_kilowats", itemComponent.kiloWatts, DbType.Decimal, ParameterDirection.Input);
                    parameters.Add("@pii_predecesor", itemComponent.predecessor, DbType.Int32, ParameterDirection.Input);
                    parameters.Add("@pib_reporta_venta", itemComponent.saleReport, DbType.Boolean, ParameterDirection.Input);

                    var result = await connection.ExecuteAsync(@"dbo.ADV_T_RUBRO_insert_update", parameters, commandType: CommandType.StoredProcedure);

                    itemComponent.itemComponentId = parameters.Get<int>("@pot_rubro_c_yid");

                    return itemComponent.itemComponentId;
                }
                catch (Exception ex)
                {
                    throw new TrackingsBaseException(ex.Message);
                }
            }
        }

        public async Task<bool> ValidateItemComponentName(int itemComponent_id, string name)
        {
            bool result = false;
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    await connection.OpenAsync();

                    var parameters = new DynamicParameters();
                    parameters.Add("@p_itemComponent_id", itemComponent_id, DbType.Int64);
                    parameters.Add("@p_name", name, DbType.String);
                    result = await connection.ExecuteScalarAsync<bool>(@"[dbo].[itemComponent_validate_samename]", parameters, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {
                throw new TrackingsBaseException(ex.Message);
            }
            return result;
        }
    }
}
