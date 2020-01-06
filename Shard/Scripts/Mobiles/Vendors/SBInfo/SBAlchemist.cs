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

/* Scripts/Mobiles/Vendors/SBInfo/SBAlchemist.cs
 * ChangeLog
 *  10/14/04, Froste
 *      Changed the amount argument to GenericBuyInfo from 999 to 20 for reagents, so the argument means something in GenericBuy.cs *      
 *  10/3/04, Jade
 *      Added Potion Keg Dye Tubs to the Sell List for 5k each.
 *	4/24/04, mith
 *		Commented all items from SellList so that NPCs don't buy from players.
 */

using System;
using System.Collections;
using Server.Items;

namespace Server.Mobiles
{
	public class SBAlchemist : SBInfo
	{
		private ArrayList m_BuyInfo = new InternalBuyInfo();
		private IShopSellInfo m_SellInfo = new InternalSellInfo();

		public SBAlchemist()
		{
		}

		public override IShopSellInfo SellInfo { get { return m_SellInfo; } }
		public override ArrayList BuyInfo { get { return m_BuyInfo; } }

		public class InternalBuyInfo : ArrayList
		{
			public InternalBuyInfo()
			{
				Add(new GenericBuyInfo(typeof(BlackPearl), 5, 20, 0xF7A, 0));
				Add(new GenericBuyInfo(typeof(Bloodmoss), 5, 20, 0xF7B, 0));
				Add(new GenericBuyInfo(typeof(MandrakeRoot), 3, 20, 0xF86, 0));
				Add(new GenericBuyInfo(typeof(Garlic), 3, 20, 0xF84, 0));
				Add(new GenericBuyInfo(typeof(Ginseng), 3, 20, 0xF85, 0));
				Add(new GenericBuyInfo(typeof(Nightshade), 3, 20, 0xF88, 0));
				Add(new GenericBuyInfo(typeof(SpidersSilk), 3, 20, 0xF8D, 0));
				Add(new GenericBuyInfo(typeof(SulfurousAsh), 3, 20, 0xF8C, 0));

				Add(new GenericBuyInfo(typeof(Bottle), 5, 100, 0xF0E, 0));

				Add(new GenericBuyInfo("1041060", typeof(HairDye), 37, 10, 0xEFF, 0));

				Add(new GenericBuyInfo(typeof(MortarPestle), 8, 10, 0xE9B, 0));
				//Jade: Add potion keg dye tub
				Add(new GenericBuyInfo("Potion Keg Dye Tub", typeof(PotionKegDyeTub), 5000, 20, 0xFAB, 0));

				Add(new GenericBuyInfo(typeof(NightSightPotion), 15, 10, 0xF06, 0));
				Add(new GenericBuyInfo(typeof(AgilityPotion), 15, 10, 0xF08, 0));
				Add(new GenericBuyInfo(typeof(StrengthPotion), 15, 10, 0xF09, 0));
				Add(new GenericBuyInfo(typeof(RefreshPotion), 15, 10, 0xF0B, 0));
				Add(new GenericBuyInfo(typeof(LesserCurePotion), 15, 10, 0xF07, 0));
				Add(new GenericBuyInfo(typeof(LesserHealPotion), 15, 10, 0xF0C, 0));
				Add(new GenericBuyInfo(typeof(LesserPoisonPotion), 15, 10, 0xF0A, 0));
				Add(new GenericBuyInfo(typeof(LesserExplosionPotion), 21, 10, 0xF0D, 0));
			}
		}

		public class InternalSellInfo : GenericSellInfo
		{
			public InternalSellInfo()
			{
				if (!Core.UOAI && !Core.UOAR && !Core.UOSP && !Core.UOMO)
				{	// cash buyback
					Add(typeof(BlackPearl), 3);
					Add(typeof(Bloodmoss), 3);
					Add(typeof(MandrakeRoot), 2);
					Add(typeof(Garlic), 2);
					Add(typeof(Ginseng), 2);
					Add(typeof(Nightshade), 2);
					Add(typeof(SpidersSilk), 2);
					Add(typeof(SulfurousAsh), 2);
					Add(typeof(Bottle), 3);
					Add(typeof(MortarPestle), 4);
					Add(typeof(HairDye), 19);

					Add(typeof(NightSightPotion), 7);
					Add(typeof(AgilityPotion), 7);
					Add(typeof(StrengthPotion), 7);
					Add(typeof(RefreshPotion), 7);
					Add(typeof(LesserCurePotion), 7);
					Add(typeof(LesserHealPotion), 7);
					Add(typeof(LesserPoisonPotion), 7);
					Add(typeof(LesserExplosionPotion), 10);
				}
			}
		}
	}
}
