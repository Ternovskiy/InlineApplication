using System.Collections.Generic;

namespace Interfaces.Models.User
{
    public interface IRepositoryUser
    {
        /// <summary>
        /// Для построничного вывода пользователей, состояние каждого "В работе"
        /// </summary>
        /// <param name="name">строка поиска</param>
        /// <param name="pageSize">колич элеметов на странице</param>
        /// <param name="page">номер страницы</param>
        /// <param name="countPage">колличество элементов</param>
        /// <returns></returns>
        IEnumerable<AUser> GetUsers(string name, int pageSize, int page, ref int countPage);

        /// <summary>
        /// получения пользователя по ид, по умолчнию новый объект
        /// </summary>
        /// <param name="idUser"></param>
        /// <returns></returns>
        AUser GerUser(int idUser=-1);

        /// <summary>
        /// сохраняет, создает пользователей
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        bool Save(AUser user);

        /// <summary>
        /// сменит статус польз на "удален" по ид
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        bool Remove(int userId);


        IEnumerable<Notice.Notice> GetUserNotices(int userId);
    }
}
