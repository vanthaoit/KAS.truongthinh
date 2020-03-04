using System;
using System.Collections.Generic;
using System.Text;

namespace KAS.TruongThinh.BusinessFunctions.IServices
{
    public interface ITruongThinhDataService<TEntity> : IDataAccessService<TEntity> where TEntity : class
    {
    }
}
