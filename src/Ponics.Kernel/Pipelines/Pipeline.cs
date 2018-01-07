using System.Collections.Generic;

namespace Ponics.Kernel.Pipelines
{
    public abstract class Pipeline<TNode, TInput, TContext>
        where  TNode : Node<TInput, TContext>
    {
        protected TContext Context { get; set; }

        private readonly IEnumerable<TNode> _nodes;

        protected Pipeline(IEnumerable<TNode> nodes)
        {
            _nodes = nodes;
        }

        public TInput Execute(TInput input, TContext context)
        {
            var root = default(TNode);
            var previous = default(TNode);
            Context = context;

            foreach (var node in _nodes)
            {
                if (root == null)
                {
                    root = node;
                }
                else
                {
                    previous.Register(node);
                }
                previous = node;
            }

            return root == null ? input : root.Execute(input, context);
        }        
    }
}