using System.Collections.Generic;
using System.Globalization;
using Sharp.Shared;
using Sharp.Shared.Enums;
using Sharp.Shared.Objects;
using TnmsExtendableTargeting.Shared;

namespace TnmsExtendableTargeting.BuiltinTargets;

public class Alive(ISharedSystem sharedSystem): ICustomTarget
{
    private static readonly Dictionary<string, string> LangMap = new();

    static Alive()
    {
        LangMap["en"] = "Alive Players";
        LangMap["ja"] = "生存しているプレイヤー";
    }
    
    public string Prefix => "@alive";
    
    public string LocalizedTargetName(CultureInfo culture)
    {
        if (LangMap.TryGetValue(culture.TwoLetterISOLanguageName, out var lang))
            return lang;
        
        return Prefix;
    }

    public bool Resolve(IGameClient targetClient, IGameClient? caller)
    {
        return sharedSystem.GetEntityManager().FindPlayerPawnBySlot(targetClient.Slot)?.LifeState == LifeState.Alive;
    }
}