using CA221012_2;

Random rnd = new();
List<Fish> fishList = new();
string[] fishes = { "ponty", "harcsa", "keszeg", "kárász", "aranyhal", "busa", };

InitRndFishList(100);
// foreach (var fish in fishList) fish.GetFishInfo();
Simulation(100);
Console.WriteLine($"hal maradt: {fishList.Count}");

void Simulation(int round)
{
	for (int i = 0; i < round; i++)
	{
		int x, y;
		do
		{
			x = rnd.Next(fishList.Count);
			y = rnd.Next(fishList.Count);
		} while (x == y);

		if (fishList[x].Predator != fishList[y].Predator)
		{
			Fish r, n;

			if (fishList[x].Predator)
			{
				r = fishList[x];
				n = fishList[y];
			}
			else
			{
                r = fishList[y];
                n = fishList[x];
            }

			if (r.SwimTop <= n.SwimBtm && n.SwimTop <= r.SwimBtm)
			{
				if (rnd.Next(100) < 30)
				{
					fishList.Remove(n);
					if (r.Weight * 1.1f <= 40f)
						r.Weight *= 1.1f;
					else r.Weight = 40f;

					r.GetFishInfo();
					Console.WriteLine("megeszi: ");
					n.GetFishInfo();
					Console.WriteLine("---------");
				}
				else
				{
					r.GetFishInfo();
					Console.WriteLine("nem akarja megenni:");
					n.GetFishInfo();
                    Console.WriteLine("---------");
                }
			}
			else
			{
                r.GetFishInfo();
                Console.WriteLine("nem éri el:");
                n.GetFishInfo();
                Console.WriteLine("---------");
            }

        }
	}
}

void InitRndFishList(int pieces)
{
	for (int i = 0; i < pieces; i++)
	{
		fishList.Add(new Fish(
			weight: rnd.Next(1, 81) / 2f,
			predator: rnd.Next(100) < 10,
			swimTop: rnd.Next(401),
			swimDepth: rnd.Next(10, 401),
			species: fishes[rnd.Next(fishes.Length)]));
	}
}