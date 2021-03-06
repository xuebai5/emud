﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Emprise.Domain.Core.Enums
{
    public enum WareCategoryEnum
    {
        丹药 = 101,//增加体力内力生命
        武器 = 102,//装备后增加攻击、防御
        服装 = 103,
        //暗器 = 4,//用来减少对方生命值
        宝物 = 105,//从商城购买，特殊用途
        材料 = 106,//挖矿、伐木、采药等获得
        //宝石 = 7,//由原材料合成，可以增加武器属性
        宝箱 = 108, //宝箱内由若干其他物品
        秘籍 = 109, //武功秘籍

        碎片 = 110,


        //工具 = 111,//用来挖矿、伐木、采药等
        //毒药=112
    }


    public enum WareTypeEnum
    {
        丹药= 101001,

        刀 = 102001,
        剑 = 102002,
        枪 = 102003,



        衣服 = 103001,
        帽 = 103002,
        鞋 = 103003,

        宝物=105001,

        木材=106001,



        秘籍残卷 =110001,

    }

    public enum WareStatusEnum
    {
        装备 = 1,
        卸下 = 0
    }

    public enum WareEffectEnum
    {
        增加攻击 = 1,
        增加防御 = 2,
        增加内力 = 3,
        增加气血 = 4,

    }

    public enum WarePartEnum
    {
        头部 = 1,
        衣服 = 2,
        裤子 = 3,
        鞋子 = 4,
        腰带 = 5,
        武器 = 6
    }
}
