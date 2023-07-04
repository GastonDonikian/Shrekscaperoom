public class CmdHeal : ICommand
{
    private IDamageable _damageable;
    private int _health;
    
    public CmdHeal(IDamageable damageable, int health)
    {
        _damageable = damageable;
        _health = health;
    }
    public void Execute() => _damageable.RecoverLife(_health);
}
