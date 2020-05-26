using System;
using System.Collections.Generic;
using System.Text;
using LiteDB;

namespace TravellerUtils.Libraries.Common.Database
{
    public abstract class AbstractDao<T> where T: IDatabaseObject
    {
        private ILiteDatabase _db;
        private ILiteCollection<T> _collection;

        protected AbstractDao(ILiteDatabase db, string collectionName)
        {
            _db = db;

            CollectionName = collectionName;
            _collection = _db.GetCollection<T>(collectionName);
        }

        public string CollectionName { get; }

        public T Get(Guid id)
        {
            return _collection.FindById(id);
        }

        public void Save(T item)
        {
            var exists = _collection.Exists(i => i.Id == item.Id);

            if (exists)
            {
                _collection.Update(item);
            }
            else
            {
                _collection.Insert(item);
            }
        }
    }
}
