using Sharp.Shared.Objects;

namespace TnmsExtendableTargeting.Shared;

public interface ICustomTarget: ICustomTargetBase
{
    /// <summary>
    /// Target predication delegate
    /// </summary>
    /// <param name="targetClient">The target client for testing.</param>
    /// <param name="caller">The command executor. client or console. (this is useful for tracing client's ray when adding like @aim targeting)</param>
    public bool Resolve(IGameClient targetClient, IGameClient? caller);
}