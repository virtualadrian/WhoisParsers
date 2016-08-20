﻿// -----------------------------------------------------------------------
// <copyright file="Program.cs" company="Microsoft">
// Copyright (c) Microsoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Geolocation.RWhois.Console
{
    using System;
    using System.IO;
    using Whois.Normalization;
    using Whois.Parsers;
    using Whois.TsvExport;

    public static class Program
    {
        public static void Main(string[] args)
        {
            /*
            var client = new RWhoisClient("rwhois.isomedia.com", 4321);
            client.ConnectAsync().Wait();

            var parser = new WhoisParser(new RWhoisXferSectionTokenizer(), new RWhoisSectionParser());

            var sectionsForQueryTask = client.RetrieveSectionsForQueryAsync(parser, "-xfer 207.115.64.0/19");
            sectionsForQueryTask.Wait();

            foreach (var section in sectionsForQueryTask.Result)
            {
                Console.WriteLine(section);
            }

            Console.WriteLine("Done!");
            Console.ReadKey();
            */

            /*
            var client = new RWhoisClient("rwhois.frontiernet.net", 4321);
            client.ConnectAsync().Wait();

            var parser = new WhoisParser(new RWhoisXferSectionTokenizer(), new RWhoisSectionParser());

            var sectionsForQueryTask = client.RetrieveSectionsForQueryAsync(parser, "184.8.0.0");
            sectionsForQueryTask.Wait();

            foreach (var section in sectionsForQueryTask.Result)
            {
                Console.WriteLine(section);
            }

            Console.WriteLine("Done!");
            */

            /* RWhois server is broken
            var client = new RWhoisClient("rwhois.hopone.net", 4321);
            client.ConnectAsync().Wait();

            Console.WriteLine(client.RawClient.XferCommandSupported);

            // 74.84.128.0

            Console.WriteLine("Done");
            */

            /*
            var client = new RWhoisClient("rwhois.frontiernet.net", 4321);
            client.ConnectAsync().Wait();

            Console.WriteLine(client.RawClient.XferCommandSupported);
            Console.WriteLine("Done");
            */

            /*
            var crawler = new RWhoisCrawler("rwhois.frontiernet.net", 4321, crawlIterationDelayMilli: 10000);
            crawler.ConnectAsync().Wait();

            var outFolder = "./CrawlResults";

            if (!Directory.Exists(outFolder))
            {
                Directory.CreateDirectory(outFolder);
            }

            var consumer = new RWhoisConsumer(Path.Combine(outFolder, "FRTR.txt"));
            crawler.Subscribe(consumer);

            crawler.CrawlRangeAsync(IPAddressRange.Parse("184.8.0.0/13")).Wait();
            */

            /*
            var settings = new ReferralServerFinderSettings()
            {
                Parser = new WhoisParser(new SectionTokenizer(), new SectionParser()),
                OrganizationIdField = "OrgID",
                NetworkIdField = "NetHandle",
                ReferralServerField = "ReferralServer",
                NetworkRangeField = "NetRange"
            };

            Console.WriteLine("FindOrganizationsToRefServers");
            var organizationsToRefServers = ReferralServerFinder.FindOrganizationsToRefServers(settings: settings, organizationsFilePath: @"C:\Users\zmarty\Downloads\arin\organizations.txt");

            Console.WriteLine("FindOrganizationsToRefRanges");
            var organizationsToRefRanges = ReferralServerFinder.FindOrganizationsToRefRanges(settings: settings, organizationsToRefServers: organizationsToRefServers, networksFilePath: @"C:\Users\zmarty\Downloads\arin\networks.txt");
            */

            //// Diff:
            //// var organizationsWithRefServers = organizationsToRefServers.Keys;
            //// var organizationsWithRefRanges = organizationsToRefRanges.Keys;
            //// var organizationsWithoutRefRanges = organizationsWithRefServers.Except(organizationsWithRefRanges);

            ////var frtr = organizationsToRefRanges["FRTR"];

            /*
            var organizationsToRefServers = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
            {
                {
                    "FRTR",
                    "rwhois://rwhois.frontiernet.net:4321/"
                }
            };

            var organizationsToRefRanges = new Dictionary<string, HashSet<IPAddressRange>>(StringComparer.OrdinalIgnoreCase)
            {
                {
                    "FRTR",
                    new HashSet<IPAddressRange>()
                    {
                        IPAddressRange.Parse("184.8.0.0-184.15.255.255"),
                        IPAddressRange.Parse("216.37.128.0-216.37.255.255"),
                        IPAddressRange.Parse("199.224.64.0-199.224.127.255")
                    }
                }
            };
            */

            /*
            Console.WriteLine("RWhoisMultiCrawler");
            var multiCrawler = new RWhoisMultiCrawler("./CrawlResults", attemptCrawlOrganizations: true);
            multiCrawler.CrawlInParallel(organizationsToRefServers, organizationsToRefRanges).Wait();
            */

            /*
            var settings = new ReferralServerFinderSettings()
            {
                Parser = new WhoisParser(new SectionTokenizer(), new SectionParser()),
                OrganizationIdField = "OrgID",
                NetworkIdField = "NetHandle",
                ReferralServerField = "ReferralServer",
                NetworkRangeField = "NetRange"
            };

            Console.WriteLine("FindOrganizationsToRefServers");
            var organizationsToRefServers = ReferralServerFinder.FindOrganizationsToRefServers(settings: settings, organizationsFilePath: @"C:\Users\zmarty\Downloads\arin\organizations.txt");

            Console.WriteLine("FindOrganizationsToRefRanges");
            var organizationsToRefRanges = ReferralServerFinder.FindOrganizationsToRefRanges(settings: settings, organizationsToRefServers: organizationsToRefServers, networksFilePath: @"C:\Users\zmarty\Downloads\arin\networks.txt");

            //// Diff:
            //// var organizationsWithRefServers = organizationsToRefServers.Keys;
            //// var organizationsWithRefRanges = organizationsToRefRanges.Keys;
            //// var organizationsWithoutRefRanges = organizationsWithRefServers.Except(organizationsWithRefRanges);

            Console.WriteLine("RWhoisMultiCrawler");
            var multiCrawler = new RWhoisMultiCrawler("./", attemptCrawlOrganizations: true);
            multiCrawler.Crawl(organizationsToRefServers, organizationsToRefRanges);
            */

            /*
            var settings = new ReferralServerFinderSettings()
            {
                Parser = new WhoisParser(new SectionTokenizer(), new SectionParser()),
                OrganizationIdField = "OrgID",
                NetworkIdField = "NetHandle",
                ReferralServerField = "ReferralServer",
                NetworkRangeField = "NetRange"
            };

            var organizationsToRefServers = ReferralServerFinder.FindOrganizationsToRefServers(settings: settings, organizationsFilePath: @"C:\Users\zmarty\Downloads\arin\organizations.txt");

            var liveServers = 0;

            var liveXferTrue = 0;
            var liveXferFalse = 0;

            var liveConnectForEachQueryTrue = 0;
            var liveConnectForEachQueryFalse = 0;

            var errors = 0;
            var total = 0;

            foreach (var item in organizationsToRefServers)
            {
                total++;

                try
                {
                    var serverUri = new Uri(item.Value);

                    var hostname = serverUri.Host;
                    var port = serverUri.Port;

                    Console.WriteLine(string.Format(CultureInfo.InvariantCulture, "{0}:{1}", hostname, port));

                    var client = new RWhoisClient(hostname, port);
                    client.ConnectAsync().Wait();

                    Console.WriteLine(string.Format(CultureInfo.InvariantCulture, "===> {0}:{1} -> {2}", hostname, port, client.RawClient.XferCommandSupported));

                    if (client.RawClient.ConnectForEachQuery)
                    {
                        liveConnectForEachQueryTrue++;
                    }
                    else
                    {
                        liveConnectForEachQueryFalse++;
                    }

                    if (client.RawClient.XferCommandSupported)
                    {
                        liveXferTrue++;
                    }
                    else
                    {
                        liveXferFalse++;
                    }

                    liveServers++;

                    client.Disconnect();
                }
                catch (Exception ex)
                {
                    //Console.WriteLine(ex);
                    Console.WriteLine("===> Error");
                    errors++;
                }

                Console.WriteLine();

                if (total % 10 == 0)
                {
                    Console.WriteLine("Results so far:");
                    Console.WriteLine(string.Format(CultureInfo.InvariantCulture, "liveServers = {0}", liveServers));
                    Console.WriteLine(string.Format(CultureInfo.InvariantCulture, "liveXferTrue = {0}", liveXferTrue));
                    Console.WriteLine(string.Format(CultureInfo.InvariantCulture, "liveXferFalse = {0}", liveXferFalse));
                    Console.WriteLine(string.Format(CultureInfo.InvariantCulture, "liveConnectForEachQueryTrue = {0}", liveConnectForEachQueryTrue));
                    Console.WriteLine(string.Format(CultureInfo.InvariantCulture, "liveConnectForEachQueryFalse = {0}", liveConnectForEachQueryFalse));
                    Console.WriteLine(string.Format(CultureInfo.InvariantCulture, "errors = {0}", errors));
                    Console.WriteLine(string.Format(CultureInfo.InvariantCulture, "total = {0}", total));
                    Console.WriteLine();
                }
            }

            Console.WriteLine(string.Format(CultureInfo.InvariantCulture, "liveServers = {0}", liveServers));
            Console.WriteLine(string.Format(CultureInfo.InvariantCulture, "liveXferTrue = {0}", liveXferTrue));
            Console.WriteLine(string.Format(CultureInfo.InvariantCulture, "liveXferFalse = {0}", liveXferFalse));
            Console.WriteLine(string.Format(CultureInfo.InvariantCulture, "liveConnectForEachQueryTrue = {0}", liveConnectForEachQueryTrue));
            Console.WriteLine(string.Format(CultureInfo.InvariantCulture, "liveConnectForEachQueryFalse = {0}", liveConnectForEachQueryFalse));
            Console.WriteLine(string.Format(CultureInfo.InvariantCulture, "errors = {0}", errors));
            Console.WriteLine(string.Format(CultureInfo.InvariantCulture, "total = {0}", total));
            */

            /*
            var parser = new WhoisParser(new RWhoisXferSectionTokenizer(), new RWhoisSectionParser());

            var completeInputPath = @"C:\Users\zmarty\lacnic.db";
            var completeOutputPath = @"C:\Users\zmarty\lacnic.tsv";

            var tsvWriter = new LacnicTsvWriter();
            tsvWriter.ExportIpv4RangesToTsv(completeInputPath, completeOutputPath);
            */

            /*
            var settings = new ReferralServerFinderSettings()
            {
                Parser = new WhoisParser(new SectionTokenizer(), new SectionParser()),
                OrganizationIdField = "OrgID",
                NetworkIdField = "NetHandle",
                ReferralServerField = "ReferralServer",
                NetworkRangeField = "NetRange"
            };

            var organizationsToRefServers = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
            {
                {
                    "19EET",
                    "rwhois://rwhois.netelligent.ca:4321"
                }
            };

            var organizationsToRefRanges = new Dictionary<string, HashSet<IPAddressRange>>(StringComparer.OrdinalIgnoreCase)
            {
                {
                    "19EET",
                    new HashSet<IPAddressRange>
                    {
                        IPAddressRange.Parse("199.193.52.0-199.193.55.255"),
                        IPAddressRange.Parse("208.82.120.0-208.82.123.255"),
                        IPAddressRange.Parse("204.147.76.0-204.147.79.255"),
                        IPAddressRange.Parse("209.44.104.144-209.44.104.159"),
                        IPAddressRange.Parse("209.44.97.0-209.44.97.15"),
                        IPAddressRange.Parse("64.15.74.0-64.15.74.15"),
                        IPAddressRange.Parse("64.15.78.0-64.15.78.15")
                    }
                }
            };

            Console.WriteLine("RWhoisMultiCrawler");
            var multiCrawler = new RWhoisMultiCrawler("./CrawlResults", attemptCrawlOrganizations: true);
            multiCrawler.CrawlInParallel(organizationsToRefServers, organizationsToRefRanges).Wait();
            */

            //RWhoisTSV();
            //ArinTSV();

            Console.WriteLine("Done!");
            Console.ReadKey();
            Console.ReadKey();
            Console.ReadKey();
        }

        private static void RWhoisTSV()
        {
            var rwhoisTsvWriter = new RWhoisTsvWriter();
            ////rwhoisTsvWriter.ColumnsPerTypeToTsv(@"C:\git\WhoisParsers\RWhoisClient.Console\bin\Debug-Net45\CrawlResults\", @"C:\git\WhoisParsers\RWhoisClient.Console\bin\Debug-Net45\rWhoisColumnsPerType.tsv");
            rwhoisTsvWriter.NetworksWithLocationsToTsv(@"C:\git\WhoisParsers\RWhoisClient.Console\bin\Debug-Net45\CrawlResults\", @"C:\git\WhoisParsers\RWhoisClient.Console\bin\Debug-Net45\CrawlResultsLocationTsv\");
        }

        private static void ArinTSV()
        {
            var arinTsvWriter = new ArinTsvWriter();
            ////rwhoisTsvWriter.ColumnsPerTypeToTsv(@"C:\git\WhoisParsers\RWhoisClient.Console\bin\Debug-Net45\CrawlResults\", @"C:\git\WhoisParsers\RWhoisClient.Console\bin\Debug-Net45\rWhoisColumnsPerType.tsv");
            arinTsvWriter.NetworksWithLocationsToTsv(@"M:\Projects\Whois\ARIN\Raw\2016\07\17\arin_db.txt", @"M:\Projects\Whois\ARIN\Processed\2016\07\17", "2016-07-17-ARIN-NetworkLocations.tsv");
        }

        private static void AfrinicTSV()
        {
            var arinTsvWriter = new ArinTsvWriter();
            ////rwhoisTsvWriter.ColumnsPerTypeToTsv(@"C:\git\WhoisParsers\RWhoisClient.Console\bin\Debug-Net45\CrawlResults\", @"C:\git\WhoisParsers\RWhoisClient.Console\bin\Debug-Net45\rWhoisColumnsPerType.tsv");
            arinTsvWriter.NetworksWithLocationsToTsv(@"M:\Projects\Whois\ARIN\Raw\2016\07\17\arin_db.txt", @"M:\Projects\Whois\ARIN\Processed\2016\07\17", "2016-07-17-ARIN-NetworkLocations.tsv");
        }
    }
}
