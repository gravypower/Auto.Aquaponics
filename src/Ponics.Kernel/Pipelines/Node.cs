namespace Ponics.Kernel.Pipelines
{
    public abstract class Node<TInput, TContext>
    {
        private Node<TInput, TContext> _nextNode;
        protected TContext Context { get; set; }
        public abstract TInput DoExecute(TInput input);

        public TInput Execute(TInput input, TContext context)
        {
            Context = context;
            var value = DoExecute(input);

            if (_nextNode != null)
            {
                value = _nextNode.Execute(value, context);
            }

            return value;
        }

        public void Register(Node<TInput, TContext> nextNode)
        {
            _nextNode = nextNode;
        }
    }
}
