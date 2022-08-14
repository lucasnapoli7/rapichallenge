using System;
using System.Data.Entity;

namespace RapiChallenge.DataAccess
{
    public abstract class RepoBase : IDisposable
    {
        public abstract DbContext CurrentContext();

        public virtual void Dispose()
        {

        }
    }
}