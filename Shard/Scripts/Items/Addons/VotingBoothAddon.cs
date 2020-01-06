/////////////////////////////////////////////////
//
// Automatically generated by the
// AddonGenerator script by Arya
//
/////////////////////////////////////////////////
using System;
using Server;
using Server.Items;

namespace Server.Items
{
	public class VotingBoothAddon : BaseAddon
	{
		public override BaseAddonDeed Deed
		{
			get
			{
				return new VotingBoothAddonDeed();
			}
		}

		[Constructable]
		public VotingBoothAddon()
		{
			AddonComponent ac = null;
			ac = new AddonComponent(7);
			AddComponent(ac, 0, 2, 0);
			ac = new AddonComponent(7);
			AddComponent(ac, -1, 2, 0);
			ac = new AddonComponent(8);
			AddComponent(ac, -2, 2, 0);
			ac = new AddonComponent(8);
			AddComponent(ac, -2, 0, 0);
			ac = new AddonComponent(8);
			AddComponent(ac, -2, 1, 0);
			ac = new AddonComponent(8);
			AddComponent(ac, -2, -1, 0);
			ac = new AddonComponent(8);
			AddComponent(ac, -2, -2, 0);
			ac = new AddonComponent(6);
			AddComponent(ac, 1, 2, 0);
			ac = new AddonComponent(7);
			AddComponent(ac, 0, -3, 0);
			ac = new AddonComponent(7);
			AddComponent(ac, -1, -3, 0);
			ac = new AddonComponent(7);
			AddComponent(ac, 1, -3, 0);
			ac = new AddonComponent(8);
			AddComponent(ac, 1, -2, 0);
			ac = new AddonComponent(8);
			AddComponent(ac, 1, 1, 0);
			ac = new AddonComponent(4827);
			AddComponent(ac, 2, -1, 0);
			ac = new AddonComponent(4827);
			AddComponent(ac, 2, 0, 0);
			ac = new AddonComponent(1997);
			AddComponent(ac, -1, -2, 20);
			ac = new AddonComponent(1997);
			AddComponent(ac, -1, -1, 20);
			ac = new AddonComponent(1997);
			AddComponent(ac, -1, 0, 20);
			ac = new AddonComponent(1997);
			AddComponent(ac, -1, 1, 20);
			ac = new AddonComponent(1997);
			AddComponent(ac, -1, 2, 20);
			ac = new AddonComponent(1997);
			AddComponent(ac, 0, -2, 20);
			ac = new AddonComponent(1997);
			AddComponent(ac, 0, -1, 20);
			ac = new AddonComponent(1997);
			AddComponent(ac, 0, 0, 20);
			ac = new AddonComponent(1997);
			AddComponent(ac, 0, 1, 20);
			ac = new AddonComponent(1997);
			AddComponent(ac, 0, 2, 20);
			ac = new AddonComponent(1997);
			AddComponent(ac, 1, -2, 20);
			ac = new AddonComponent(1997);
			AddComponent(ac, 1, -1, 20);
			ac = new AddonComponent(1997);
			AddComponent(ac, 1, 0, 20);
			ac = new AddonComponent(1997);
			AddComponent(ac, 1, 1, 20);
			ac = new AddonComponent(1997);
			AddComponent(ac, 1, 2, 20);
			ac = new AddonComponent(3026);
			AddComponent(ac, 2, 2, 2);
			ac = new AddonComponent(1474);
			AddComponent(ac, 0, 2, 24);
			ac = new AddonComponent(1474);
			AddComponent(ac, 0, 1, 24);
			ac = new AddonComponent(1474);
			AddComponent(ac, 0, 0, 24);
			ac = new AddonComponent(1474);
			AddComponent(ac, 0, -1, 24);
			ac = new AddonComponent(1474);
			AddComponent(ac, 0, -2, 24);
			ac = new AddonComponent(1475);
			AddComponent(ac, 1, 2, 21);
			ac = new AddonComponent(1475);
			AddComponent(ac, 1, 1, 21);
			ac = new AddonComponent(1475);
			AddComponent(ac, 1, 0, 21);
			ac = new AddonComponent(1475);
			AddComponent(ac, 1, -1, 21);
			ac = new AddonComponent(1475);
			AddComponent(ac, 1, -2, 21);
			ac = new AddonComponent(1475);
			AddComponent(ac, 2, -2, 18);
			ac = new AddonComponent(1475);
			AddComponent(ac, 2, -1, 18);
			ac = new AddonComponent(1475);
			AddComponent(ac, 2, 0, 18);
			ac = new AddonComponent(1475);
			AddComponent(ac, 2, 1, 18);
			ac = new AddonComponent(1475);
			AddComponent(ac, 2, 2, 18);
			ac = new AddonComponent(1476);
			AddComponent(ac, -1, -2, 21);
			ac = new AddonComponent(1476);
			AddComponent(ac, -1, -1, 21);
			ac = new AddonComponent(1476);
			AddComponent(ac, -1, 0, 21);
			ac = new AddonComponent(1476);
			AddComponent(ac, -1, 1, 21);
			ac = new AddonComponent(1476);
			AddComponent(ac, -1, 2, 21);
			ac = new AddonComponent(1476);
			AddComponent(ac, -1, 3, 21);
			ac = new AddonComponent(1474);
			AddComponent(ac, 0, 3, 24);
			ac = new AddonComponent(1475);
			AddComponent(ac, 1, 3, 21);
			ac = new AddonComponent(1475);
			AddComponent(ac, 2, 3, 18);

		}

		public VotingBoothAddon(Serial serial)
			: base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);
			writer.Write(0); // Version
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);
			int version = reader.ReadInt();
		}
	}

	public class VotingBoothAddonDeed : BaseAddonDeed
	{
		public override BaseAddon Addon
		{
			get
			{
				return new VotingBoothAddon();
			}
		}

		[Constructable]
		public VotingBoothAddonDeed()
		{
			Name = "VotingBooth";
		}

		public VotingBoothAddonDeed(Serial serial)
			: base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);
			writer.Write(0); // Version
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);
			int version = reader.ReadInt();
		}
	}
}