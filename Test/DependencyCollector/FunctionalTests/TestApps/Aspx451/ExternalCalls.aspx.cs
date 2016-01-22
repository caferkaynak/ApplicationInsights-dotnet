﻿namespace Aspx451
{
    using System;
    using System.Data;
    using System.Data.SqlClient;
    using System.Net;
    using System.Runtime.InteropServices;
    using FW40Shared;
    using FW45Shared;

    /// <summary>
    /// ExternalCalls page to make remote dependency calls.
    /// </summary>
    [ComVisible(false)]
    public partial class ExternalCalls : System.Web.UI.Page
    {
        /// <summary>
        /// Connection string to APM Development database.
        /// </summary> 
        private const string ConnectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=RDDTestDatabase;Integrated Security=True";

        /// <summary>
        /// Valid SQL Query.
        /// </summary> 
        private const string ValidSqlQueryToApmDatabase = "select top 2 * from dbo.Messages";

        /// <summary>
        /// Valid SQL Query to get count.
        /// </summary> 
        private const string ValidSqlQueryCountToApmDatabase = "SELECT count(*) FROM dbo.Messages";

        /// <summary>
        /// Invalid SQL Query.
        /// </summary> 
        private const string InvalidSqlQueryToApmDatabase = "SELECT TOP 2 * FROM apm.[Database1212121]";

        /// <summary>
        /// Label used to identify the query being executed.
        /// </summary> 
        private const string QueryToExecuteLabel = "Query Executed:";

        /// <summary>
        /// ExternalCalls page to make remote dependency calls.
        /// </summary>        
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Argument object.</param>        
        protected void Page_Load(object sender, EventArgs e)
        {
            var type = Request.QueryString["type"];
            var countStr = Request.QueryString["count"];
            var success = true;
            bool.TryParse(Request.QueryString["success"], out success);
            string sqlQueryTouse = (success == true) ? ValidSqlQueryToApmDatabase : InvalidSqlQueryToApmDatabase;
            var count = 1;
            try
            {
                count = int.Parse(countStr);
            }
            catch (Exception)
            {
                // Dont care about this           
            }

            this.lblRequestedAction.Text = "Requested Action:" + type;

            try
            {
                switch (type)
                {
                    case "http":
                        HttpHelper40.MakeHttpCallSync(count, "bing");
                        break;
                    case "httppost":
                        HttpHelper40.MakeHttpPostCallSync(count, "bing");
                        break;
                    case "failedhttp":
                        HttpHelper40.MakeHttpCallSyncFailed(count);
                        break;
                    case "httpasync1":
                        HttpHelper40.MakeHttpCallAsync1(count, "bing");
                        break;
                    case "failedhttpasync1":
                        HttpHelper40.MakeHttpCallAsync1Failed(count);
                        break;
                    case "httpasync2":
                        HttpHelper40.MakeHttpCallAsync2(count, "bing");
                        break;
                    case "failedhttpasync2":
                        HttpHelper40.MakeHttpCallAsync2Failed(count);
                        break;
                    case "httpasync3":
                        HttpHelper40.MakeHttpCallAsync3(count, "bing");
                        break;
                    case "failedhttpasync3":
                        HttpHelper40.MakeHttpCallAsync3Failed(count);
                        break;
                    case "httpasync4":
                        HttpHelper40.MakeHttpCallAsync4(count, "bing");
                        break;
                    case "failedhttpasync4":
                        HttpHelper40.MakeHttpCallAsync4Failed(count);
                        break;
                    case "httpasyncawait1":
                        HttpHelper45.MakeHttpCallAsyncAwait1(count, "bing");
                        break;
                    case "failedhttpasyncawait1":
                        HttpHelper45.MakeHttpCallAsyncAwait1Failed(count);
                        break;
                    case "sql":
                        this.MakeSQLCallSync(count);
                        break;
                    case "azuresdkblob":
                        HttpHelper40.MakeAzureCallToReadBlobWithSdk(count);
                        break;
                    case "azuresdkqueue":
                        HttpHelper40.MakeAzureCallToWriteQueueWithSdk(count);
                        break;
                    case "azuresdktable":
                        HttpHelper40.MakeAzureCallToWriteTableWithSdk(count);
                        HttpHelper40.MakeAzureCallToReadTableWithSdk(count);
                        break;
                    case "ExecuteReaderAsync":
                        SqlCommandHelper.ExecuteReaderAsync(ConnectionString, sqlQueryTouse);
                        break;
                    case "ExecuteScalarAsync":
                        SqlCommandHelper.ExecuteScalarAsync(ConnectionString, sqlQueryTouse);
                        break;
                    case "ExecuteReaderStoredProcedureAsync":
                        this.ExecuteReaderStoredProcedureAsync();
                        break;
                    case "TestExecuteReaderTwice":
                        SqlCommandHelper.TestExecuteReaderTwice(ConnectionString, sqlQueryTouse);
                        break;
                    case "BeginExecuteReader":
                        SqlCommandHelper.BeginExecuteReader(ConnectionString, sqlQueryTouse);
                        break;
                    case "TestExecuteReaderTwiceInSequence":
                        SqlCommandHelper.TestExecuteReaderTwiceInSequence(ConnectionString, sqlQueryTouse);
                        break;
                    case "TestExecuteReaderTwiceWithTasks":
                        SqlCommandHelper.AsyncExecuteReaderInTasks(ConnectionString, sqlQueryTouse);
                        break;
                    case "ExecuteNonQueryAsync":
                        SqlCommandHelper.ExecuteNonQueryAsync(ConnectionString, sqlQueryTouse);
                        break;
                    case "BeginExecuteNonQuery":
                        SqlCommandHelper.BeginExecuteNonQuery(ConnectionString, sqlQueryTouse);
                        break;
                    case "ExecuteXmlReaderAsync":
                        sqlQueryTouse += " FOR XML AUTO";
                        SqlCommandHelper.ExecuteXmlReaderAsync(ConnectionString, sqlQueryTouse);
                        break;
                    case "BeginExecuteXmlReader":
                        SqlCommandHelper.BeginExecuteXmlReader(ConnectionString, sqlQueryTouse);
                        break;
                    case "SqlCommandExecuteScalar":
                        sqlQueryTouse = (success == true)
                                        ? ValidSqlQueryCountToApmDatabase
                                        : InvalidSqlQueryToApmDatabase;
                        SqlCommandHelper.ExecuteScalar(ConnectionString, sqlQueryTouse);
                        break;
                    case "SqlCommandExecuteNonQuery":
                        sqlQueryTouse = (success == true)
                               ? ValidSqlQueryCountToApmDatabase
                               : InvalidSqlQueryToApmDatabase;
                        SqlCommandHelper.ExecuteNonQuery(ConnectionString, sqlQueryTouse);
                        break;
                    case "SqlCommandExecuteReader":
                        SqlCommandHelper.ExecuteReader(ConnectionString, sqlQueryTouse);
                        break;
                    case "SqlCommandExecuteXmlReader":
                        sqlQueryTouse += " FOR XML AUTO";
                        SqlCommandHelper.ExecuteXmlReader(ConnectionString, sqlQueryTouse);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException("Request Parameter type is not mapped to an action: " + type);
                }

                this.lblResult.Text = "Requested action completed successfully.";
                Response.Write(QueryToExecuteLabel + sqlQueryTouse);
            }
            catch (Exception ex)
            {
                Response.Write(QueryToExecuteLabel + sqlQueryTouse);
                this.lblResult.Text = "The following error occured while attempting to perform requested action" + ex;
            }
        }

        /// <summary>
        /// Make sync SQL calls.
        /// </summary>        
        /// <param name="count">No of calls to be made.</param>        
        private void MakeSQLCallSync(int count)
        {
            SqlConnection conn = null;
            SqlCommand cmd = null;
            SqlDataReader rdr = null;
            for (int i = 0; i < count; i++)
            {
                conn = new SqlConnection(ConnectionString);
                conn.Open();
                cmd = new SqlCommand("GetTopTenMessages", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                rdr = cmd.ExecuteReader();
                rdr.Close();
            }
        }

        private void ExecuteReaderStoredProcedureAsync()
        {
            var storedProcedureName = this.Request.QueryString["storedProcedureName"];
            if (string.IsNullOrEmpty(storedProcedureName))
            {
                throw new ArgumentException("storedProcedureName query string parameter is not defined.");
            }

            SqlCommandHelper.ExecuteReaderAsync(ConnectionString, storedProcedureName, CommandType.StoredProcedure);
        }
    }
}