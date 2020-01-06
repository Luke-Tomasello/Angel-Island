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

namespace Server.Gumps
{
	public delegate void NoticeGumpCallback(Mobile from, object state);

	public class NoticeGump : Gump
	{
		private NoticeGumpCallback m_Callback;
		private object m_State;

		public NoticeGump(int header, int headerColor, object content, int contentColor, int width, int height, NoticeGumpCallback callback, object state)
			: base((640 - width) / 2, (480 - height) / 2)
		{
			m_Callback = callback;
			m_State = state;

			Closable = false;

			AddPage(0);

			AddBackground(0, 0, width, height, 5054);

			AddImageTiled(10, 10, width - 20, 20, 2624);
			AddAlphaRegion(10, 10, width - 20, 20);
			AddHtmlLocalized(10, 10, width - 20, 20, header, headerColor, false, false);

			AddImageTiled(10, 40, width - 20, height - 80, 2624);
			AddAlphaRegion(10, 40, width - 20, height - 80);

			if (content is int)
				AddHtmlLocalized(10, 40, width - 20, height - 80, (int)content, contentColor, false, true);
			else if (content is string)
				AddHtml(10, 40, width - 20, height - 80, String.Format("<BASEFONT COLOR=#{0:X6}>{1}</BASEFONT>", contentColor, content), false, true);

			AddImageTiled(10, height - 30, width - 20, 20, 2624);
			AddAlphaRegion(10, height - 30, width - 20, 20);
			AddButton(10, height - 30, 4005, 4007, 1, GumpButtonType.Reply, 0);
			AddHtmlLocalized(40, height - 30, 120, 20, 1011036, 32767, false, false); // OKAY
		}

		public override void OnResponse(Server.Network.NetState sender, RelayInfo info)
		{
			if (info.ButtonID == 1 && m_Callback != null)
				m_Callback(sender.Mobile, m_State);
		}
	}
}