using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace TaxiOperation
{
    public class DBObject : Base 
    {
        protected SqlConnection myConnection;
        private string myConnectionString =string.Empty ;
        protected int rowsAffected;
        protected DataSet objDataSet;
        #region Constructor

        public DBObject()
        {
            myConnectionString = System.Configuration.ConfigurationManager.AppSettings["ConnectionString"];
            myConnection = new SqlConnection(myConnectionString);
        }
        public DBObject(string StringConnection)
        {
            myConnectionString = StringConnection;
            myConnection = new SqlConnection(myConnectionString);
        }

        #endregion Constructor

        #region Properties
        protected  string ConnectionString
        {
            get { return myConnectionString; }
        }
        protected   SqlConnection ConnectionDB
        {
            get { return myConnection; }
        }
        #endregion Properties

        #region Methods
        protected int RunSQL(string strSQL)
        {             
            SqlCommand myCommand;
            try
            {
                objDataSet = new DataSet();
                if ((myConnection.State == 0) || (myConnection == null))
                {
                    myConnection.Open();
                }
                myCommand = new SqlCommand(strSQL, myConnection);
                myCommand.CommandType = CommandType.Text;
                myCommand.ExecuteNonQuery();
                myConnection.Close();
                return 0;
            }
            catch (SqlException ex)
            {
                myConnection.Close();                
                return ex.ErrorCode;
            }
            finally
            {                
                myCommand = null;
                myConnection.Close();             
                objDataSet.Dispose();
                objDataSet = null;
            }
        }

        protected int RunSQL_ReturnRowsAffected(string strSQL)
        {
            SqlCommand myCommand;
            try
            {
                int rowAffected = 0;
                objDataSet = new DataSet();
                if ((myConnection.State == 0) || (myConnection == null))
                {
                    myConnection.Open();
                }
                myCommand = new SqlCommand(strSQL, myConnection);
                myCommand.CommandType = CommandType.Text;
                rowAffected = myCommand.ExecuteNonQuery();
                myConnection.Close();
                return rowAffected;
            }
            catch (SqlException ex)
            {
                myConnection.Close();
                return ex.ErrorCode;
            }
            finally
            {
                myCommand = null;
                myConnection.Close();
                objDataSet.Dispose();
                objDataSet = null;
            }
        }

        protected DataTable RunSQL(string strSQL, string strTableName)
        {
            SqlCommand myCommand;
            try
            {
                objDataSet = new DataSet();
                if ((myConnection.State == 0) || (myConnection == null))
                {
                    myConnection.Open();
                }
                myCommand = new SqlCommand(strSQL, myConnection);
                myCommand.CommandType = CommandType.Text;
                myCommand.ExecuteNonQuery();
                SqlDataAdapter sqlDA = new SqlDataAdapter(myCommand);
                sqlDA.Fill(objDataSet, strTableName);
                myConnection.Close();
                return objDataSet.Tables[0];
            }
            catch (SqlException ex)
            {
                myConnection.Close();                
                return new DataTable();
            }
            finally
            {                
                myCommand = null;
                myConnection.Close();             
                objDataSet.Dispose();
                objDataSet = null;
            }
        }

        protected int RunProcedure(string storedProcName, IDataParameter[] parameters,   int rowsAffected)
        {
            if (myConnection.State == 0)
            {
                myConnection.Open();
            }

            SqlCommand command = BuildQueryCommand(storedProcName, parameters);

            try
            {
                rowsAffected = command.ExecuteNonQuery();
                myConnection.Close();
            }
            catch (SqlException ex)
            {
                myConnection.Close();                                
            }
            return rowsAffected;
        }

        protected SqlDataReader RunProcedure(string storedProcName, IDataParameter[] parameters)
        {
            SqlDataReader returnReader;
            if (myConnection.State == 0)
            {
                myConnection.Open();
            }
            SqlCommand command = BuildQueryCommand(storedProcName, parameters);
            command.CommandType = CommandType.StoredProcedure;
            returnReader = command.ExecuteReader();
            myConnection.Close();
            return returnReader;
        }
        protected SqlDataReader RunProcedure(string storedProcName, IDataParameter[] parameters,CommandBehavior commandBehavior)
        {
            SqlDataReader returnReader;
            if (myConnection.State == 0)
            {
                myConnection.Open();
            }
            SqlCommand command = BuildQueryCommand(storedProcName, parameters);
            command.CommandType = CommandType.StoredProcedure;
            returnReader = command.ExecuteReader(CommandBehavior.SingleRow );
            myConnection.Close();
            return returnReader;
        }  
        protected DataSet RunProcedure(string storedProcName, IDataParameter[] parameters, string tableName)
        {
            DataSet dataSet = new DataSet();
            if (myConnection.State == 0)
            {
                myConnection.Open();
            }
            SqlDataAdapter sqlDA = new SqlDataAdapter();
            sqlDA.SelectCommand = BuildQueryCommand(storedProcName, parameters);
            sqlDA.Fill(dataSet, tableName);
            sqlDA.Dispose();
            myConnection.Close();
            return dataSet;
        }

        protected void RunProcedure(string storedProcName, IDataParameter[] parameters, DataSet dataSet, string tableName)
        {
            myConnection.Open();
            SqlDataAdapter sqlDA = new SqlDataAdapter();
            sqlDA.SelectCommand = BuildQueryCommand(storedProcName, parameters);
            sqlDA.Fill(dataSet, tableName);
            myConnection.Close();
        } 
        private SqlCommand BuildQueryCommand(string storedProcName, IDataParameter[] parameters)
        {
            SqlCommand command = new SqlCommand(storedProcName, myConnection);
            command.CommandType = CommandType.StoredProcedure;

            foreach (SqlParameter parameter in parameters)
            {
                command.Parameters.Add(parameter);
            }
            return command;
        }

        //=====================Phupn=========================
        //Run a List Stored Procedure 
        protected DataSet RunListProcedure(string storedProcName,
                                                  System.Collections.ArrayList ListPara,
            //IDataParameter[] parameters,
                                                  string tableName)
        {

            DataSet dataSet = new DataSet();
            //Dim cmd As sqlCommand
            if (myConnection.State == 0)
            {
                try
                {
                    myConnection.Open();
                }
                catch
                {
                    throw new Exception("Không kết nối được cơ sở dữ liệu");
                }
            }
            SqlTransaction transaction = myConnection.BeginTransaction();
            try
            {
                for (int i = 0; i < ListPara.Count; i++)
                {
                    SqlDataAdapter SqlDA = new SqlDataAdapter();
                    IDataParameter[] parameters = (IDataParameter[])ListPara[i];
                    SqlDA.SelectCommand = BuildQueryCommand(storedProcName, parameters);
                    SqlDA.SelectCommand.Transaction = transaction;
                    SqlDA.Fill(dataSet, tableName);
                    SqlDA.Dispose();
                }
                transaction.Commit();
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
                //throw new Exception("Error occur when insert multiple ThietBiThuPhi");
            }
            finally
            {
                myConnection.Close();
            }
            //SqlDataAdapter SqlDA = new SqlDataAdapter();
            //SqlDA.SelectCommand = Bui ldQueryCommand(storedProcName, parameters);
            //SqlDA.Fill(dataSet, tableName);
            //SqlDA.Dispose();
            return dataSet;

        }
        #endregion Methods

        ~DBObject()
        {
            myConnection.Dispose(); 
        }

    }
}