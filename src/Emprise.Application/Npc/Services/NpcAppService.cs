﻿using AutoMapper;
using Emprise.Domain.Core.Authorization;
using Emprise.Domain.Core.Bus;
using Emprise.Domain.Core.Interfaces;
using Emprise.Domain.Npc.Entity;
using Emprise.Domain.Npc.Services;
using Emprise.Domain.Player.Services;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;


namespace Emprise.Application.User.Services
{
    public class NpcAppService : INpcAppService
    {
        private readonly IMediatorHandler _bus;
        private readonly IMapper _mapper;
        private readonly INpcDomainService _npcDomainService;
        private readonly IPlayerDomainService _playerDomainService;
        private readonly IAccountContext _account;
        private readonly IScriptDomainService _scriptDomainService;
        private readonly INpcScriptDomainService _npcScriptDomainService;
        private readonly IMudProvider _mudProvider;
        private readonly ILogger<NpcAppService> _logger;

        public NpcAppService(IMediatorHandler bus, IMapper mapper, INpcDomainService npcDomainService, IPlayerDomainService playerDomainService, IAccountContext account, IScriptDomainService scriptDomainService, INpcScriptDomainService npcScriptDomainService,  IMudProvider mudProvider, ILogger<NpcAppService> logger)
        {
            _bus = bus;
            _mapper = mapper;
            _npcDomainService = npcDomainService;
            _playerDomainService = playerDomainService;
            _account = account;
            _scriptDomainService = scriptDomainService;
            _npcScriptDomainService = npcScriptDomainService;
            _mudProvider = mudProvider;
            _logger = logger;
        }

        public async Task<NpcEntity> Get(int id)
        {
            return await _npcDomainService.Get(id);
        }


        /*
        public async Task<NpcInfo> GetNpc(int playerId,int id)
        {
            var npcInfo = new NpcInfo()
            {
                Descriptions = new List<string>(),
                Actions = new List<NpcAction>()
            };
            var npc = await _npcDomainService.Get(id);
            if (npc == null)
            {
                return npcInfo;
            }


            npcInfo.Id = id;
            npcInfo.Name = npc.Name;
            string genderStr = npc.Gender.ToGender();

            if(npc.Type == NpcTypeEnum.人物)
            {
                //npcInfo.Actions.Add(new NpcAction { Name = NpcActionEnum.给予.ToString() });
            }        

            if (npc.CanFight)
            {
                npcInfo.Actions.Add(new NpcAction { Name = NpcActionEnum.切磋.ToString() });
            }

            if (npc.CanKill)
            {
                npcInfo.Actions.Add(new NpcAction { Name = NpcActionEnum.杀死.ToString() });
            }

            var player = await _playerDomainService.Get(_account.PlayerId);

            npcInfo.Descriptions.Add(npc.Description??"");
            npcInfo.Descriptions.Add($"{genderStr}{npc.Age.ToAge()}");
            npcInfo.Descriptions.Add($"{genderStr}{npc.Per.ToPer(npc.Age, npc.Gender)}");
            npcInfo.Descriptions.Add($"{genderStr}{npc.Exp.ToKunFuLevel(player.Exp)}");


            var npcScripts = await _npcScriptDomainService.Query(x => x.NpcId == npc.Id);
            foreach (var npcScript in npcScripts)
            {
                var script = await _scriptDomainService.Get(npcScript.ScriptId);

                if (script != null)
                {
                    npcInfo.Actions.Add(new NpcAction { Name = script.Name, ScriptId = script.Id, CommandId = 0 });
                }
              
            }


            await _bus.RaiseEvent(new ChatWithNpcEvent(playerId, npc.Id)).ConfigureAwait(false);

            return npcInfo;
        }*/
        
         


        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
