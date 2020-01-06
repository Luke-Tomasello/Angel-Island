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

using System;
using Server.Network;
using Server.Items;

namespace Server.Items
{
	[FlipableAttribute(0x13b4, 0x13b3)]
	public class Club : BaseBashing
	{
		public override WeaponAbility PrimaryAbility { get { return WeaponAbility.ShadowStrike; } }
		public override WeaponAbility SecondaryAbility { get { return WeaponAbility.Dismount; } }

		//		public override int AosStrengthReq{ get{ return 40; } }
		//		public override int AosMinDamage{ get{ return 11; } }
		//		public override int AosMaxDamage{ get{ return 13; } }
		//		public override int AosSpeed{ get{ return 44; } }
		//
		//		public override int OldMinDamage{ get{ return 8; } }
		//		public override int OldMaxDamage{ get{ return 24; } }
		public override int OldStrengthReq { get { return 10; } }
		public override int OldSpeed { get { return 40; } }

		public override int OldDieRolls { get { return 4; } }
		public override int OldDieMax { get { return 5; } }
		public override int OldAddConstant { get { return 4; } }

		public override int InitMinHits { get { return 31; } }
		public override int InitMaxHits { get { return 40; } }

		[Constructable]
		public Club()
			: base(0x13B4)
		{
			Weight = 9.0;
		}

		public Club(Serial serial)
			: base(serial)
		{
		}

// old name removed, see base class

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write((int)0); // version
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();
		}
	}
}