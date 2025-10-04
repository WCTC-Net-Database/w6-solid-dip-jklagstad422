namespace W6_assignment_template.Interfaces
{
 \
    public interface ICombat
    {
        void Attack(ICharacter target, int damage);
        void Heal(int healAmount);
        void PerformSpecialAction();
    }
}