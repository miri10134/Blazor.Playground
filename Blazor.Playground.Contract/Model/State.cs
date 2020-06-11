using System;
using System.Collections.Generic;
using System.Text;

namespace Blazor.Playground.Contract.Model
{
    internal sealed class State : IState
    {
        public int CurrentState { get; internal set; }
    }
}
