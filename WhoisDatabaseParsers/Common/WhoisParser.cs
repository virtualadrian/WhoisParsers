﻿// -----------------------------------------------------------------------
// <copyright file="WhoisParser.cs" company="Microsoft">
// Copyright (c) Microsoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Geolocation.Whois.Parsers
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.IO;
    using System.Text;

    public class WhoisParser : IWhoisParser
    {
        public WhoisParser(ISectionTokenizer sectionTokenizer, ISectionParser sectionParser)
        {
            this.SectionTokenizer = sectionTokenizer;
            this.SectionParser = sectionParser;
        }

        public ISectionTokenizer SectionTokenizer { get; set; }

        public ISectionParser SectionParser { get; set; }

        public Dictionary<string, List<string>> ColumnsPerTypeFromReader(StreamReader reader)
        {
            string record;

            while ((record = this.SectionTokenizer.RetrieveRecord(reader)) != null)
            {
                this.SectionParser.Parse(record);
            }

            return this.SectionParser.TypeToFieldNamesList;
        }

        public Dictionary<string, List<string>> ColumnsPerTypeFromFile(string filePath)
        {
            using (var reader = new StreamReader(filePath))
            {
                return this.ColumnsPerTypeFromReader(reader);
            }
        }

        public IEnumerable<RawWhoisSection> RetrieveSectionsFromReader(StreamReader reader)
        {
            string record;

            while ((record = this.SectionTokenizer.RetrieveRecord(reader)) != null)
            {
                var section = this.SectionParser.Parse(record);

                if (section != null)
                {
                    yield return section;
                }
            }
        }

        public IEnumerable<RawWhoisSection> RetrieveSectionsFromReader(StreamReader reader, string desiredType)
        {
            return this.RetrieveSectionsFromReader(reader, new HashSet<string>() { desiredType });
        }

        public IEnumerable<RawWhoisSection> RetrieveSectionsFromReader(StreamReader reader, HashSet<string> desiredTypes)
        {
            string record;

            while ((record = this.SectionTokenizer.RetrieveRecord(reader)) != null)
            {
                var section = this.SectionParser.Parse(record);

                if (section != null && desiredTypes.Contains(section.Type))
                {
                    yield return section;
                }
            }
        }

        public IEnumerable<RawWhoisSection> RetrieveSectionsFromFile(string filePath)
        {
            using (var reader = new StreamReader(filePath))
            {
                foreach (var record in this.RetrieveSectionsFromReader(reader))
                {
                    yield return record;
                }
            }
        }

        public IEnumerable<RawWhoisSection> RetrieveSectionsFromFile(string filePath, string desiredType)
        {
            return this.RetrieveSectionsFromFile(filePath, new HashSet<string>() { desiredType });
        }

        public IEnumerable<RawWhoisSection> RetrieveSectionsFromFile(string filePath, HashSet<string> desiredTypes)
        {
            using (var reader = new StreamReader(filePath))
            {
                foreach (var section in this.RetrieveSectionsFromReader(reader, desiredTypes))
                {
                    yield return section;
                }
            }
        }

        public IEnumerable<RawWhoisSection> RetrieveSectionsFromString(string text)
        {
            return this.RetrieveSectionsFromReader(this.StreamFromString(text));
        }

        public IEnumerable<RawWhoisSection> RetrieveSectionsFromString(string text, string desiredType)
        {
            return this.RetrieveSectionsFromReader(this.StreamFromString(text), desiredType);
        }

        public IEnumerable<RawWhoisSection> RetrieveSectionsFromString(string text, HashSet<string> desiredTypes)
        {
            return this.RetrieveSectionsFromReader(this.StreamFromString(text), desiredTypes);
        }

        [SuppressMessage(category: "Microsoft.Reliability", checkId: "CA2000", Justification = "This memory stream needs to be disposed of outside this function")]
        private StreamReader StreamFromString(string text)
        {
            MemoryStream memoryStream = null;

            try
            {
                var textBytes = Encoding.UTF8.GetBytes(text);
                memoryStream = new MemoryStream(textBytes);
                return new StreamReader(memoryStream);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}