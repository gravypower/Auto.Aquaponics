using Auto.Aquaponics.Commands;
using Auto.Aquaponics.Kernel.Data;

namespace Auto.Aquaponics.Analysis.Levels
{
    public class AddToleranceCommandHandler<TTolerance> : ICommandHandler<AddTolerance<TTolerance>> 
        where TTolerance : Tolerance
    {
        private readonly IDataCommandHandler<AddTolerance<TTolerance>> _addToleranceDataCommandHandler;

        public AddToleranceCommandHandler(IDataCommandHandler<AddTolerance<TTolerance>> addToleranceDataCommandHandler)
        {
            _addToleranceDataCommandHandler = addToleranceDataCommandHandler;
        }

        public void Handle(AddTolerance<TTolerance> command)
        {
            _addToleranceDataCommandHandler.Handle(command);
        }
    }
}
