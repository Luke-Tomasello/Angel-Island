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
using Server.Guilds;
using Server.Prompts;

namespace Server.Gumps
{
	public class GuildCharterPrompt : Prompt
	{
		private Mobile m_Mobile;
		private Guild m_Guild;

		public GuildCharterPrompt(Mobile m, Guild g)
		{
			m_Mobile = m;
			m_Guild = g;
		}

		public override void OnCancel(Mobile from)
		{
			if (GuildGump.BadLeader(m_Mobile, m_Guild))
				return;

			GuildGump.EnsureClosed(m_Mobile);
			m_Mobile.SendGump(new GuildmasterGump(m_Mobile, m_Guild));
		}

		public override void OnResponse(Mobile from, string text)
		{
			if (GuildGump.BadLeader(m_Mobile, m_Guild))
				return;

			text = text.Trim();

			if (text.Length > 50)
				text = text.Substring(0, 50);

			if (text.Length > 0)
				m_Guild.Charter = text;

			m_Mobile.SendLocalizedMessage(1013072); // Enter the new website for the guild (50 characters max):
			m_Mobile.Prompt = new GuildWebsitePrompt(m_Mobile, m_Guild);

			GuildGump.EnsureClosed(m_Mobile);
			m_Mobile.SendGump(new GuildmasterGump(m_Mobile, m_Guild));
		}
	}
}