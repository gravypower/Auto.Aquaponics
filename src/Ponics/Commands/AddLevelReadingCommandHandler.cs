using Ponics.Kernel.Commands;

namespace Ponics.Commands
{
    public class AddLevelReadingCommandHandler : ICommandHandler<AddLevelReading>
    {
        private readonly IDataCommandHandler<AddLevelReading> _addLevelReadingDataCommandHandler;

        public AddLevelReadingCommandHandler(IDataCommandHandler<AddLevelReading> addLevelReadingDataCommandHandler)
        {
            _addLevelReadingDataCommandHandler = addLevelReadingDataCommandHandler;
        }

        public void Handle(AddLevelReading command)
        {
            _addLevelReadingDataCommandHandler.Handle(command);
        }
    }
}
