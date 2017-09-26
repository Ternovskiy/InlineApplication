using System.Collections.Generic;
using System.Threading.Tasks;

namespace Interfaces.Models.Notice
{
    public interface IRepositoryNotice
    {
        /// <summary>
        /// Вернет все уведомления
        /// </summary>
        /// <returns></returns>
        IEnumerable<Notice> GetNotices();
        /// <summary>
        /// изменит, сохранит уведомление
        /// </summary>
        /// <param name="notice"></param>
        /// <returns></returns>
        bool Save(Notice notice);

        /// <summary>
        /// вернет уведомление по ид, ид=-1 объект по умолчению 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Notice GetNotice(int id=-1);

        /// <summary>
        /// изменит состояние уведомления на удален
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool RemoveNotice(int id);
        

        /// <summary>
        /// вернет список подписок и дату последней рассылки
        /// </summary>
        /// <returns></returns>
        IEnumerable<NoticeSendView> GetNoticeSendView();


        /// <summary>
        /// запустит асинхронною рассылку уведомелений
        /// </summary>
        /// <param name="noticeId"></param>
        /// <returns></returns>
        Task SendMessage(int noticeId);
    }
}