using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using System.Data.SqlClient;
using TestWebApiModel;
using TestWebApiRepositoryCommon;
using TestWebApiCommon;

namespace TestWebApiRepository
{
    public class BuyerRepository : IBuyerRepository
    {
        static string connectionString = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=WebApplication_DataBase;Integrated Security=True";

        public async Task <List<BuyerModel>> GetBuyerAsync(Page page, Sort sort, Filter filter)
        {
            StringBuilder sql = new StringBuilder();

            sql.Append($"SELECT * FROM Buyer");
            if (page == null && sort == null && filter == null)
                sql.Append("");
            else
            {
                if (filter != null)
                    sql.Append($" WHERE 1=1");
                if (filter.FilterId != Guid.Empty)
                    sql.Append($" AND ID = '{filter.FilterId}'");
                if (filter.FilterName != String.Empty)
                    sql.Append($" AND BuyerName = '{filter.FilterName}'");
                if (filter.FilterAdress != String.Empty)
                    sql.Append($" AND BuyerAdress = '{filter.FilterAdress}'");
                if (filter.FilterOib != 0)
                    sql.Append($" AND BuyerOib = '{filter.FilterOib}'");
                sql.Append($" ORDER BY {sort.SortColumn} {sort.SortOrder}");
                sql.Append($" OFFSET {page.PageSize} * ({page.PageNumber}-1) ROWS");
                sql.Append($" FETCH NEXT {page.PageSize} ROWS ONLY");
            }

            string SqlCommand = sql.ToString();
            
            SqlConnection connection = new SqlConnection(connectionString);

            List<BuyerModel> listofbuyers = new List<BuyerModel>();

            using (connection)
            {
                SqlCommand command = new SqlCommand(SqlCommand, connection);
                connection.Open();
                SqlDataReader reader = await command.ExecuteReaderAsync();

                string GetStringNull(int i)
                {
                    if (reader.IsDBNull(i) == false)
                        return reader.GetString(i);
                    else return string.Empty;
                }

                long GetLongNull(int i)
                {
                    if (reader.IsDBNull(i) == false)
                        return reader.GetInt64(i);
                    else return 0;
                }
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        BuyerModel buyerModel = new BuyerModel();
                        buyerModel.Id = reader.GetGuid(0);
                        buyerModel.Name = GetStringNull(1);
                        buyerModel.Adress = GetStringNull(2);
                        buyerModel.Oib = GetLongNull(3);
                        listofbuyers.Add(buyerModel);
                    }
                }
                reader.Close();
                connection.Close();
            }
            return listofbuyers;
        }

        public async Task <List<BuyerModel>> GetBuyerByIdAsync(Guid id)
        {
            string SqlCommand = $"SELECT * FROM Buyer WHERE ID = '{id}'";

            SqlConnection connection = new SqlConnection(connectionString);

            List<BuyerModel> listofbuyers = new List<BuyerModel>();

            using (connection)
            {
                SqlCommand command = new SqlCommand(SqlCommand, connection);
                connection.Open();
                SqlDataReader reader = await command.ExecuteReaderAsync();

                string GetStringNull(int i)
                {
                    if (reader.IsDBNull(i) == false)
                        return reader.GetString(i);
                    else return string.Empty;
                }

                long GetLongNull(int i)
                {
                    if (reader.IsDBNull(i) == false)
                        return reader.GetInt64(i);
                    else return 0;
                }
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        BuyerModel buyerModel = new BuyerModel();
                        buyerModel.Id = reader.GetGuid(0);
                        buyerModel.Name = GetStringNull(1);
                        buyerModel.Adress = GetStringNull(2);
                        buyerModel.Oib = GetLongNull(3);
                        listofbuyers.Add(buyerModel);
                    }
                }
                reader.Close();
                connection.Close();
            }
            return listofbuyers;
        }

        public async Task PostBuyerAsync(BuyerModel buyer)
        {
            SqlConnection connection = new SqlConnection(connectionString);

            using (connection)
            {
                string SqlCommand = $"INSERT INTO Buyer (BuyerName, BuyerAdress, BuyerOIB) VALUES ('{buyer.Name}', '{buyer.Adress}', {buyer.Oib})";
                SqlCommand command = new SqlCommand(SqlCommand, connection);
                SqlDataAdapter adapter = new SqlDataAdapter();
                connection.Open();
                adapter.InsertCommand = command;
                await adapter.InsertCommand.ExecuteNonQueryAsync();
                connection.Close();
            };
        }

        public async Task PostBuyersAsync(List<BuyerModel> buyer)
        {
            SqlConnection connection = new SqlConnection(connectionString);

            using (connection)
            {
                foreach (var item in buyer)
                {
                    string SqlCommand = $"INSERT INTO Buyer (BuyerName, BuyerAdress, BuyerOIB) VALUES ('{item.Name}', '{item.Adress}', {item.Oib});";
                    SqlCommand command = new SqlCommand(SqlCommand, connection);
                    SqlDataAdapter adapter = new SqlDataAdapter();
                    connection.Open();
                    adapter.InsertCommand = command;
                    await adapter.InsertCommand.ExecuteNonQueryAsync();
                    connection.Close();
                }
            };
        }

        public async Task PutBuyerAsync(Guid id, BuyerModel buyer)
        {
            string SqlCommand = $"UPDATE Buyer SET BuyerName = '{buyer.Name}', BuyerAdress = '{buyer.Adress}', BuyerOIB = {buyer.Oib} WHERE ID = '{id}';";

            SqlConnection connection = new SqlConnection(connectionString);

            using (connection)
            {
                SqlCommand command = new SqlCommand(SqlCommand, connection);
                SqlDataAdapter adapter = new SqlDataAdapter();
                connection.Open();
                adapter.InsertCommand = command;
                await adapter.InsertCommand.ExecuteNonQueryAsync();
                connection.Close();
            }
        }

        public async Task DeleteBuyerAsync(Guid id)
        {
            string SqlCommand = $"DELETE FROM Buyer WHERE ID = '{id}';";

            SqlConnection connection = new SqlConnection(connectionString);

            using (connection)
            {
                SqlCommand command = new SqlCommand(SqlCommand, connection);
                SqlDataAdapter adapter = new SqlDataAdapter();
                connection.Open();
                adapter.InsertCommand = command;
                await adapter.InsertCommand.ExecuteNonQueryAsync();
                connection.Close();
            }
        }

        public async Task <bool> BuyerIdCheckAsync(Guid id)
        {
            string SqlCommand = $"SELECT * FROM Buyer WHERE ID = '{id}'";

            SqlConnection connection = new SqlConnection(connectionString);

            BuyerModel buyerModel = new BuyerModel();

            using (connection)
            {
                SqlCommand command = new SqlCommand(SqlCommand, connection);
                connection.Open();
                SqlDataReader reader = await command.ExecuteReaderAsync();

                if (reader.HasRows)
                    while (reader.Read())
                        buyerModel.Id = reader.GetGuid(0);

                reader.Close();
                connection.Close();
            }
            if (id == buyerModel.Id)
                return true;
            else
                return false;
        }
    }
}
