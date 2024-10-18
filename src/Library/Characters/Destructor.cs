namespace Ucu.Poo.RoleplayGame;

public class Destructor: ICharacter, IEnemy
{
    public int VictoryPoints { get; } 

    private int health = 100;

    private List<IItem> items = new List<IItem>();

    public IReadOnlyCollection<IItem> Items
    {
        get { return this.items.AsReadOnly(); }
    }
    
    public Destructor (string name)
    {
        this.Name = name;

        this.AddItem(new Shield());
        this.AddItem(new Axe());
        this.VictoryPoints = 3;

    }

    public string Name { get; set; }

    public int AttackValue
    {
        get
        {
            int value = 0;
            foreach (IItem item in this.items)
            {
                if (item is IAttackItem)
                {
                    value += (item as IAttackItem).AttackValue;
                }
            }
            return value;
        }
    }

    public int DefenseValue
    {
        get
        {
            int value = 0;
            foreach (IItem item in this.items)
            {
                if (item is IDefenseItem)
                {
                    value += (item as IDefenseItem).DefenseValue;
                }
            }
            return value;
        }
    }

    public int Health
    {
        get
        {
            return this.health;
        }
        private set
        {
            this.health = value < 0 ? 0 : value;
        }
    }

    public void ReceiveAttack(int power)
    {
        if (this.DefenseValue < power)
        {
            this.Health =  this.Health - power + this.DefenseValue;
        }
    }

    public void Cure()
    {
        this.Health = 100;
    }

    public void AddItem(IItem item)
    {
        this.items.Add(item);
    }

    public void RemoveItem(IItem item)
    {
        this.items.Remove(item);
    }
}