using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Data.Entity.Migrations.Model;
using Microsoft.Data.Sqlite;

namespace WMS_app.Repositories
{
    public abstract class RepositoryBase
    {
        public RepositoryBase()
        {
            SQLiteConnection sQLiteConnection;
            sQLiteConnection = CreateConnection();
            CreateTable(sQLiteConnection);
            CreateGoodsTable(sQLiteConnection);
            InsertData(sQLiteConnection);
        }

        protected SQLiteConnection CreateConnection()
        {
            SQLiteConnection sQLiteConnection;
            sQLiteConnection = new SQLiteConnection("Data Source=WMS_DB.db;Version=3;New=True;Compress=True;");
            try
            {
                sQLiteConnection.Open();
            }
            catch (Exception)
            {

                throw;
            }
            return sQLiteConnection;
        }

        public void CreateTable(SQLiteConnection sQLiteConnection)
        {

            SQLiteCommand sqLiteCommand;
            
            string CreateName = "CREATE TABLE Employees(ID INT,Name VARCHAR(30),Surname VARCHAR(30), Password VARCHAR(30))";

            sqLiteCommand = sQLiteConnection.CreateCommand();
            sqLiteCommand.CommandText = CreateName;
            //sqLiteCommand.ExecuteNonQuery();
        }

        public void CreateGoodsTable(SQLiteConnection sQLiteConnection)
        {
            SQLiteCommand sqLiteCommand;

            string CreateTable = "CREATE TABLE StoredGoods(ID INT, ItemName VARCHAR(50), ItemQuantity INT)";

            sqLiteCommand = sQLiteConnection.CreateCommand();
            sqLiteCommand.CommandText = CreateTable;
            //sqLiteCommand.ExecuteNonQuery();
        }

        public void InsertData(SQLiteConnection sQLiteConnection)
        {
            SQLiteCommand sQLiteCommand;
            sQLiteCommand = sQLiteConnection.CreateCommand();
            sQLiteCommand.CommandText = "INSERT INTO Employees (ID,Name,Surname,Password) VALUES(1,'Johny','Johnson','12345')";
            sQLiteCommand.ExecuteNonQuery();
        }
    }
}
