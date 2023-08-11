using System;
using System.Data;
using walkerscott_domain.Interfaces.UnitOfWork;

namespace walkerscott_application.UnitOfWork
{
	public class UnitOfWork:IUnitOfWork
	{
		private readonly IDbTransaction _dbTransaction;

		public UnitOfWork(IDbTransaction dbTransaction)
		{
			_dbTransaction = dbTransaction;
		}

		public void Commit()
		{
			_dbTransaction.Commit();
		}

        public void Rollback()
        {
			_dbTransaction.Rollback();
        }
    }
}

