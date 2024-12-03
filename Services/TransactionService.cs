using Dapper;
using Microsoft.Data.SqlClient;
using PruebaSP_API.Models;
using System.Data;

namespace PruebaSP_API.Services;

public class TransactionService
{
    private readonly string _connectionString;

    public TransactionService(string connectionString)
    {
        _connectionString = connectionString;
    }

    public async Task<IEnumerable<TransactionPayPad>> GetTransactionsAsync(int payPadId, DateTime startDate, DateTime endDate)
    {
        using var connection = new SqlConnection(_connectionString);
        var parameters = new DynamicParameters();
        parameters.Add("@ID_PayPad", payPadId, DbType.Int32);
        parameters.Add("@Date_Start_Query", startDate, DbType.DateTime);
        parameters.Add("@Date_End_Query", endDate, DbType.DateTime);

        string spName = "business.SP_GetTransactionPayPad";

        var result = await connection.QueryAsync<TransactionPayPad>(
            spName,
            parameters,
            commandType: CommandType.StoredProcedure
        );

        return result;
    }

}
