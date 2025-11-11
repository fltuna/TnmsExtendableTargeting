using Sharp.Shared.Objects;

namespace TnmsExtendableTargeting.Shared;

public interface ICustomSingleTarget: ICustomTargetBase
{
    /// <summary>
    /// Resolve single target
    /// </summary>
    /// <param name="caller">this is useful for tracing client's ray when adding like @aim targeting, and @me</param>
    /// <returns>Return client if found</returns>
    public IGameClient? Resolve(IGameClient? caller);
}