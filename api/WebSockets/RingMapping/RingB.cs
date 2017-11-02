﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MuaythaiSportManagementSystemApi.Data;

namespace MuaythaiSportManagementSystemApi.WebSockets.RingMapping
{
    public class RingB:FightHandler
    {
        public RingB(ApplicationDbContext context, WebSocketConnectionManager connectionManager) : base(context, connectionManager)
        {
            Ring = "B";
        }
    }
}
