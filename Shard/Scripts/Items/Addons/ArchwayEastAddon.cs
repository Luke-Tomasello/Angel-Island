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
	public class ArchwayEastAddon : BaseAddon
	{
		public override BaseAddonDeed Deed
		{
			get
			{
				return new ArchwayEastAddonDeed();
			}
		}

		[Constructable]
		public ArchwayEastAddon()
		{
			AddonComponent ac = null;
			ac = new AddonComponent(1955);
			AddComponent(ac, 0, 2, 0);
			ac = new AddonComponent(1955);
			AddComponent(ac, 0, 1, 0);
			ac = new AddonComponent(1955);
			AddComponent(ac, 0, 0, 0);
			ac = new AddonComponent(1955);
			AddComponent(ac, 0, -1, 0);
			ac = new AddonComponent(1955);
			AddComponent(ac, 0, -2, 0);
			ac = new AddonComponent(1955);
			AddComponent(ac, 0, 2, 5);
			ac = new AddonComponent(1955);
			AddComponent(ac, 0, 1, 26);
			ac = new AddonComponent(1955);
			AddComponent(ac, 0, 0, 26);
			ac = new AddonComponent(1955);
			AddComponent(ac, 0, -1, 26);
			ac = new AddonComponent(1955);
			AddComponent(ac, 0, -2, 5);
			ac = new AddonComponent(1955);
			AddComponent(ac, 0, 2, 10);
			ac = new AddonComponent(1955);
			AddComponent(ac, 0, 2, 15);
			ac = new AddonComponent(1955);
			AddComponent(ac, 0, 2, 20);
			ac = new AddonComponent(1955);
			AddComponent(ac, 0, -2, 10);
			ac = new AddonComponent(1955);
			AddComponent(ac, 0, -2, 15);
			ac = new AddonComponent(1955);
			AddComponent(ac, 0, -2, 20);
			ac = new AddonComponent(1956);
			AddComponent(ac, 0, 2, 25);
			ac = new AddonComponent(1956);
			AddComponent(ac, 0, 1, 31);
			ac = new AddonComponent(1958);
			AddComponent(ac, 0, -2, 25);
			ac = new AddonComponent(1958);
			AddComponent(ac, 0, -1, 31);
			ac = new AddonComponent(1955);
			AddComponent(ac, 0, 0, 31);
			ac = new AddonComponent(1957);
			AddComponent(ac, 1, 1, 0);
			ac = new AddonComponent(1957);
			AddComponent(ac, 1, 0, 0);
			ac = new AddonComponent(1957);
			AddComponent(ac, 1, -1, 0);
			ac = new AddonComponent(1961);
			AddComponent(ac, 1, 2, 0);
			ac = new AddonComponent(1962);
			AddComponent(ac, 1, -2, 0);
			ac = new AddonComponent(1959);
			AddComponent(ac, -1, -1, 0);
			ac = new AddonComponent(1959);
			AddComponent(ac, -1, 0, 0);
			ac = new AddonComponent(1959);
			AddComponent(ac, -1, 1, 0);
			ac = new AddonComponent(1963);
			AddComponent(ac, -1, 2, 0);
			ac = new AddonComponent(1960);
			AddComponent(ac, -1, -2, 0);

		}

		public ArchwayEastAddon(Serial serial)
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

	public class ArchwayEastAddonDeed : BaseAddonDeed
	{
		public override BaseAddon Addon
		{
			get
			{
				return new ArchwayEastAddon();
			}
		}

		[Constructable]
		public ArchwayEastAddonDeed()
		{
			Name = "ArchwayEast";
		}

		public ArchwayEastAddonDeed(Serial serial)
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