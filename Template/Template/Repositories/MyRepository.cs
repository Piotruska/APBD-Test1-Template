using System.Data.Common;
using Microsoft.Data.SqlClient;

namespace Template.Repositories;

public class MyRepository : ImyRepository
{
    private readonly IConfiguration _configuration;

    public MyRepository(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public async Task<object> GetAsync()
    {
        SqlConnection sqlConnection = new SqlConnection(_configuration["ConnectionStrings:DefaultConnection"]);
        SqlCommand sqlCommand = new SqlCommand();

        sqlCommand.Connection = sqlConnection;
        sqlCommand.CommandText = $"";
        //sqlCommand.Parameters.AddWithValue("@paremeter", parameterPassed);
        
        await sqlConnection.OpenAsync();

        // sqlCommand.ExecuteScalar(); //To get id 
        // var reader = sqlCommand.ExecuteReader(); // to read a list of objects 
        // var affectedCount = sqlCommand.ExecuteNonQuery(); //when updating / deleting for example

        sqlConnection.Dispose();
        sqlCommand.Dispose();

        return null;
    }

    public async Task<object> SomeProcedure()
    {
        SqlConnection sqlConnection = new SqlConnection(_configuration["ConnectionStrings:DefaultConnection"]);
        SqlCommand sqlCommand = new SqlCommand();
        sqlCommand.Connection = sqlConnection;
        
        await sqlConnection.OpenAsync();

        DbTransaction transaction = await sqlConnection.BeginTransactionAsync();
        sqlCommand.Transaction = (SqlTransaction)transaction;

        try
        {
            sqlCommand.CommandText = $"";
            //sqlCommand.Parameters.AddWithValue("@paremeter", parameterPassed);

            // sqlCommand.ExecuteScalar(); //To get id 
            // var reader = sqlCommand.ExecuteReader(); // to read a list of objects 
            // var affectedCount = sqlCommand.ExecuteNonQuery(); //when updating / deleting for example


            await transaction.CommitAsync();
        }
        catch (SqlException exp)
        {
            await transaction.RollbackAsync();
        }
        catch (Exception e)
        {
            await transaction.RollbackAsync();
        }
        
        sqlConnection.Dispose();
        sqlCommand.Dispose();
        
        return null;
    }
}