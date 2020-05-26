using System;
using LiteDB;

namespace TravellerUtils.Libraries.Common.Database
{
    public interface IDatabaseObject
    {
        [BsonId]
        Guid Id { get; set; }
    }
}