using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace News.Domain.News.Interfaces
{
    public interface IActivatable
    {
        bool IsActive { get; set; }
    }
}
