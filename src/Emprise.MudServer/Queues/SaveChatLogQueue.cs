﻿using Emprise.Domain.Core.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace Emprise.MudServer.Queues
{
    public class SaveChatLogQueue : QueueEvent
    {
        public SaveChatLogQueue(int playerId,string content)
        {
            PlayerId = playerId;
            Content = content;
        }


        public int PlayerId { get; set; }
        public string Content { get; set; }

    }
}
