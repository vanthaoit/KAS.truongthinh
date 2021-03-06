﻿using KAS.TruongThinh.BusinessFunctions.IServices;
using KAS.TruongThinh.Models.Constants;
using KAS.TruongThinh.Models.Structs;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace KAS.TruongThinh.BusinessFunctions.Services
{
    public class TruongThinhDataService<TEntity>: ITruongThinhDataService<TEntity> where TEntity : class
    {
        private readonly DataAccessService<TEntity> _repository;
        public TruongThinhDataService(IConfiguration config)
        {
            var conn = config[ConnectStringConstants.TRUONG_THINH_DATABASE];
            _repository = new DataAccessService<TEntity>(conn);
        }

        public Task<bool> Delete(TEntity entity) => _repository.Delete(entity);

        public Task<bool> Delete(IEnumerable<TEntity> entities) => _repository.Delete(entities);

        public Task ExecuteProc(string proc, object parameters) => _repository.ExecuteProc(proc, parameters);

        public Task ExecuteStatement(string statement, object parameters) => _repository.ExecuteStatement(statement, parameters);

        public Task<TEntity> Get(long key) => _repository.Get(key);

        public Task<TEntity> Get(int key) => _repository.Get(key);

        public Task<IEnumerable<TEntity>> GetAll() => _repository.GetAll();

        public Task<IEnumerable<TEntity>> GetDataByFilter(string table = "", params KeyValuePair<string, string>[] filter) => _repository.GetDataByFilter(table, filter);

        public Task<IEnumerable<TEntity>> GetDataByFilter(params KeyValuePair<string, string>[] filter) => _repository.GetDataByFilter(filter);

        public Task<IEnumerable<TEntity>> GetDataByFilter(object filter, string table = "") => _repository.GetDataByFilter(filter, table);

        public Task<IEnumerable<TEntity>> GetDataByFilter(params ParameterDefinition[] parameters) => _repository.GetDataByFilter(parameters);

        public Task<IEnumerable<TEntity>> GetDataWithProc(string proc, object parameters) => _repository.GetDataWithProc(proc, parameters);

        public Task<IEnumerable<TEntity>> GetDataWithQuery(string query, object parameters) => _repository.GetDataWithQuery(query, parameters);

        public Task<long> Insert(TEntity entity) => _repository.Insert(entity);

        public Task<long> Insert(IEnumerable<TEntity> entities) => _repository.Insert(entities);

        public Task<bool> Update(TEntity entity) => _repository.Update(entity);

        public Task<bool> Update(IEnumerable<TEntity> entities) => _repository.Update(entities);
    }
}
