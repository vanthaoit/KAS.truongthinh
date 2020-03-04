using System;
using System.Collections.Generic;
using System.Text;

namespace KAS.TruongThinh.Models.Abstract
{
    public interface IAuditable
    {
        DateTime? CreatedDate { set; get; }
        string CreatedBy { set; get; }
        DateTime? UpdatedDate { set; get; }
        string UpdatedBy { set; get; }

    }
}
