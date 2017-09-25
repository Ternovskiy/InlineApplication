using System.Collections.Generic;
using Interfaces.Models;
using Interfaces.Models.Notice;
using Interfaces.Models.User;

namespace Interfaces
{
    public partial interface IRepository: IRepositoryUser, IRepositoryNotice
    {

    }
}