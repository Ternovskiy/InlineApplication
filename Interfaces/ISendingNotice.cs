using Interfaces.Models;
using Interfaces.Models.Notice;

namespace Interfaces
{
    public interface ISendingNotice
    {
        bool Send(Notice notice, AUser user);
    }
}