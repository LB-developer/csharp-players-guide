namespace Overloading;

public class Ship
{
    private int _Health { get; set; }
    private int _Width { get; set; }
    private int _Length { get; set; }
    private Cannon _Cannon { get; }


    public Ship()
    {
        _Health = 10;
        _Width = 3;
        _Length = 4;
        _Cannon = new Cannon();
    }

    public Ship(AttackTypes type)
    {
        _Cannon = type switch
        {
            AttackTypes.Normal => new Cannon(),
            AttackTypes.Risky => new SpikeCannon(),
            _ => new Cannon()
        };

    }

    public int FireCannons => this._Cannon.Shoot();

    public enum AttackTypes
    {
        Normal,
        Risky
    }
}

public class Cannon
{
    internal int _ShotsFired { get; set; }
    internal int _Damage { get; init; }

    public Cannon()
    {
        _ShotsFired = 0;
        _Damage = 2;
    }

    public virtual int Shoot()
    {
        var random = new Random();
        if (random.NextDouble() < 0.25)
        {
            return 0;
        }
        else
        {
            _ShotsFired++;
            return _Damage;
        }
    }
}

public class SpikeCannon : Cannon
{
    public SpikeCannon()
    {
        _Damage = 4;
    }

    public override int Shoot()
    {

        var random = new Random();
        if (random.NextDouble() < 0.40)
        {
            return 0;
        }
        else
        {
            _ShotsFired++;
            return _Damage;
        }

    }
}
