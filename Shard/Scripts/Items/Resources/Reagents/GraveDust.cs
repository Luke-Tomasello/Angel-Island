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
using Server;
using Server.Items;

namespace Server.Items
{
	public class GraveDust : BaseReagent, ICommodity
	{
		string ICommodity.Description
		{
			get
			{
				return String.Format("{0} grave dust", Amount);
			}
		}

		[Constructable]
		public GraveDust()
			: this(1)
		{
		}

		[Constructable]
		public GraveDust(int amount)
			: base(0xF8F, amount)
		{
		}

		public GraveDust(Serial serial)
			: base(serial)
		{
		}

		public override Item Dupe(int amount)
		{
			return base.Dupe(new GraveDust(amount), amount);
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
	}
}