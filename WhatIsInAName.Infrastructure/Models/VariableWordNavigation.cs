using System.Collections.Generic;

namespace WhatIsInAName.Infrastructure.Models
{
    public class VariableWordNavigation
    {
        private readonly LinkedList<VariableWord> _navigation;

        private LinkedListNode<VariableWord> _current;

        public VariableWordNavigation(VariableWord root)
        {
            _navigation = new LinkedList<VariableWord>();
            _navigation.AddFirst(root);
            _current = _navigation.First;
        }

        public VariableWord Current => _current.Value;

        public bool IsHasPrev => _current.Previous != null;

        public bool IsHasNext => _current.Next != null;

        public void Prev()
        {
            if (_current.Previous == null)
            {
                return;
            }

            _current = _current.Previous;
        }

        public void Next()
        {
            if (_current.Next == null)
            {
                return;
            }

            _current = _current.Next;
        }

        public void AddRange(IEnumerable<VariableWord> range)
        {
            foreach (var next in range)
            {
                Add(next);
            }
        }

        public void Add(VariableWord next)
        {
            _navigation.AddLast(next);
        }
    }
}
