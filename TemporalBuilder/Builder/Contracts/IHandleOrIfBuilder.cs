namespace TemporalBuilder.Builder.Contracts;

public interface IHandleOrIfBuilder<T, TComplete> : IHandleBuilder<T, TComplete>, IIfBuilder<T, TComplete>
    where T : Enum;
    
    