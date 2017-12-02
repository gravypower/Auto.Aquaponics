﻿namespace Ponics.Queries
{
    public interface IQueryHandler<in TQuery, out TResult> where TQuery : Query<TResult>
    {
        TResult Handle(TQuery query);
    }
}