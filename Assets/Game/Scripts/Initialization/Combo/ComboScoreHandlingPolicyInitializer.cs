using Abstracts.Initialization;
using Systems.Combos.Handling;

namespace Initialization.Combo
{
    public class ComboScoreHandlingPolicyInitializer : InitializerBase<IComboScoreHandlingPolicy>
    {
        public override IComboScoreHandlingPolicy Create() => new ComboScoreHandlingPolicy();
    }
}