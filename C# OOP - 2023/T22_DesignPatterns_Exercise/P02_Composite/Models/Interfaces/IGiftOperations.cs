using System;
namespace P02_Composite.Models.Interfaces
{
    public interface IGiftOperations
    {
        void Add(GiftBase gift);
        void Remove(GiftBase gift);
    }
}

