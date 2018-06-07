using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Web;


namespace SignalRApp.DataAccessLayer
{
    public class DataAccess
    {
        public DataAccess()
        {
            //Initialize properties
            pTransactionSuccessful = true;
            pErrorMessage = "";

        }
    #region Properties 
    private bool pTransactionSuccessful;
        public bool TransactionSuccessful
        {
            get { return pTransactionSuccessful; }
            set { pTransactionSuccessful = value; }
        }
        private string pErrorMessage;
        public string ErrorMessage
        {
            get { return pErrorMessage; }
        }
        #endregion

        #region GetMethods
        public DataTable ValidateUser(string ConnectionString)
        {
            DataTable dtTblAuthor = new DataTable("dtTblAuthor");

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand();

                command.Connection = connection;

                command.CommandType = CommandType.StoredProcedure;

                command.CommandText = "GetAuthor";

                using (SqlDataAdapter da = new SqlDataAdapter(command))
                {
                    DataSet ds = new DataSet();

                    try
                    {
                        da.Fill(ds);

                        dtTblAuthor = ds.Tables[0];
                    }
                    catch (SqlException ReadError)
                    {

                        DataRow ErrorRow = dtTblAuthor.NewRow();
                        dtTblAuthor.Columns.Add("ErrorMessage");
                        ErrorRow["ErrorMessage"] = ReadError.Message.ToString();
                        dtTblAuthor.Columns.Add("ErrorLineNumber");
                        ErrorRow["ErrorLineNumber"] = ReadError.Message.ToString();
                        dtTblAuthor.Rows.Add(ErrorRow);

                        pTransactionSuccessful = false;
                    }
                }

            }

            return dtTblAuthor;
        }
        #endregion
    }

}