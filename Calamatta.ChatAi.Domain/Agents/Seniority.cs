namespace Calamatta.ChatAi.Domain.Agents;

public abstract class Seniority(int value, string name)
    : Enumeration<Seniority>(value, name)
{
    public static readonly Seniority Junior = new JuniorPrivate();
    public static readonly Seniority MidLevel = new MidLevelPrivate();
    public static readonly Seniority Senior = new SeniorPrivate();
    public static readonly Seniority TeamLead = new TeamLeadPrivate();
    public abstract decimal Multipliers { get; }

    private sealed class JuniorPrivate()
        : Seniority(1, nameof(Junior))
    {
        public override decimal Multipliers => 0.4m;
    }

    private sealed class MidLevelPrivate()
        : Seniority(2, nameof(MidLevel))
    {
        public override decimal Multipliers => 0.6m;
    }

    private sealed class SeniorPrivate()
        : Seniority(3, nameof(Senior))
    {
        public override decimal Multipliers => 0.8m;
    }

    private sealed class TeamLeadPrivate()
        : Seniority(4, nameof(TeamLead))
    {
        public override decimal Multipliers => 0.5m;
    }
}