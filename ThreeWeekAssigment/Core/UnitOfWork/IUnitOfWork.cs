﻿namespace Core.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        void Commit();
    }
}