using Dapper;
using Mapster;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Trackings.Application.Queries.Mappers;

namespace Trackings.Application.Queries.Implementations
{
    public class BrandQuery : IBrandQuery
    {
        private string _connectionString = string.Empty;
        public BrandQuery(string constr) => _connectionString = !string.IsNullOrWhiteSpace(constr) ? constr : throw new ArgumentException(nameof(constr));

        public async Task<IEnumerable<BrandViewModel>> findAll()
        {
            IEnumerable<BrandViewModel> result;
            using (var cn = new MySqlConnection(_connectionString))
            {
                await cn.OpenAsync();
                result = await cn.QueryAsync<BrandViewModel>("brand__find_all", commandType: CommandType.StoredProcedure);
            }
            return result;
        }

        public async Task<BrandViewModel> findById(int brandId)
        {
            BrandViewModel result;
            using (var cn = new MySqlConnection(_connectionString))
            {
                await cn.OpenAsync();
                var parameters = new DynamicParameters();
                parameters.Add("@p_brand_id", brandId);
                result = (await cn.QueryFirstOrDefaultAsync<BrandMapper>("brand__find_by_id", parameters, commandType: CommandType.StoredProcedure)).Adapt<BrandViewModel>();
            }
            return result;
        }

        public async Task<IEnumerable<BrandViewModel>> findByMall(int malId)
        {
            IEnumerable<BrandViewModel> result;
            using (var cn = new MySqlConnection(_connectionString))
            {
                await cn.OpenAsync();
                var parameters = new DynamicParameters();
                parameters.Add("@p_mall_id", malId);
                result = (await cn.QueryAsync<BrandMapper>("brand__find_by_mall", parameters, commandType: CommandType.StoredProcedure)).Adapt<IEnumerable<BrandViewModel>>();
            }
            return result;
        }
    }
}
