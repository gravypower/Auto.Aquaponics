using ServiceStack;

namespace Ponics.Analysis.Levels.Commands
{
    public abstract class DeleteTolerance<TTolerance> : ToleranceCommand<TTolerance>
        where TTolerance : Tolerance
    {
        [ApiMember(ExcludeInSchema = true)]
        public abstract TTolerance Tolerance { get; set; }
    }
}
