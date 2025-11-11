using Sharp.Shared.Objects;

namespace TnmsExtendableTargeting.Shared;

public interface ICustomParameterizedTarget: ICustomTargetBase
{
    /// <summary>
    /// Resolve Custom parameterized target
    /// </summary>
    /// <param name="param">parameter</param>
    /// <param name="targetClient">target client to check</param>
    /// <param name="caller">null if caller is console</param>
    /// <returns>Return true, if targetClient is valid with correspond targeting prefix</returns>
    public bool Resolve(string param, IGameClient targetClient, IGameClient? caller);
}