using System.Collections.Generic;
using System.Globalization;
using Sharp.Shared;
using Sharp.Shared.Enums;
using Sharp.Shared.Objects;
using TnmsExtendableTargeting.Shared;

namespace TnmsExtendableTargeting.BuiltinTargets;

public class Dead: ICustomTarget
{
    private static readonly Dictionary<string, string> LangMap = new();

    static Dead()
    {
        LangMap["en"] = "Dead Players";
        LangMap["ja"] = "死亡したプレイヤー";
    }
    
    public string Prefix => "@dead";
    
    public string LocalizedTargetName(CultureInfo culture)
    {
        if (LangMap.TryGetValue(culture.TwoLetterISOLanguageName, out var lang))
            return lang;
        
        return Prefix;
    }

    public bool Resolve(IGameClient targetClient, IGameClient? caller)
    {
        return targetClient.GetPlayerController()?.GetPlayerPawn()?.LifeState != LifeState.Alive;
    }
}