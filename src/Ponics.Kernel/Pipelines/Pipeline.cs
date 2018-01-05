using System.Collections.Generic;

namespace Ponics.Kernel.Pipelines
{
    public abstract class Pipeline<TNode, TInput, TContext>
        where  TNode : Node<TInput, TContext>
    {
        public TContext Context { get; set; }

        private readonly IEnumerable<TNode> _nodes;

        protected Pipeline(IEnumerable<TNode> nodes)
        {
            _nodes = nodes;
        }


        public TInput Execute(TInput input)
        {
            var root = default(TNode);
            var previous = default(TNode);

            foreach (var node in GetNodes())
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

            return root == null ? input : root.Execute(input);
        }

        private IEnumerable<TNode> GetNodes()
        {
            foreach (var node in _nodes)
            {
                node.Context = Context;

                if (node.ExecuteCondition())
                    yield return node;
            }
        }
    }

}
