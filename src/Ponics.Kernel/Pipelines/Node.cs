namespace Ponics.Kernel.Pipelines
{
    public abstract class Node<TInput, TContext>
    {
        private Node<TInput, TContext> _nextNode;
        public TContext Context { get; set; }

        public abstract bool ExecuteCondition();
        public abstract TInput DoExecute(TInput input);

        public TInput Execute(TInput input)
        {
            var value = DoExecute(input);

            if (_nextNode != null)
            {
                value = _nextNode.Execute(value);
            }

            return value;
        }

        public void Register(Node<TInput, TContext> nextNode)
        {
            _nextNode = nextNode;
        }
    }
}
