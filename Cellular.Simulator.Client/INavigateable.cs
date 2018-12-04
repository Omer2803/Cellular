using System;

namespace Cellular.Simulator.Client
{
    public interface INavigateable
    {
        void NavigateTo(Type ViewType);
    }
}
