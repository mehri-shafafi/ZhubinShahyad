using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace News.Application.Articles.Commands.Update
{
    public class ChangeNewsArticleStatusCommand:IRequest<bool>
    {
        public int Id { get; set; }
        public bool IsActive { get; set; }
    }
}
