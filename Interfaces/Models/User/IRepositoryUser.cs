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


        /// <summary>
        /// Получить подписки пользователя
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        IEnumerable<Notice.Notice> GetUserNotices(int userId);


        /// <summary>
        /// добавить или удалить подписку пользователю
        /// </summary>
        /// <param name="userId">ид польз</param>
        /// <param name="noticeId">ид уведомления</param>
        /// <param name="signed">тру- добавить подп.польз., фалс-удалить у польз. подп.</param>
        /// <returns></returns>
        bool SaveUserNotices(int userId, int noticeId, bool signed);
    }
}
