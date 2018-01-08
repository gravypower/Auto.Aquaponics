using Ponics.Kernel.Commands;

namespace Ponics.Organisms.Commands
{
    public class UpdateOrganismCommandHandler:ICommandHandler<UpdateOrganism>
    {
        private readonly IDataCommandHandler<UpdateOrganism> _updateDataCommandHandler;

        public UpdateOrganismCommandHandler(IDataCommandHandler<UpdateOrganism> updateDataCommandHandler)
        {
            _updateDataCommandHandler = updateDataCommandHandler;
        }

        public void Handle(UpdateOrganism command)
        {
            _updateDataCommandHandler.Handle(command);
        }
    }
}
