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
using Server.Items;
using Server.Mobiles;

namespace Server.Items
{
	public class GlassblowingBook : Item
	{
		[Constructable]
		public GlassblowingBook()
			: base(0xFF4)
		{
			Name = "Crafting Glass With Glassblowing";
			Weight = 1.0;
		}

		public GlassblowingBook(Serial serial)
			: base(serial)
		{
		}

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

		public override void OnDoubleClick(Mobile from)
		{
			PlayerMobile pm = from as PlayerMobile;

			if (!IsChildOf(from.Backpack))
			{
				from.SendLocalizedMessage(1042001); // That must be in your pack for you to use it.
			}
			else if (pm == null || from.Skills[SkillName.Alchemy].Base < 100.0)
			{
				pm.SendMessage("Only a Grandmaster Alchemist can learn from this book.");
			}
			else if (pm.Glassblowing)
			{
				pm.SendMessage("You have already learned this information.");
			}
			else
			{
				pm.Glassblowing = true;
				pm.SendMessage("You have learned to make items from glass. You will need to find miners to mine find sand for you to make these items.");
				Delete();
			}
		}
	}
}