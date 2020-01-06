/*
 *	This program is the CONFIDENTIAL and PROPRIETARY property 
 *	of Tomasello Software LLC. Any unauthorized use, reproduction or
 *	transfer of this computer program is strictly prohibited.
 *
 *      Copyright (c) 2004 Tomasello Software LLC.
 *	This is an unpublished work, and is subject to limited distribution and
 *	restricted disclosure only. ALL RIGHTS RESERVED.
 *
 *			RESTRICTED RIGHTS LEGEND
 *	Use, duplication, or disclosure by the Government is subject to
 *	restrictions set forth in subparagraph (c)(1)(ii) of the Rights in
 * 	Technical Data and Computer Software clause at DFARS 252.227-7013.
 *
 *	Angel Island UO Shard	Version 1.0
 *			Release A
 *			March 25, 2004
 */

/* Items/Lights/Lantern.cs
 * ChangeLog:
 *  6/5/04, Pix
 *		Merged in 1.0RC0 code.
 */

using System;
using Server;

namespace Server.Items
{
	public class Lantern : BaseEquipableLight
	{
		public override int LitItemID
		{
			get
			{
				if (ItemID == 0xA15 || ItemID == 0xA17)
					return ItemID;

				return 0xA22;
			}
		}

		public override int UnlitItemID
		{
			get
			{
				if (ItemID == 0xA18)
					return ItemID;

				return 0xA25;
			}
		}

		[Constructable]
		public Lantern()
			: base(0xA25)
		{
			if (Burnout)
				Duration = TimeSpan.FromMinutes(20);
			else
				Duration = TimeSpan.Zero;

			Burning = false;
			Light = LightType.Circle300;
			Weight = 2.0;
		}

		public Lantern(Serial serial)
			: base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);
			writer.Write((int)0);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);
			int version = reader.ReadInt();
		}
	}

	public class LanternOfSouls : Lantern
	{
		public override int LabelNumber { get { return 1061618; } } // Lantern of Souls

		[Constructable]
		public LanternOfSouls()
		{
			Hue = 0x482;
		}

		public LanternOfSouls(Serial serial)
			: base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);
			writer.Write((int)0);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);
			int version = reader.ReadInt();
		}
	}
}