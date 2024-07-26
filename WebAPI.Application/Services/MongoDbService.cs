using Microsoft.EntityFrameworkCore.Metadata.Internal;
using MongoDB.Driver;
using WebAPI.Application.Generic;
using WebAPI.Application.InterfacesService;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace WebAPI.Application.Services;

public sealed class MongoDbService<TEntity> : GenericService, IMongoDbService<TEntity> where TEntity : class
{
    private EnvironmentVariables _environmentVariables { get; }

    public MongoDbService(EnvironmentVariables environmentVariables, INotificationMessageService notificationMessageService) : base(notificationMessageService)
    {
        _environmentVariables = environmentVariables;
    }

    private IMongoCollection<TEntity> CreateMongoDbConnection()
    {
        var client = new MongoClient(_environmentVariables.ConnectionStringSettings.DefaultConnectionToMongoDb);
        var database = client.GetDatabase("testdb");
        var collection = database.GetCollection<TEntity>(nameof(TEntity));
        return collection;
    }

    private FilterDefinition<TEntity> GenericFilter(string propertyName, object value)
    {
        var parameter = Expression.Parameter(typeof(TEntity), "p");
        var property = Expression.Property(parameter, propertyName);
        var constant = Expression.Constant(value);
        var equality = Expression.Equal(property, constant);
        var lambda = Expression.Lambda<Func<TEntity, bool>>(equality, parameter);
        var filter = Builders<TEntity>.Filter.Where(lambda);
        return filter;
    }

    private UpdateDefinition<TEntity> GenericUpdateFilter(string propertyName, object value)
    {
        var parameter = Expression.Parameter(typeof(TEntity), "p");
        var property = Expression.Property(parameter, propertyName);
        var constant = Expression.Constant(value);
        var equality = Expression.Equal(property, constant);
        var lambda = Expression.Lambda<Func<TEntity, bool>>(equality, parameter);
        var filter = Builders<TEntity>.Update.Set(propertyName, value);
        return filter;
    }

    public async Task CreateItem(TEntity entity)
    {
        IMongoCollection<TEntity> mongoCollection = CreateMongoDbConnection();
        await mongoCollection.InsertOneAsync(entity);
    }

    public async Task UpdateItem(string propertyNameToFind, object valueToFind, string propertyNameToChange, object valueToChange)
    {
        IMongoCollection<TEntity> mongoCollection = CreateMongoDbConnection();
        var filter = GenericFilter(propertyNameToFind, valueToFind);
        var existRecord = await mongoCollection.Find(filter).AnyAsync();
        if(existRecord)
        {
            var update = GenericUpdateFilter(propertyNameToChange, valueToChange);
            await mongoCollection.UpdateOneAsync(filter, update);
        }
    }

    public async Task<bool> ResearchItem(string propertyNameToFind, object valueToFind)
    {
        IMongoCollection<TEntity> mongoCollection = CreateMongoDbConnection();
        var filter = GenericFilter(propertyNameToFind, valueToFind);
        var existRecord = await mongoCollection.Find(filter).AnyAsync();
        return existRecord;
    }

    public async Task DeleteItem(string propertyNameToFind, object valueToFind)
    {
        IMongoCollection<TEntity> mongoCollection = CreateMongoDbConnection();
        var filter = GenericFilter(propertyNameToFind, valueToFind);
        var existRecord = await mongoCollection.Find(filter).AnyAsync();
        if (existRecord)
        {
            await mongoCollection.DeleteOneAsync(filter);
        }
    }

    public void Dispose()
    {
        GC.SuppressFinalize(this);
    }
}


