﻿using WebAPI.DesignPatterns.FactoryMethod.Passo_2;

namespace WebAPI.DesignPatterns.FactoryMethod.Passo_1;

// Abstract Creator
public abstract class DbFactory
{
    // Factory Method
    public abstract DbConnector CreateConnector(string connectionString);

    public static DbFactory Database(DataBase dataBase)
    {
        if (dataBase == DataBase.SqlServer)
            return new SqlFactory();
        if (dataBase == DataBase.Oracle)
            return new OracleFactory();

        throw new ApplicationException("Banco de dados não reconhecido.");
    }
}