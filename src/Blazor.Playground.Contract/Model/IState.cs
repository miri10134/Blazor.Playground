using System;
using System.Collections.Generic;
using System.Text;

namespace Blazor.Playground.Contract.Model
{
    public interface IState
    {
        int CurrentState { get; }
    }
}
