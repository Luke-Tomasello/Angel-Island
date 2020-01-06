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
using System.Collections;
using Server;

namespace Server.Mobiles
{
	[TypeAlias("Server.Mobiles.GargoyleStonecrafter")]
	public class StoneCrafter : BaseVendor
	{
		private ArrayList m_SBInfos = new ArrayList();
		protected override ArrayList SBInfos { get { return m_SBInfos; } }

		public override NpcGuild NpcGuild { get { return NpcGuild.TinkersGuild; } }

		[Constructable]
		public StoneCrafter()
			: base("the stone crafter")
		{
			SetSkill(SkillName.Carpentry, 85.0, 100.0);
		}

		public override void InitSBInfo()
		{
			m_SBInfos.Add(new SBStoneCrafter());
			m_SBInfos.Add(new SBStavesWeapon());
			m_SBInfos.Add(new SBCarpenter());
			m_SBInfos.Add(new SBWoodenShields());
		}

		public StoneCrafter(Serial serial)
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

			if (Title == "the stonecrafter")
				Title = "the stone crafter";
		}
	}
}