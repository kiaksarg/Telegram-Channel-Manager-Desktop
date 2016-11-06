using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormattedText
{
    public class Chat
    {
        public Telegram.Bot.Types.Enums.ChatType ChatType { get; set; }
        public long ChatId { get; set; }
        public string UserName { get; set; }
        public string ChatName { get; set; }
        public string BotUserName { get; set; }
        public string BotToken { get; set; }
    }
}
