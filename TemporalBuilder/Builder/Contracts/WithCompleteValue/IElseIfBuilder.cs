﻿namespace TemporalBuilder.Builder.Contracts.WithCompleteValue;

public interface IElseIfBuilder<T, TComplete> : IInBuilder<T, TComplete>, IElseBuilder<T, TComplete> where T : Enum
{
    IHandleInIfBuilder<T, TComplete> ElseIf(Func<bool> condition);
}