﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Interfaces;
using Interfaces.Models;
using Interfaces.Models.Notice;

namespace SendingNotice
{
    public class SendingNotice:ISendingNotice
    {
        public bool Send(Notice notice, AUser user)
        {
            var random=new Random();

            var sleep = random.Next(1000, 3000);
            Thread.Sleep(sleep);


            var exeption = random.Next(0, 10);
            if(exeption==5)throw new Exception("Удаленный сервис не смог отправить уведомление");

            return true;
        }
    }
}
