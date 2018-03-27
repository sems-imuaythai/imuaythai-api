﻿using System.Threading.Tasks;
using IMuaythai.DataAccess.Contexts;

namespace IMuaythai.JudgingServer.Handlers
{
    class EndRoundHandler : BaseRequestHandler, IMessageHandler
    {
        public EndRoundHandler(IMessageHandler handler, IFightContext fightContext, ApplicationDbContext context) :
            base(
                handler, fightContext, context)
        {
            
        }

        public async Task<HandlerResponse> Handle(Message message)
        {
            if (message.RequestType != MessageType.EndRound)
            {
                return NextHandler?.Handle(message).Result;
            }
            FightContext.EndRound();
            return new HandlerResponse
            {
                ResponseType = ResponseType.ToAll,
                Message = new Message
                {
                    RequestType = message.RequestType,
                    Data = null
                }
            };
        }
    }
}