﻿using System;
using System.Text;
using LogForU.Core.Layouts.Interfaces;

namespace LogForU.CustomLayouts
{
    public class XmlLayout : ILayout
    {
        public XmlLayout()
        {
        }

        public string Format
        {
            get
            {
                StringBuilder sb = new();
                sb.AppendLine("<log>");
                sb.AppendLine("\t<date>{0}</date>");
                sb.AppendLine("\t<level>{1}</level>");
                sb.AppendLine("\t<message>{2}</message>");
                sb.AppendLine("</log>");

                return sb.ToString();
            }
        }
    }
}

