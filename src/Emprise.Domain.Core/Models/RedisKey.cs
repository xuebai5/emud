﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Emprise.Domain.Core.Models
{
    public class RedisKey
    {
        /// <summary>
        /// chatWithNpc_{playerId}_{npcId}
        /// </summary>
        public const string ChatWithNpc = "chatWithNpc_{0}_{1}";

        /// <summary>
        /// ChatWithNpcLike_{playerId}_{npcId}
        /// </summary>
        public const string ChatWithNpcLike = "chatWithNpcLike_{0}_{1}";
        

        /// <summary>
        /// completeQuest_{playerId}_{questId}
        /// </summary>
        public const string CompleteQuest = "completeQuest_{0}_{1}";

        /// <summary>
        /// commandIds_{playerId}_{npcId}_{scriptId}
        /// </summary>
        public const string CommandIds = "commandIds_{0}_{1}_{2}";

        /// <summary>
        /// regemail_{email}
        /// </summary>
        public const string RegEmail = "regEmail_{0}";

        /// <summary>
        /// resetPassword_{userId}
        /// </summary>
        public const string ResetPassword = "resetPassword_{0}";

        /// <summary>
        /// resetPassword_{email}
        /// </summary>
        public const string VerifyEmail = "verifyEmail_{0}";

        /// <summary>
        /// UnreadEmailCount_{playerId}
        /// </summary>
        public const string UnreadEmailCount = "unreadEmailCount_{0}";

        /// <summary>
        /// chatTimes_{playerId}
        /// </summary>
        public const string ChatTimes = "chatTimes_{0}";

        /// <summary>
        /// workTimes_{playerId}_{workType}
        /// </summary>
        public const string WorkTimes = "workTimes_{0}_{1}";

        /// <summary>
        /// chatTimes_{playerId}
        /// </summary>
        public const string SearchTimes = "searchTimes_{0}";

        /// <summary>
        /// learnSkillId_{playerId}
        /// </summary>
        public const string LearnSkillId = "learnSkillId_{0}";

        /// <summary>
        /// RefuseFriend_{playerId}_{relationId}
        /// </summary>
        public const string RefuseFriend = "RefuseFriend_{0}_{1}";

        /// <summary>
        /// NpcFighting_{NpcId}
        /// </summary>
        public const string NpcFighting = "NpcFighting_{0}";


        /// <summary>
        /// ActionPoint_{playerId}
        /// </summary>
        public const string ActionPoint = "ActionPoint_{0}";
    }
}
