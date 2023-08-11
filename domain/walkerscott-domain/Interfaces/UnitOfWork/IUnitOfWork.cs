using System;
namespace walkerscott_domain.Interfaces.UnitOfWork
{
	public interface IUnitOfWork
	{
		public void Commit();
		public void Rollback();
	}
}

