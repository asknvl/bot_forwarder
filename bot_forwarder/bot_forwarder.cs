using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace bot_forwarder
{
    public class bot_forwarder
    {

        #region const
        long OUT_CHANNEL_ID = -1002085060438;
        #endregion

        #region vars
        string Token;
        ITelegramBotClient bot;
        CancellationToken cancellationToken;
        #endregion

        public bot_forwarder(string token) { 

            bot = new TelegramBotClient(token);

        }


        async Task HandleUpdateAsync(ITelegramBotClient botClient, Telegram.Bot.Types.Update update, CancellationToken cancellationToken) { 
        
            switch (update.Type)
            {

                case UpdateType.ChannelPost:
                    try
                    {
                        var m = update.ChannelPost;
                        if (m != null)
                        {

                            await bot.ForwardMessageAsync(OUT_CHANNEL_ID, m.Chat.Id, m.MessageId);
                            
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    break;

                case UpdateType.Message:

                    

                    break;
            }
        
        }

        public Task HandleErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken) { 
            return Task.CompletedTask;
        }

        public void start() {

            cancellationToken = new CancellationToken();

            var receiverOptions = new ReceiverOptions
            {
                AllowedUpdates = new UpdateType[] { UpdateType.Message, UpdateType.ChannelPost }
            };
            bot.StartReceiving(HandleUpdateAsync, HandleErrorAsync, receiverOptions, new CancellationToken());
        }

    }    
}
