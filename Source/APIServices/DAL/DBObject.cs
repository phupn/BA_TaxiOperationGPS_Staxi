using System;
using System.Configuration; 
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace APIServices.DAL
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

        //hangtm thêm. Hàm này dùng cho kết nối mới
        protected int RunProcedureNew(string storedProcName, IDataParameter[] parameters, int rowsAffected, SqlConnection connect)
        {
            if (connect.State == 0)
            {
                connect.Open();
            }

            SqlCommand command = BuildQueryCommandNew(storedProcName, parameters, connect);

            try
            {
                rowsAffected = command.ExecuteNonQuery();
                connect.Close();
            }
            catch (SqlException ex)
            {
                connect.Close();
            }
            return rowsAffected;
        }

        private SqlCommand BuildQueryCommandNew(string storedProcName, IDataParameter[] parameters, SqlConnection connect)
        {
            SqlCommand command = new SqlCommand(storedProcName, connect);
            command.CommandType = CommandType.StoredProcedure;

            foreach (SqlParameter parameter in parameters)
            {
                command.Parameters.Add(parameter);
            }
            return command;
        }
        
        #endregion Methods

        ~DBObject()
        {
            myConnection.Dispose(); 
        }

    }
}